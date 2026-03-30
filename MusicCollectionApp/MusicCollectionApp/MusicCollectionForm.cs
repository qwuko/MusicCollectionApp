using System;
using System.Windows.Forms;

namespace MusicCollectionApp
{
    public partial class MusicCollectionForm : Form
    {
        private MusicCollection musicCollection;

        public MusicCollectionForm()
        {
            InitializeComponent(); // вызывает метод из Designer.cs
            musicCollection = new MusicCollection(listView);
            AttachEvents();
        }

        private void AttachEvents()
        {
            addTrackButton.Click += AddTrackButton_Click;
            removeTrackButton.Click += RemoveTrackButton_Click;
            searchByArtistButton.Click += SearchByArtistButton_Click;
            sortByYearButton.Click += SortByYearButton_Click;
        }

        private void AddTrackButton_Click(object sender, EventArgs e)
        {
            var addTrackForm = new AddTrackForm();
            if (addTrackForm.ShowDialog() == DialogResult.OK)
            {
                var track = new MusicTrack(
                    addTrackForm.Artist,
                    addTrackForm.Title,
                    addTrackForm.Genre,
                    addTrackForm.Year);
                musicCollection.AddTrack(track);
            }
        }

        private void RemoveTrackButton_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Сначала выберите трек для удаления.", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var selectedItem = listView.SelectedItems[0];

                if (selectedItem.SubItems.Count < 4)
                {
                    MessageBox.Show("Ошибка: недостаточно данных для удаления.", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string artist = selectedItem.SubItems[0]?.Text ?? "";
                string title = selectedItem.SubItems[1]?.Text ?? "";
                string genre = selectedItem.SubItems[2]?.Text ?? "";
                string yearText = selectedItem.SubItems[3]?.Text ?? "";

                if (!int.TryParse(yearText, out int year))
                {
                    MessageBox.Show("Ошибка: некорректный год трека.", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                artist = artist.Trim();
                title = title.Trim();
                genre = genre.Trim();

                var trackToRemove = new MusicTrack(artist, title, genre, year);

                musicCollection.RemoveTrack(trackToRemove);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchByArtistButton_Click(object sender, EventArgs e)
        {
            var searchForm = new SearchArtistForm();
            if (searchForm.ShowDialog() == DialogResult.OK)
            {
                musicCollection.SearchByArtist(searchForm.Artist);
            }
        }

        private void SortByYearButton_Click(object sender, EventArgs e)
        {
            musicCollection.SortByYear();
        }
    }
}