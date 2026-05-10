using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicCollectionApp;

namespace MusicCollectionAppTests
{
    [TestClass]
    public class MusicTrackTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void YearLessThan1900_IsAllowed()
        {
            int year = 1799;
            var track = new MusicTrack("Artist", "Title", "Genre", year);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void YearGreaterThanCurrent_IsAllowed()
        {
            int year = DateTime.Now.Year + 1;
            var track = new MusicTrack("Artist", "Title", "Genre", year);
        }

        [TestMethod]
        public void Year1900_IsAllowed()
        {
            int year = 1800;
            var track = new MusicTrack("Artist", "Title", "Genre", year);
            Assert.AreEqual(year, track.Year);
        }

        [TestMethod]
        public void YearCurrent_IsAllowed()
        {
            int year = DateTime.Now.Year;
            var track = new MusicTrack("Artist", "Title", "Genre", year);
            Assert.AreEqual(year, track.Year);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EmptyArtist_IsAllowed()
        {
            string artist = "";
            var track = new MusicTrack(artist, "Title", "Genre", 2020);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void WhitespaceArtist_IsAllowed()
        {
            string artist = "   ";
            var track = new MusicTrack(artist, "Title", "Genre", 2020);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EmptyTitle_IsAllowed()
        {
            string title = "";
            var track = new MusicTrack("Artist", title, "Genre", 2020);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void WhitespaceTitle_IsAllowed()
        {
            string title = "   ";
            var track = new MusicTrack("Artist", title, "Genre", 2020);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NegativeYear_IsAllowed()
        {
            int year = -100;
            var track = new MusicTrack("Artist", "Title", "Genre", year);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void YearZero_IsAllowed()
        {
            int year = 0;
            var track = new MusicTrack("Artist", "Title", "Genre", year);
        }

        [TestMethod]
        public void Constructor_ValidData_CreatesTrack()
        {
            string artist = "Artist";
            string title = "Title";
            string genre = "Genre";
            int year = 2020;

            var track = new MusicTrack(artist, title, genre, year);

            Assert.AreEqual(artist, track.Artist);
            Assert.AreEqual(title, track.Title);
            Assert.AreEqual(genre, track.Genre);
            Assert.AreEqual(year, track.Year);
        }
    }
}