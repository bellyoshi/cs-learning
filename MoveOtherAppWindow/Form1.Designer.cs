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
            SuspendLayout();
            // 
            // btnMoveToSecondMonitor
            // 
            btnMoveToSecondMonitor.Location = new Point(79, 141);
            btnMoveToSecondMonitor.Name = "btnMoveToSecondMonitor";
            btnMoveToSecondMonitor.Size = new Size(94, 29);
            btnMoveToSecondMonitor.TabIndex = 0;
            btnMoveToSecondMonitor.Text = "セカンドモニターへ合わせる";
            btnMoveToSecondMonitor.UseVisualStyleBackColor = true;
            btnMoveToSecondMonitor.Click += btnMoveToSecondMonitor_Click;
            // 
            // btnRestore
            // 
            btnRestore.Location = new Point(79, 198);
            btnRestore.Name = "btnRestore";
            btnRestore.Size = new Size(94, 29);
            btnRestore.TabIndex = 1;
            btnRestore.Text = "button2";
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
            button1.Location = new Point(190, 141);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 3;
            button1.Text = "ダブルクリック";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnDoubleClick_Click;
            // 
            // button2
            // 
            button2.Location = new Point(290, 141);
            button2.Name = "button2";
            button2.Size = new Size(335, 29);
            button2.TabIndex = 4;
            button2.Text = "セカンドモニターへ移動しダブルクリック";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
    }
}
