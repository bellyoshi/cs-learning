namespace NDDD.WinForm.Views
{
    partial class LatestView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SearchButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.AreaIDTextBox = new System.Windows.Forms.TextBox();
            this.MeasureDateTextBox = new System.Windows.Forms.TextBox();
            this.MeasureValueTextbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(62, 151);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(94, 29);
            this.SearchButton.TabIndex = 0;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "計測値";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "エリアID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "計測日時";
            // 
            // AreaIDTextBox
            // 
            this.AreaIDTextBox.Location = new System.Drawing.Point(123, 5);
            this.AreaIDTextBox.Name = "AreaIDTextBox";
            this.AreaIDTextBox.ReadOnly = true;
            this.AreaIDTextBox.Size = new System.Drawing.Size(163, 27);
            this.AreaIDTextBox.TabIndex = 2;
            // 
            // MeasureDateTextBox
            // 
            this.MeasureDateTextBox.Location = new System.Drawing.Point(123, 45);
            this.MeasureDateTextBox.Name = "MeasureDateTextBox";
            this.MeasureDateTextBox.ReadOnly = true;
            this.MeasureDateTextBox.Size = new System.Drawing.Size(163, 27);
            this.MeasureDateTextBox.TabIndex = 2;
            // 
            // MeasureValueTextbox
            // 
            this.MeasureValueTextbox.Location = new System.Drawing.Point(123, 87);
            this.MeasureValueTextbox.Name = "MeasureValueTextbox";
            this.MeasureValueTextbox.ReadOnly = true;
            this.MeasureValueTextbox.Size = new System.Drawing.Size(163, 27);
            this.MeasureValueTextbox.TabIndex = 2;
            // 
            // LatestView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 238);
            this.Controls.Add(this.MeasureValueTextbox);
            this.Controls.Add(this.MeasureDateTextBox);
            this.Controls.Add(this.AreaIDTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SearchButton);
            this.Name = "LatestView";
            this.Text = "LatestView";
            this.Controls.SetChildIndex(this.SearchButton, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.AreaIDTextBox, 0);
            this.Controls.SetChildIndex(this.MeasureDateTextBox, 0);
            this.Controls.SetChildIndex(this.MeasureValueTextbox, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button SearchButton;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox AreaIDTextBox;
        private TextBox MeasureDateTextBox;
        private TextBox MeasureValueTextbox;
    }
}