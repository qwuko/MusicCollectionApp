using System;
using System.Windows.Forms;

namespace MusicCollectionApp
{
    public partial class SearchArtistForm : Form
    {
        public string Artist { get; set; }

        public SearchArtistForm()
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
            Artist = artistTextBox.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}