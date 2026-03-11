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
            if (int.TryParse(yearTextBox.Text, out int year))
            {
                Artist = artistTextBox.Text;
                Title = titleTextBox.Text;
                Genre = genreTextBox.Text;
                Year = year;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите корректный год.");
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}