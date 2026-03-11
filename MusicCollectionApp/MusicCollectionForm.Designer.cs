namespace MusicCollectionApp
{
    partial class MusicCollectionForm
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
            this.listView = new System.Windows.Forms.ListView();
            this.addTrackButton = new System.Windows.Forms.Button();
            this.removeTrackButton = new System.Windows.Forms.Button();
            this.searchByArtistButton = new System.Windows.Forms.Button();
            this.sortByYearButton = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // listView
            this.listView.Location = new System.Drawing.Point(10, 10);
            this.listView.Size = new System.Drawing.Size(480, 300);
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.FullRowSelect = true;
            this.listView.Columns.Add("Исполнитель", 150);
            this.listView.Columns.Add("Название", 150);
            this.listView.Columns.Add("Жанр", 100);
            this.listView.Columns.Add("Год", 50);

            // addTrackButton
            this.addTrackButton.Location = new System.Drawing.Point(10, 320);
            this.addTrackButton.Size = new System.Drawing.Size(100, 25);
            this.addTrackButton.Text = "Добавить трек";

            // removeTrackButton
            this.removeTrackButton.Location = new System.Drawing.Point(120, 320);
            this.removeTrackButton.Size = new System.Drawing.Size(100, 25);
            this.removeTrackButton.Text = "Удалить трек";

            // searchByArtistButton
            this.searchByArtistButton.Location = new System.Drawing.Point(230, 320);
            this.searchByArtistButton.Size = new System.Drawing.Size(120, 25);
            this.searchByArtistButton.Text = "Поиск по исполнителю";

            // sortByYearButton
            this.sortByYearButton.Location = new System.Drawing.Point(360, 320);
            this.sortByYearButton.Size = new System.Drawing.Size(120, 25);
            this.sortByYearButton.Text = "Сортировать по году";

            // MusicCollectionForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 400);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.addTrackButton);
            this.Controls.Add(this.removeTrackButton);
            this.Controls.Add(this.searchByArtistButton);
            this.Controls.Add(this.sortByYearButton);
            this.Text = "Управление музыкальной коллекцией";
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.Button addTrackButton;
        private System.Windows.Forms.Button removeTrackButton;
        private System.Windows.Forms.Button searchByArtistButton;
        private System.Windows.Forms.Button sortByYearButton;
    }
}