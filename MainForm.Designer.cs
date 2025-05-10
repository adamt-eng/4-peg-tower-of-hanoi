using System.Drawing;
using System.Windows.Forms;

namespace Four_Peg_Tower_of_Hanoi
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private Panel pegA, pegB, pegC, pegD;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pegA = new Panel();
            pegB = new Panel();
            pegC = new Panel();
            pegD = new Panel();
            numberOfMovesLabel = new Label();
            startButton = new Button();
            numberOfDisksLabel = new Label();
            numberOfDisksNumericUpDown = new NumericUpDown();
            DelayNumericUpDown = new NumericUpDown();
            delayLabel = new Label();
            algorithmComboBox = new ComboBox();
            algorithmLabel = new Label();
            restartButton = new Button();
            terminateButton = new Button();
            ((System.ComponentModel.ISupportInitialize)numberOfDisksNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DelayNumericUpDown).BeginInit();
            SuspendLayout();
            // 
            // pegA
            // 
            pegA.Location = new Point(1334, 218);
            pegA.Name = "pegA";
            pegA.Size = new Size(200, 100);
            pegA.TabIndex = 0;
            // 
            // pegB
            // 
            pegB.Location = new Point(1327, 392);
            pegB.Name = "pegB";
            pegB.Size = new Size(200, 100);
            pegB.TabIndex = 1;
            // 
            // pegC
            // 
            pegC.Location = new Point(1324, 157);
            pegC.Name = "pegC";
            pegC.Size = new Size(200, 100);
            pegC.TabIndex = 2;
            // 
            // pegD
            // 
            pegD.Location = new Point(1324, 186);
            pegD.Name = "pegD";
            pegD.Size = new Size(200, 100);
            pegD.TabIndex = 3;
            // 
            // numberOfMovesLabel
            // 
            numberOfMovesLabel.BorderStyle = BorderStyle.FixedSingle;
            numberOfMovesLabel.Font = new Font("Segoe UI", 9.857143F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numberOfMovesLabel.ForeColor = Color.White;
            numberOfMovesLabel.Location = new Point(685, 14);
            numberOfMovesLabel.Margin = new Padding(5);
            numberOfMovesLabel.Name = "numberOfMovesLabel";
            numberOfMovesLabel.Size = new Size(601, 60);
            numberOfMovesLabel.TabIndex = 5;
            numberOfMovesLabel.Text = "Number of Moves: 0";
            numberOfMovesLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // startButton
            // 
            startButton.BackColor = Color.FromArgb(55, 55, 55);
            startButton.FlatStyle = FlatStyle.Flat;
            startButton.Font = new Font("Segoe UI", 10F);
            startButton.ForeColor = Color.White;
            startButton.Location = new Point(685, 84);
            startButton.Margin = new Padding(5);
            startButton.Name = "startButton";
            startButton.Size = new Size(194, 61);
            startButton.TabIndex = 6;
            startButton.Text = "Start";
            startButton.UseVisualStyleBackColor = false;
            startButton.Click += startButton_Click;
            // 
            // numberOfDisksLabel
            // 
            numberOfDisksLabel.Font = new Font("Segoe UI", 10F);
            numberOfDisksLabel.ForeColor = Color.White;
            numberOfDisksLabel.Location = new Point(12, 61);
            numberOfDisksLabel.Name = "numberOfDisksLabel";
            numberOfDisksLabel.Size = new Size(143, 39);
            numberOfDisksLabel.TabIndex = 8;
            numberOfDisksLabel.Text = "# of Disks:";
            numberOfDisksLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // numberOfDisksNumericUpDown
            // 
            numberOfDisksNumericUpDown.BackColor = Color.FromArgb(55, 55, 55);
            numberOfDisksNumericUpDown.Font = new Font("Segoe UI", 10F);
            numberOfDisksNumericUpDown.ForeColor = Color.White;
            numberOfDisksNumericUpDown.Location = new Point(160, 61);
            numberOfDisksNumericUpDown.Maximum = new decimal(new int[] { 25, 0, 0, 0 });
            numberOfDisksNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numberOfDisksNumericUpDown.Name = "numberOfDisksNumericUpDown";
            numberOfDisksNumericUpDown.Size = new Size(517, 39);
            numberOfDisksNumericUpDown.TabIndex = 9;
            numberOfDisksNumericUpDown.Value = new decimal(new int[] { 8, 0, 0, 0 });
            numberOfDisksNumericUpDown.ValueChanged += NumberOfDisksNumericUpDown_ValueChanged;
            // 
            // DelayNumericUpDown
            // 
            DelayNumericUpDown.BackColor = Color.FromArgb(55, 55, 55);
            DelayNumericUpDown.Font = new Font("Segoe UI", 10F);
            DelayNumericUpDown.ForeColor = Color.White;
            DelayNumericUpDown.Location = new Point(160, 106);
            DelayNumericUpDown.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            DelayNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            DelayNumericUpDown.Name = "DelayNumericUpDown";
            DelayNumericUpDown.Size = new Size(517, 39);
            DelayNumericUpDown.TabIndex = 11;
            DelayNumericUpDown.Value = new decimal(new int[] { 250, 0, 0, 0 });
            // 
            // delayLabel
            // 
            delayLabel.Font = new Font("Segoe UI", 10F);
            delayLabel.ForeColor = Color.White;
            delayLabel.Location = new Point(12, 106);
            delayLabel.Name = "delayLabel";
            delayLabel.Size = new Size(143, 39);
            delayLabel.TabIndex = 10;
            delayLabel.Text = "Delay (ms):";
            delayLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // algorithmComboBox
            // 
            algorithmComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            algorithmComboBox.Font = new Font("Segoe UI", 10F);
            algorithmComboBox.FormattingEnabled = true;
            algorithmComboBox.Items.AddRange(new object[] { "Divide and Conquer", "Dynamic Programming", "Brute Force" });
            algorithmComboBox.Location = new Point(160, 14);
            algorithmComboBox.Name = "algorithmComboBox";
            algorithmComboBox.Size = new Size(517, 39);
            algorithmComboBox.TabIndex = 13;
            // 
            // algorithmLabel
            // 
            algorithmLabel.Font = new Font("Segoe UI", 10F);
            algorithmLabel.ForeColor = Color.White;
            algorithmLabel.Location = new Point(14, 14);
            algorithmLabel.Margin = new Padding(5);
            algorithmLabel.Name = "algorithmLabel";
            algorithmLabel.Size = new Size(138, 39);
            algorithmLabel.TabIndex = 14;
            algorithmLabel.Text = "Algorithm:";
            algorithmLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // restartButton
            // 
            restartButton.BackColor = Color.FromArgb(55, 55, 55);
            restartButton.FlatStyle = FlatStyle.Flat;
            restartButton.Font = new Font("Segoe UI", 10F);
            restartButton.ForeColor = Color.White;
            restartButton.Location = new Point(889, 84);
            restartButton.Margin = new Padding(5);
            restartButton.Name = "restartButton";
            restartButton.Size = new Size(194, 61);
            restartButton.TabIndex = 15;
            restartButton.Text = "Restart";
            restartButton.UseVisualStyleBackColor = false;
            restartButton.Click += restartButton_Click;
            // 
            // terminateButton
            // 
            terminateButton.BackColor = Color.FromArgb(55, 55, 55);
            terminateButton.FlatStyle = FlatStyle.Flat;
            terminateButton.Font = new Font("Segoe UI", 10F);
            terminateButton.ForeColor = Color.White;
            terminateButton.Location = new Point(1093, 84);
            terminateButton.Margin = new Padding(5);
            terminateButton.Name = "terminateButton";
            terminateButton.Size = new Size(193, 61);
            terminateButton.TabIndex = 16;
            terminateButton.Text = "Terminate";
            terminateButton.UseVisualStyleBackColor = false;
            terminateButton.Click += terminateButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(33, 33, 33);
            ClientSize = new Size(1300, 800);
            Controls.Add(terminateButton);
            Controls.Add(restartButton);
            Controls.Add(algorithmLabel);
            Controls.Add(algorithmComboBox);
            Controls.Add(DelayNumericUpDown);
            Controls.Add(delayLabel);
            Controls.Add(numberOfDisksNumericUpDown);
            Controls.Add(numberOfDisksLabel);
            Controls.Add(startButton);
            Controls.Add(numberOfMovesLabel);
            Controls.Add(pegA);
            Controls.Add(pegB);
            Controls.Add(pegC);
            Controls.Add(pegD);
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "4-Peg Towers of Hanoi";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)numberOfDisksNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)DelayNumericUpDown).EndInit();
            ResumeLayout(false);
        }

        private Label numberOfMovesLabel;
        private Button startButton;
        private Label numberOfDisksLabel;
        private NumericUpDown numberOfDisksNumericUpDown;
        private NumericUpDown DelayNumericUpDown;
        private Label delayLabel;
        private ComboBox algorithmComboBox;
        private Label algorithmLabel;
        private Button restartButton;
        private Button terminateButton;
    }
}