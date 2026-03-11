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
                MessageBox.Show("Сначала выберите трек для удаления.");
                return;
            }
            var track = new MusicTrack(
                listView.SelectedItems[0].SubItems[0].Text,
                listView.SelectedItems[0].SubItems[1].Text,
                listView.SelectedItems[0].SubItems[2].Text,
                int.Parse(listView.SelectedItems[0].SubItems[3].Text));
            musicCollection.RemoveTrack(track);
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