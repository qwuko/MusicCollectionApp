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
            this.listView.Columns.Add("Год", 75);

            // addTrackButton
            this.addTrackButton.Location = new System.Drawing.Point(10, 320);
            this.addTrackButton.Size = new System.Drawing.Size(100, 40);
            this.addTrackButton.Text = "Добавить трек";

            // removeTrackButton
            this.removeTrackButton.Location = new System.Drawing.Point(120, 320);
            this.removeTrackButton.Size = new System.Drawing.Size(100, 40);
            this.removeTrackButton.Text = "Удалить трек";

            // searchByArtistButton
            this.searchByArtistButton.Location = new System.Drawing.Point(230, 320);
            this.searchByArtistButton.Size = new System.Drawing.Size(120, 40);
            this.searchByArtistButton.Text = "Поиск по исполнителю";

            // sortByYearButton
            this.sortByYearButton.Location = new System.Drawing.Point(360, 320);
            this.sortByYearButton.Size = new System.Drawing.Size(120, 40);
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

            // Кнопка "Экспорт"
            this.exportButton = new System.Windows.Forms.Button();
            this.exportButton.Location = new System.Drawing.Point(10, 365);
            this.exportButton.Size = new System.Drawing.Size(100, 25);
            this.exportButton.Text = "Экспорт";
            this.exportButton.Name = "exportButton";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);

            // Кнопка "Импорт"
            this.importButton = new System.Windows.Forms.Button();
            this.importButton.Location = new System.Drawing.Point(120, 365);
            this.importButton.Size = new System.Drawing.Size(100, 25);
            this.importButton.Text = "Импорт";
            this.importButton.Name = "importButton";
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.importButton_Click);

            // Кнопка "Сохранить"
            this.saveButton = new System.Windows.Forms.Button();
            this.saveButton.Location = new System.Drawing.Point(230, 365);
            this.saveButton.Size = new System.Drawing.Size(120, 25);
            this.saveButton.Text = "Сохранить";
            this.saveButton.Name = "saveButton";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Enabled = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);

            // Добавляем кнопки на форму
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.importButton);
            this.Controls.Add(this.saveButton);
        }

        #endregion

        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.Button addTrackButton;
        private System.Windows.Forms.Button removeTrackButton;
        private System.Windows.Forms.Button searchByArtistButton;
        private System.Windows.Forms.Button sortByYearButton;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.Button saveButton;
    }
}