namespace MusicCollectionApp
{
    partial class SearchArtistForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.artistLabel = new System.Windows.Forms.Label();
            this.artistTextBox = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // artistLabel
            this.artistLabel.Text = "Исполнитель:";
            this.artistLabel.Location = new System.Drawing.Point(10, 10);

            // artistTextBox
            this.artistTextBox.Location = new System.Drawing.Point(10, 30);
            this.artistTextBox.Width = 260;

            // okButton
            this.okButton.Text = "OK";
            this.okButton.Location = new System.Drawing.Point(10, 60);
            this.okButton.Size = new System.Drawing.Size(75, 23);

            // cancelButton
            this.cancelButton.Text = "Отмена";
            this.cancelButton.Location = new System.Drawing.Point(95, 60);
            this.cancelButton.Size = new System.Drawing.Size(75, 23);

            // SearchArtistForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 100);
            this.Controls.Add(this.artistLabel);
            this.Controls.Add(this.artistTextBox);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Text = "Поиск по исполнителю";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label artistLabel;
        private System.Windows.Forms.TextBox artistTextBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
    }
}