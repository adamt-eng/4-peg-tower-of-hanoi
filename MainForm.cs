using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Four_Peg_Tower_of_Hanoi;

internal partial class MainForm : Form
{
    private static int _numberOfMoves;
    private static bool _terminating;

    internal MainForm() => InitializeComponent();

    #region GUI-related functions
    private readonly List<Panel>[] _pegs = new List<Panel>[4];
    private const int DiskHeight = 15;
    private void MainForm_Load(object sender, EventArgs e)
    {
        SetupPeg(pegA, 200);
        SetupPeg(pegB, 500);
        SetupPeg(pegC, 800);
        SetupPeg(pegD, 1100);

        for (var i = 0; i < 4; i++) _pegs[i] = [];

        LoadDisks();

        algorithmComboBox.SelectedIndex = 0;

        return;

        void SetupPeg(Panel peg, int x)
        {
            peg.BackColor = Color.BurlyWood;
            peg.Width = 10;
            peg.Height = 375;
            peg.Location = new Point(x, 325);
        }
    }
    private void LoadDisks()
    {
        for (var i = (int)numberOfDisksNumericUpDown.Value; i >= 1; i--)
        {
            var intensity = Math.Min(120 + (i - 1) % 10 * 15, 255);

            var disk = new Panel { Width = i * 10 + 10, Height = DiskHeight, BackColor = Color.FromArgb(intensity, 0, intensity), Tag = i };

            disk.Location = new Point(pegA.Left - disk.Width / 2 + 5, 700 - _pegs[0].Count * DiskHeight);
            disk.BringToFront();
            Controls.Add(disk);
            _pegs[0].Add(disk);
        }
    }
    private void MoveDisk(int fromPegIndex, int toPegIndex)
    {
        if (_pegs[fromPegIndex].Count == 0 || _terminating) return;

        ++_numberOfMoves;
        numberOfMovesLabel.Text = $"Number of Moves: {_numberOfMoves}";

        var disk = _pegs[fromPegIndex][^1];
        _pegs[fromPegIndex].RemoveAt(_pegs[fromPegIndex].Count - 1);

        var newX = new[] { pegA, pegB, pegC, pegD }[toPegIndex].Left - disk.Width / 2 + 5;
        var newY = 700 - _pegs[toPegIndex].Count * DiskHeight;
        disk.Invoke((MethodInvoker)(() => { disk.Location = new Point(newX, newY); }));

        _pegs[toPegIndex].Add(disk);

        Application.DoEvents();
        Thread.Sleep((int)DelayNumericUpDown.Value);
    }
    private void restartButton_Click(object sender, EventArgs e) => Application.Restart();
    private void terminateButton_Click(object sender, EventArgs e)
    {
        _terminating = true;
        Application.Exit();
    }
    private void startButton_Click(object sender, EventArgs e)
    {
        ToggleControls();

        switch (algorithmComboBox.SelectedIndex)
        {
            case 0: MoveDisks4Peg((int)numberOfDisksNumericUpDown.Value, 0, 3, 1, 2); break;
            case 1: MoveDisks4Peg((int)numberOfDisksNumericUpDown.Value, 0, 3, 1, 2, dynamicProgramming: true); break;
            case 2: MoveDisks4PegBruteForce((int)numberOfDisksNumericUpDown.Value, 3); break;
        }

        ToggleControls();

        return;

        void ToggleControls()
        {
            restartButton.Enabled = !restartButton.Enabled;
            algorithmComboBox.Enabled = !algorithmComboBox.Enabled;
            startButton.Enabled = !startButton.Enabled;
            numberOfDisksNumericUpDown.Enabled = !numberOfDisksNumericUpDown.Enabled;
            DelayNumericUpDown.Enabled = !DelayNumericUpDown.Enabled;
        }
    }
    private void NumberOfDisksNumericUpDown_ValueChanged(object sender, EventArgs e)
    {
        foreach (var control in Controls.OfType<Panel>().Where(control => control.BackColor != Color.BurlyWood).ToList()) Controls.Remove(control);
        foreach (var peg in _pegs) peg.Clear();

        LoadDisks();
    }
    #endregion

    private void MoveDisks3Peg(int n, int source, int destination, int auxiliary)
    {
        if (n == 0) return;

        MoveDisks3Peg(n - 1, source, auxiliary, destination);
        MoveDisk(source, destination);
        MoveDisks3Peg(n - 1, auxiliary, destination, source);
    }

    private static readonly Dictionary<int, int> MemoizationDictionary4Peg = new();
    private static readonly Dictionary<int, int> MemoizationDictionary3Peg = new();

    private void MoveDisks4Peg(int n, int source, int destination, int aux1, int aux2, bool dynamicProgramming = false)
    {
        switch (n)
        {
            case 0: return;
            case 1: MoveDisk(source, destination); return;
        }

        var m = n - (int)Math.Floor(Math.Sqrt(2 * n + 1)) + 1;

        if (dynamicProgramming)
        {
            var minMoves = int.MaxValue;

            for (var i = 1; i < n; i++)
            {
                if (!MemoizationDictionary4Peg.TryGetValue(i, out var value))
                {
                    value = CountMoves4Peg(i);
                    MemoizationDictionary4Peg[i] = value;
                }

                if (!MemoizationDictionary3Peg.ContainsKey(n - i))
                {
                    MemoizationDictionary3Peg[n - i] = CountMoves3Peg(n - i);
                }

                var moves = 2 * value + MemoizationDictionary3Peg[n - i];
                if (moves >= minMoves)
                {
                    continue;
                }

                minMoves = moves;
                m = i;
            }
        }

        MoveDisks4Peg(m, source, aux1, aux2, destination, dynamicProgramming);
        MoveDisks3Peg(n - m, source, destination, aux2);
        MoveDisks4Peg(m, aux1, destination, source, aux2, dynamicProgramming);
    }

    private static int CountMoves4Peg(int n)
    { 
        switch (n)
        {
            case 0: return 0;
            case 1: return 1;
        }

        var min = int.MaxValue;
        for (var m = 1; m < n; m++)
        {
            var moves = 2 * CountMoves4Peg(m) + CountMoves3Peg(n - m);
            if (moves < min) min = moves;
        }

        return min;
    }

    private static int CountMoves3Peg(int n) => (int)(Math.Pow(2, n) - 1);

    private void MoveDisks4PegBruteForce(int n, int destination)
    {
        var visited = new HashSet<string>();
        var initial = new List<List<int>> { Enumerable.Range(1, n).Reverse().ToList(), new(), new(), new() };

        var queue = new Queue<(List<List<int>> state, List<(int from, int to)> moves)>();
        queue.Enqueue((CloneState(initial), new List<(int, int)>()));

        while (queue.Count > 0)
        {
            var (state, moves) = queue.Dequeue();

            if (!visited.Add(string.Join("|", state.Select(peg => string.Join(",", peg))))) continue;

            if (state[destination].Count == n && state[destination].SequenceEqual(Enumerable.Range(1, n).Reverse()))
            {
                foreach (var (from, to) in moves) MoveDisk(from, to);
                return;
            }

            for (var from = 0; from < 4; from++)
            {
                if (state[from].Count == 0) continue;

                var disk = state[from][^1];
                for (var to = 0; to < 4; to++)
                {
                    if (from == to || state[to].Count > 0 && state[to][^1] < disk) continue;

                    var newState = CloneState(state);
                    newState[from].RemoveAt(newState[from].Count - 1);
                    newState[to].Add(disk);

                    queue.Enqueue((newState, new List<(int, int)>(moves) { (from, to) }));
                }
            }
        }

        return;

        static List<List<int>> CloneState(List<List<int>> state) => state.Select(peg => new List<int>(peg)).ToList();
    }
}