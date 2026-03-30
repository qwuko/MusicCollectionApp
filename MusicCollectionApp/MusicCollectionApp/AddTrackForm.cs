using System;
using System.Windows.Forms;

namespace MusicCollectionApp
{
    public partial class AddTrackForm : Form
    {
        public string Artist { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }

        public AddTrackForm()
        {
            InitializeComponent();
            AttachEvents();
        }

        private void AttachEvents()
        {
            okButton.Click += OkButton_Click;
            cancelButton.Click += CancelButton_Click;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(yearTextBox.Text, out int year))
            {
                MessageBox.Show("Пожалуйста, введите корректный год.",
                    "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string artist = artistTextBox.Text;
            string title = titleTextBox.Text;
            string genre = genreTextBox.Text;

            try
            {
                var track = new MusicTrack(artist, title, genre, year);

                Artist = artist;
                Title = title;
                Genre = genre;
                Year = year;
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка ввода данных",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}