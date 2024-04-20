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
            txtSearchTitle = new TextBox();
            btnSearch = new Button();
            lstWindows = new ListBox();
            btnMoveToSecondMonitor = new Button();
            btnDoubleClick = new Button();
            btnReturnToOriginal = new Button();
            SuspendLayout();
            // 
            // txtSearchTitle
            // 
            txtSearchTitle.Location = new Point(56, 64);
            txtSearchTitle.Margin = new Padding(4);
            txtSearchTitle.Name = "txtSearchTitle";
            txtSearchTitle.Size = new Size(599, 31);
            txtSearchTitle.TabIndex = 2;
            txtSearchTitle.Text = "Zoom";
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(670, 62);
            btnSearch.Margin = new Padding(4);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(118, 36);
            btnSearch.TabIndex = 5;
            btnSearch.Text = "検索";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // lstWindows
            // 
            lstWindows.FormattingEnabled = true;
            lstWindows.ItemHeight = 25;
            lstWindows.Location = new Point(56, 125);
            lstWindows.Name = "lstWindows";
            lstWindows.Size = new Size(754, 229);
            lstWindows.TabIndex = 6;
            // 
            // btnMoveToSecondMonitor
            // 
            btnMoveToSecondMonitor.Location = new Point(56, 386);
            btnMoveToSecondMonitor.Name = "btnMoveToSecondMonitor";
            btnMoveToSecondMonitor.Size = new Size(139, 34);
            btnMoveToSecondMonitor.TabIndex = 7;
            btnMoveToSecondMonitor.Text = "セカンドモニターへ";
            btnMoveToSecondMonitor.UseVisualStyleBackColor = true;
            btnMoveToSecondMonitor.Click += btnMoveToSecondMonitor_Click;
            // 
            // btnDoubleClick
            // 
            btnDoubleClick.Location = new Point(214, 386);
            btnDoubleClick.Name = "btnDoubleClick";
            btnDoubleClick.Size = new Size(127, 34);
            btnDoubleClick.TabIndex = 8;
            btnDoubleClick.Text = "ダブルクリック";
            btnDoubleClick.UseVisualStyleBackColor = true;
            btnDoubleClick.Click += btnDoubleClick_Click;
            // 
            // btnReturnToOriginal
            // 
            btnReturnToOriginal.Location = new Point(366, 386);
            btnReturnToOriginal.Name = "btnReturnToOriginal";
            btnReturnToOriginal.Size = new Size(112, 34);
            btnReturnToOriginal.TabIndex = 9;
            btnReturnToOriginal.Text = "元の位置に戻す";
            btnReturnToOriginal.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 562);
            Controls.Add(btnReturnToOriginal);
            Controls.Add(btnDoubleClick);
            Controls.Add(btnMoveToSecondMonitor);
            Controls.Add(lstWindows);
            Controls.Add(btnSearch);
            Controls.Add(txtSearchTitle);
            Margin = new Padding(4);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtSearchTitle;
        private Button btnSearch;
        private ListBox lstWindows;
        private Button btnMoveToSecondMonitor;
        private Button btnDoubleClick;
        private Button btnReturnToOriginal;
    }
}
