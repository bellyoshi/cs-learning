namespace MoveOtherAppWindow
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
            btnMoveToSecondMonitor = new Button();
            btnRestore = new Button();
            textBox1 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            LeftTexBox = new TextBox();
            TopTextBox = new TextBox();
            RightTextBox = new TextBox();
            BottomTextBox = new TextBox();
            SuspendLayout();
            // 
            // btnMoveToSecondMonitor
            // 
            btnMoveToSecondMonitor.Location = new Point(45, 164);
            btnMoveToSecondMonitor.Name = "btnMoveToSecondMonitor";
            btnMoveToSecondMonitor.Size = new Size(121, 29);
            btnMoveToSecondMonitor.TabIndex = 0;
            btnMoveToSecondMonitor.Text = "セカンドモニターへ合わせる";
            btnMoveToSecondMonitor.UseVisualStyleBackColor = true;
            btnMoveToSecondMonitor.Click += btnMoveToSecondMonitor_Click;
            // 
            // btnRestore
            // 
            btnRestore.Location = new Point(395, 92);
            btnRestore.Name = "btnRestore";
            btnRestore.Size = new Size(94, 29);
            btnRestore.TabIndex = 1;
            btnRestore.Text = "戻す";
            btnRestore.UseVisualStyleBackColor = true;
            btnRestore.Click += btnRestore_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(45, 51);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(480, 27);
            textBox1.TabIndex = 2;
            textBox1.Text = "Zoom ミーティング 参加者ID: 260447";
            // 
            // button1
            // 
            button1.Location = new Point(173, 164);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 3;
            button1.Text = "ダブルクリック";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnDoubleClick_Click;
            // 
            // button2
            // 
            button2.Location = new Point(273, 164);
            button2.Name = "button2";
            button2.Size = new Size(335, 29);
            button2.TabIndex = 4;
            button2.Text = "セカンドモニターへ移動しダブルクリック";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(536, 50);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 5;
            button3.Text = "獲得";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // LeftTexBox
            // 
            LeftTexBox.Location = new Point(45, 93);
            LeftTexBox.Name = "LeftTexBox";
            LeftTexBox.Size = new Size(78, 27);
            LeftTexBox.TabIndex = 6;
            // 
            // TopTextBox
            // 
            TopTextBox.Location = new Point(129, 93);
            TopTextBox.Name = "TopTextBox";
            TopTextBox.Size = new Size(78, 27);
            TopTextBox.TabIndex = 6;
            // 
            // RightTextBox
            // 
            RightTextBox.Location = new Point(213, 93);
            RightTextBox.Name = "RightTextBox";
            RightTextBox.Size = new Size(78, 27);
            RightTextBox.TabIndex = 6;
            // 
            // BottomTextBox
            // 
            BottomTextBox.Location = new Point(297, 93);
            BottomTextBox.Name = "BottomTextBox";
            BottomTextBox.Size = new Size(78, 27);
            BottomTextBox.TabIndex = 6;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(BottomTextBox);
            Controls.Add(RightTextBox);
            Controls.Add(TopTextBox);
            Controls.Add(LeftTexBox);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(btnRestore);
            Controls.Add(btnMoveToSecondMonitor);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnMoveToSecondMonitor;
        private Button btnRestore;
        private TextBox textBox1;
        private Button button1;
        private Button button2;
        private Button button3;
        private TextBox LeftTexBox;
        private TextBox TopTextBox;
        private TextBox RightTextBox;
        private TextBox BottomTextBox;
    }
}
