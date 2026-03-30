using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;

namespace MusicCollectionAppTests
{
    [TestClass]
    public class MusicCollectionTests
    {
        [TestMethod]
        public void Constructor_WhenCalled_CreatesMusicCollection()
        {
            var listView = new ListView();

            var collection = new MusicCollection(listView);

            Assert.IsNotNull(collection);
        }

        [TestMethod]
        public void Constructor_WithDifferentListView_Creates()
        {
            var listView1 = new ListView();
            var listView2 = new ListView();

            var collection1 = new MusicCollection(listView1);
            var collection2 = new MusicCollection(listView2);

            Assert.IsNotNull(collection1);
            Assert.IsNotNull(collection2);
            Assert.AreNotSame(collection1, collection2);
        }

        [TestMethod]
        public void Constructor_MultipleCalls_CreatesDifferent()
        {
            var collection1 = new MusicCollection(new ListView());
            var collection2 = new MusicCollection(new ListView());
            var collection3 = new MusicCollection(new ListView());

            Assert.IsNotNull(collection1);
            Assert.IsNotNull(collection2);
            Assert.IsNotNull(collection3);
            Assert.AreNotSame(collection1, collection2);
            Assert.AreNotSame(collection1, collection3);
            Assert.AreNotSame(collection2, collection3);
        }

        // LoadTracks вызывается при конструкторе и обновляет ListView из пустого списка
        [TestMethod]
        public void LoadTracks_AfterConstructor_ListViewEmpty()
        {
            var listView = new ListView();

            var collection = new MusicCollection(listView);

            Assert.AreEqual(0, listView.Items.Count);
        }

        [TestMethod]
        public void TracksCanAddTrack()
        {
            var tracks = new List<MusicTrack>();
            var track = new MusicTrack("Artist", "Title", "Rock", 2020);

            tracks.Add(track);

            Assert.AreEqual(1, tracks.Count);
            Assert.AreSame(track, tracks[0]);
        }

        [TestMethod]
        public void TracksCanRemoveTrack()
        {
            var tracks = new List<MusicTrack>();
            var track1 = new MusicTrack("Artist1", "Title1", "Rock", 2020);
            var track2 = new MusicTrack("Artist2", "Title2", "Pop", 2021);

            tracks.Add(track1);
            tracks.Add(track2);

            bool result = tracks.Remove(track1);

            Assert.IsTrue(result);
            Assert.AreEqual(1, tracks.Count);
            Assert.AreSame(track2, tracks[0]);
        }

        [TestMethod]
        public void TracksRemoveNonExistentTrackReturnsFalse()
        {
            var tracks = new List<MusicTrack>();
            var track1 = new MusicTrack("Artist1", "Title1", "Rock", 2020);
            var nonExistentTrack = new MusicTrack("Artist3", "Title3", "Jazz", 2019);

            tracks.Add(track1);

            bool result = tracks.Remove(nonExistentTrack);

            Assert.IsFalse(result);
            Assert.AreEqual(1, tracks.Count);
            Assert.AreSame(track1, tracks[0]);
        }

        [TestMethod]
        public void TracksRemoveAtSpecificIndex()
        {
            var tracks = new List<MusicTrack>();
            var track1 = new MusicTrack("Artist1", "Title1", "Rock", 2020);
            var track2 = new MusicTrack("Artist2", "Title2", "Pop", 2021);
            var track3 = new MusicTrack("Artist3", "Title3", "Jazz", 2022);

            tracks.Add(track1);
            tracks.Add(track2);
            tracks.Add(track3);

            tracks.RemoveAt(1);

            Assert.AreEqual(2, tracks.Count);
            Assert.AreSame(track1, tracks[0]);
            Assert.AreSame(track3, tracks[1]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TracksRemoveAtInvalidIndexThrowsException()
        {
            var tracks = new List<MusicTrack>();
            var track = new MusicTrack("Artist", "Title", "Rock", 2020);
            tracks.Add(track);

            tracks.RemoveAt(5);
        }
    }
}
