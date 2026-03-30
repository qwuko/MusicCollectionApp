using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

public class MusicCollection
{
    private List<MusicTrack> tracks = new List<MusicTrack>();
    private ListView listView;

    public MusicCollection(ListView listView)
    {
        this.listView = listView;
        LoadTracks();
    }

    private void LoadTracks()
    {
        listView.Items.Clear();
        foreach (var track in tracks)
        {
            string artist = track.Artist ?? "";
            string title = track.Title ?? "";
            string genre = track.Genre ?? "";
            string year = track.Year.ToString();

            var item = new ListViewItem(new[] { artist, title, genre, year });
            listView.Items.Add(item);
        }
    }

    public void AddTrack(MusicTrack track)
    {
        tracks.Add(track);
        LoadTracks();
        MessageBox.Show("Трек добавлен.");
    }

    public void RemoveTrack(MusicTrack track)
    {
        if (track == null)
        {
            MessageBox.Show("Ошибка: трек не указан.", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        var existingTrack = tracks.FirstOrDefault(t =>
            t.Artist == track.Artist &&
            t.Title == track.Title &&
            t.Genre == track.Genre &&
            t.Year == track.Year);

        if (existingTrack != null)
        {
            tracks.Remove(existingTrack);
            LoadTracks();
            MessageBox.Show("Трек удалён.", "Успешно",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        else
        {
            MessageBox.Show("Трек не найден в коллекции.", "Внимание",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    public void SearchByArtist(string artist)
    {
        var foundTracks = tracks.Where(t => t.Artist.IndexOf(artist, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
        if (foundTracks.Any())
        {
            listView.Items.Clear();
            foreach (var track in foundTracks)
            {
                listView.Items.Add(new ListViewItem(new[] { track.Artist, track.Title, track.Genre, track.Year.ToString() }));
            }
            MessageBox.Show("Найденные треки:");
        }
        else
        {
            MessageBox.Show("Треки не найдены.");
        }
    }

    public void SortByYear()
    {
        var sortedTracks = tracks.OrderBy(t => t.Year).ToList();
        listView.Items.Clear();
        foreach (var track in sortedTracks)
        {
            listView.Items.Add(new ListViewItem(new[] { track.Artist, track.Title, track.Genre, track.Year.ToString() }));
        }
        MessageBox.Show("Сортировка по году выполнена.");
    }
}