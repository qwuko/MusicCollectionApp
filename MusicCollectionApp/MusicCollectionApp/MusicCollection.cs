using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Text;

public class MusicCollection
{
    private List<MusicTrack> tracks = new List<MusicTrack>();
    private ListView listView;

    private string lastFilePath = null;
    private string lastFormat = null;

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

    public void ExportToFile(string filePath)
    {
        try
        {
            string ext = Path.GetExtension(filePath).ToLower();
            char separator = GetSeparator(ext);
            using (StreamWriter sw = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                sw.WriteLine(string.Join(separator.ToString(), "Artist", "Title", "Genre", "Year"));
                foreach (var track in tracks)
                {
                    string artist = EscapeField(track.Artist, separator);
                    string title = EscapeField(track.Title, separator);
                    string genre = EscapeField(track.Genre, separator);
                    sw.WriteLine($"{artist}{separator}{title}{separator}{genre}{separator}{track.Year}");
                }
            }
            lastFilePath = filePath;
            lastFormat = ext.TrimStart('.');
            MessageBox.Show($"Коллекция экспортирована в файл:\n{filePath}", "Экспорт", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка при экспорте: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    public void ImportFromFile(string filePath)
    {
        try
        {
            string ext = Path.GetExtension(filePath).ToLower();
            char separator = GetSeparator(ext);
            var newTracks = new List<MusicTrack>();
            bool headerChecked = false;
            int lineNumber = 0;

            using (StreamReader sr = new StreamReader(filePath, Encoding.UTF8))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    lineNumber++;
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    if (!headerChecked)
                    {
                        string[] headerParts = line.Split(separator);
                        if (headerParts.Length != 4)
                            throw new Exception($"Некорректный заголовок: ожидается 4 колонки, найдено {headerParts.Length}.");

                        for (int i = 0; i < 4; i++)
                        {
                            string actual = headerParts[i].Trim().Trim('"');
                            string expected = i == 0 ? "Artist" : i == 1 ? "Title" : i == 2 ? "Genre" : "Year";
                            if (!string.Equals(actual, expected, StringComparison.OrdinalIgnoreCase))
                                throw new Exception($"Ошибка заголовка: ожидается '{expected}', найдено '{actual}'.");
                        }
                        headerChecked = true;
                        continue;
                    }

                    string[] parts = line.Split(separator);
                    if (parts.Length < 4)
                        throw new Exception($"Строка {lineNumber}: ожидается 4 поля, найдено {parts.Length}.");

                    string artist = parts[0].Trim();
                    string title = parts[1].Trim();
                    string genre = parts[2].Trim();
                    if (!int.TryParse(parts[3].Trim(), out int year))
                        throw new Exception($"Строка {lineNumber}: значение года '{parts[3].Trim()}' не является числом.");

                    newTracks.Add(new MusicTrack(artist, title, genre, year));
                }
            }

            if (!headerChecked)
                throw new Exception("Файл не содержит данных или отсутствует заголовок.");

            if (newTracks.Count == 0)
                throw new Exception("В файле не найдено корректных треков.");

            tracks = newTracks;
            LoadTracks();
            lastFilePath = filePath;
            lastFormat = ext.TrimStart('.');

            MessageBox.Show($"Импорт выполнен. Загружено треков: {tracks.Count}", "Импорт",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка при импорте: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    public void SaveChanges()
    {
        if (!string.IsNullOrEmpty(lastFilePath))
        {
            ExportToFile(lastFilePath);
        }
        else
        {
            MessageBox.Show("Нет сохранённого файла. Сначала выполните экспорт.", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private char GetSeparator(string extension)
    {
        switch (extension)
        {
            case ".csv": return ',';
            case ".psv": return '|';
            case ".txt": return '\t';
            default: return ',';
        }
    }

    private string EscapeField(string field, char separator)
    {
        if (string.IsNullOrEmpty(field)) return "";
        bool needQuotes = field.Contains(separator) || field.Contains("\"") || field.Contains("\n") || field.Contains("\r");
        if (needQuotes)
        {
            field = field.Replace("\"", "\"\"");
            return $"\"{field}\"";
        }
        return field;
    }

    private string[] SplitLine(string line, char separator)
    {
        List<string> result = new List<string>();
        bool inQuotes = false;
        int start = 0;
        for (int i = 0; i < line.Length; i++)
        {
            if (line[i] == '"')
                inQuotes = !inQuotes;
            else if (line[i] == separator && !inQuotes)
            {
                string field = line.Substring(start, i - start);
                result.Add(UnescapeField(field));
                start = i + 1;
            }
        }
        string lastField = line.Substring(start);
        result.Add(UnescapeField(lastField));
        return result.ToArray();
    }

    private string UnescapeField(string field)
    {
        if (string.IsNullOrEmpty(field)) return "";
        if (field.StartsWith("\"") && field.EndsWith("\""))
        {
            field = field.Substring(1, field.Length - 2);
            field = field.Replace("\"\"", "\"");
        }
        return field;
    }
}