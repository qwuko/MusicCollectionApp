using System;

public class MusicTrack
{
    public string Artist { get; set; }
    public string Title { get; set; }
    public string Genre { get; set; }
    public int Year { get; set; }

    public MusicTrack(string artist, string title, string genre, int year)
    {
        if (string.IsNullOrWhiteSpace(artist))
        {
            throw new ArgumentException("Исполнитель не может быть пустым");
        }

        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException("Название трека не может быть пустым");
        }

        if (string.IsNullOrWhiteSpace(genre))
        {
            throw new ArgumentException("Жанр трека не может быть пустым");
        }

        if (year < 1800 || year > DateTime.Now.Year)
        {
            throw new ArgumentException($"Год должен быть между 1800 и {DateTime.Now.Year}");
        }

        Artist = artist;
        Title = title;
        Genre = genre;
        Year = year;
    }

    public override string ToString()
    {
        return $"{Artist} - {Title} ({Year}) [{Genre}]";
    }
}