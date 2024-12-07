namespace ThreadManager
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            buttonStart = new Button();
            textBoxN = new MaskedTextBox();
            richTextBoxArray = new RichTextBox();
            richTextBoxSortedArray = new RichTextBox();
            textBoxThreadsCount = new MaskedTextBox();
            label1 = new Label();
            label2 = new Label();
            groupBox1 = new GroupBox();
            comboBoxThreads = new ComboBox();
            comboBoxPriority = new ComboBox();
            buttonChangePriority = new Button();
            groupBox2 = new GroupBox();
            label3 = new Label();
            label4 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // buttonStart
            // 
            buttonStart.Location = new Point(18, 74);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(67, 23);
            buttonStart.TabIndex = 0;
            buttonStart.Text = "Start";
            buttonStart.UseVisualStyleBackColor = true;
            buttonStart.Click += buttonStart_Click;
            // 
            // textBoxN
            // 
            textBoxN.Location = new Point(18, 35);
            textBoxN.Mask = "0000000";
            textBoxN.Name = "textBoxN";
            textBoxN.Size = new Size(67, 23);
            textBoxN.TabIndex = 1;
            textBoxN.TextAlign = HorizontalAlignment.Center;
            textBoxN.ValidatingType = typeof(int);
            // 
            // richTextBoxArray
            // 
            richTextBoxArray.Location = new Point(279, 26);
            richTextBoxArray.Name = "richTextBoxArray";
            richTextBoxArray.Size = new Size(284, 128);
            richTextBoxArray.TabIndex = 3;
            richTextBoxArray.Text = "";
            // 
            // richTextBoxSortedArray
            // 
            richTextBoxSortedArray.Location = new Point(279, 187);
            richTextBoxSortedArray.Name = "richTextBoxSortedArray";
            richTextBoxSortedArray.Size = new Size(284, 128);
            richTextBoxSortedArray.TabIndex = 4;
            richTextBoxSortedArray.Text = "";
            // 
            // textBoxThreadsCount
            // 
            textBoxThreadsCount.Location = new Point(102, 35);
            textBoxThreadsCount.Mask = "0";
            textBoxThreadsCount.Name = "textBoxThreadsCount";
            textBoxThreadsCount.Size = new Size(67, 23);
            textBoxThreadsCount.TabIndex = 5;
            textBoxThreadsCount.TextAlign = HorizontalAlignment.Center;
            textBoxThreadsCount.ValidatingType = typeof(int);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 17);
            label1.Name = "label1";
            label1.Size = new Size(16, 15);
            label1.TabIndex = 6;
            label1.Text = "N";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(102, 17);
            label2.Name = "label2";
            label2.Size = new Size(100, 15);
            label2.TabIndex = 7;
            label2.Text = "Кількість потоків";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(textBoxThreadsCount);
            groupBox1.Controls.Add(textBoxN);
            groupBox1.Controls.Add(buttonStart);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(236, 148);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            // 
            // comboBoxThreads
            // 
            comboBoxThreads.FormattingEnabled = true;
            comboBoxThreads.Location = new Point(17, 32);
            comboBoxThreads.Name = "comboBoxThreads";
            comboBoxThreads.Size = new Size(64, 23);
            comboBoxThreads.TabIndex = 9;
            // 
            // comboBoxPriority
            // 
            comboBoxPriority.Items.AddRange(new object[] { "Lowest", "Normal", "Highest", "BelowNormal", "AboveNormal" });
            comboBoxPriority.Location = new Point(104, 32);
            comboBoxPriority.Name = "comboBoxPriority";
            comboBoxPriority.Size = new Size(121, 23);
            comboBoxPriority.TabIndex = 10;
            // 
            // buttonChangePriority
            // 
            buttonChangePriority.Location = new Point(17, 88);
            buttonChangePriority.Name = "buttonChangePriority";
            buttonChangePriority.Size = new Size(67, 23);
            buttonChangePriority.TabIndex = 8;
            buttonChangePriority.Text = "Change";
            buttonChangePriority.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(buttonChangePriority);
            groupBox2.Controls.Add(comboBoxPriority);
            groupBox2.Controls.Add(comboBoxThreads);
            groupBox2.Location = new Point(10, 174);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(238, 141);
            groupBox2.TabIndex = 11;
            groupBox2.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(279, 8);
            label3.Name = "label3";
            label3.Size = new Size(49, 15);
            label3.TabIndex = 8;
            label3.Text = "Массив";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(279, 169);
            label4.Name = "label4";
            label4.Size = new Size(131, 15);
            label4.TabIndex = 12;
            label4.Text = "Посортований массив";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(604, 363);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(richTextBoxSortedArray);
            Controls.Add(richTextBoxArray);
            Name = "Form1";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonStart;
        private MaskedTextBox textBoxN;
        private RichTextBox richTextBoxArray;
        private RichTextBox richTextBoxSortedArray;
        private MaskedTextBox textBoxThreadsCount;
        private Label label1;
        private Label label2;
        private GroupBox groupBox1;
        private ComboBox comboBoxThreads;
        private MaskedTextBox maskedTextBox1;
        private MaskedTextBox maskedTextBox2;
        private Button button2;
        private ComboBox comboBoxPriority;
        private Button buttonChangePriority;
        private GroupBox groupBox2;
        private Label label3;
        private Label label4;
    }
}
