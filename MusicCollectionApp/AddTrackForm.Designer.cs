namespace MusicCollectionApp
{
    partial class AddTrackForm
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
            this.titleLabel = new System.Windows.Forms.Label();
            this.genreLabel = new System.Windows.Forms.Label();
            this.yearLabel = new System.Windows.Forms.Label();
            this.artistTextBox = new System.Windows.Forms.TextBox();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.genreTextBox = new System.Windows.Forms.TextBox();
            this.yearTextBox = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // artistLabel
            this.artistLabel.Text = "Исполнитель:";
            this.artistLabel.Location = new System.Drawing.Point(10, 10);

            // titleLabel
            this.titleLabel.Text = "Название:";
            this.titleLabel.Location = new System.Drawing.Point(10, 40);

            // genreLabel
            this.genreLabel.Text = "Жанр:";
            this.genreLabel.Location = new System.Drawing.Point(10, 70);

            // yearLabel
            this.yearLabel.Text = "Год:";
            this.yearLabel.Location = new System.Drawing.Point(10, 100);

            // artistTextBox
            this.artistTextBox.Location = new System.Drawing.Point(120, 10);
            this.artistTextBox.Width = 150;

            // titleTextBox
            this.titleTextBox.Location = new System.Drawing.Point(120, 40);
            this.titleTextBox.Width = 150;

            // genreTextBox
            this.genreTextBox.Location = new System.Drawing.Point(120, 70);
            this.genreTextBox.Width = 150;

            // yearTextBox
            this.yearTextBox.Location = new System.Drawing.Point(120, 100);
            this.yearTextBox.Width = 50;

            // okButton
            this.okButton.Text = "OK";
            this.okButton.Location = new System.Drawing.Point(10, 140);
            this.okButton.Size = new System.Drawing.Size(75, 23);

            // cancelButton
            this.cancelButton.Text = "Отмена";
            this.cancelButton.Location = new System.Drawing.Point(95, 140);
            this.cancelButton.Size = new System.Drawing.Size(75, 23);

            // AddTrackForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 200);
            this.Controls.Add(this.artistLabel);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.genreLabel);
            this.Controls.Add(this.yearLabel);
            this.Controls.Add(this.artistTextBox);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.genreTextBox);
            this.Controls.Add(this.yearTextBox);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Text = "Добавить трек";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label artistLabel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label genreLabel;
        private System.Windows.Forms.Label yearLabel;
        private System.Windows.Forms.TextBox artistTextBox;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.TextBox genreTextBox;
        private System.Windows.Forms.TextBox yearTextBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
    }
}