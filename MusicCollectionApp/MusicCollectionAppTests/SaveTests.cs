using System;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;

namespace MusicCollectionAppTests
{
    [TestClass]
    public class SaveTests
    {
        private MusicCollection collection;
        private ListView dummyListView;

        [TestInitialize]
        public void Setup()
        {
            dummyListView = new ListView();
            collection = new MusicCollection(dummyListView);
        }

        // экспорт в CSV
        [TestMethod]
        public void ExportToCsv_FileExists()
        {
            string tempFile = Path.GetTempFileName() + ".csv";
            collection.AddTrack(new MusicTrack("А", "Б", "В", 2000));
            collection.ExportToFile(tempFile);
            Assert.IsTrue(File.Exists(tempFile));
            File.Delete(tempFile);
        }

        // экспорт в PSV
        [TestMethod]
        public void ExportToPsv_FileExists()
        {
            string tempFile = Path.GetTempFileName() + ".psv";
            collection.AddTrack(new MusicTrack("А", "Б", "В", 2000));
            collection.ExportToFile(tempFile);
            Assert.IsTrue(File.Exists(tempFile));
            File.Delete(tempFile);
        }

        // экспорт в TXT
        [TestMethod]
        public void ExportToTxt_FileExists()
        {
            string tempFile = Path.GetTempFileName() + ".txt";
            collection.AddTrack(new MusicTrack("А", "Б", "В", 2000));
            collection.ExportToFile(tempFile);
            Assert.IsTrue(File.Exists(tempFile));
            File.Delete(tempFile);
        }

        // импорт из CSV
        [TestMethod]
        public void ImportFromCsv_RestoresCollection()
        {
            string tempFile = Path.GetTempFileName() + ".csv";
            var originalTracks = new[]
            {
                new MusicTrack("Исполнитель1", "Название1", "Жанр1", 2000),
                new MusicTrack("Исполнитель2", "Название2", "Жанр2", 2010)
            };
            foreach (var t in originalTracks) collection.AddTrack(t);
            collection.ExportToFile(tempFile);

            var newCollection = new MusicCollection(new ListView());
            newCollection.ImportFromFile(tempFile);

            var importedTracks = GetTracksViaReflection(newCollection);
            Assert.AreEqual(2, importedTracks.Count);
            Assert.AreEqual("Исполнитель1", importedTracks[0].Artist);
            Assert.AreEqual(2010, importedTracks[1].Year);
            File.Delete(tempFile);
        }

        // импорт из PSV
        [TestMethod]
        public void ImportFromPsv_RestoresCollection()
        {
            string tempFile = Path.GetTempFileName() + ".psv";
            collection.AddTrack(new MusicTrack("Э", "Ю", "Я", 2020));
            collection.ExportToFile(tempFile);

            var newCollection = new MusicCollection(new ListView());
            newCollection.ImportFromFile(tempFile);

            var imported = GetTracksViaReflection(newCollection);
            Assert.AreEqual(1, imported.Count);
            Assert.AreEqual("Э", imported[0].Artist);
            File.Delete(tempFile);
        }

        // импорт из TXT
        [TestMethod]
        public void ImportFromTxt_RestoresCollection()
        {
            string tempFile = Path.GetTempFileName() + ".txt";
            collection.AddTrack(new MusicTrack("О", "П", "Р", 1999));
            collection.ExportToFile(tempFile);

            var newCollection = new MusicCollection(new ListView());
            newCollection.ImportFromFile(tempFile);

            var imported = GetTracksViaReflection(newCollection);
            Assert.AreEqual(1, imported.Count);
            Assert.AreEqual("О", imported[0].Artist);
            File.Delete(tempFile);
        }

        // экспорт пустой коллекции
        [TestMethod]
        public void ExportEmptyCollection_WritesHeaderOnly()
        {
            string tempFile = Path.GetTempFileName() + ".csv";
            collection.ExportToFile(tempFile);
            var content = File.ReadAllText(tempFile);
            Assert.IsTrue(content.Contains("Artist,Title,Genre,Year"));
            Assert.AreEqual(1, File.ReadAllLines(tempFile).Length);
            File.Delete(tempFile);
        }

        // импорт несуществующего файла
        [TestMethod]
        public void ImportNonExistentFile_ShowsError_NoException()
        {
            try
            {
                collection.ImportFromFile("nonexistent_12345.csv");
            }
            catch
            {
                Assert.Fail("Метод не должен выбрасывать исключение, ошибка обрабатывается внутри.");
            }
        }

        // вызов SaveChanges без предварительного экспорта не изменяет коллекцию
        [TestMethod]
        public void SaveChanges_WithoutExport_CollectionRemainsUnchanged()
        {
            var originalTracks = GetTracksViaReflection(collection).ToList();
            collection.AddTrack(new MusicTrack("Temp", "Temp", "Temp", 2000));
            var afterAddCount = GetTracksViaReflection(collection).Count;
            Assert.AreEqual(originalTracks.Count + 1, afterAddCount);

            collection.SaveChanges();

            var finalTracks = GetTracksViaReflection(collection);
            Assert.AreEqual(afterAddCount, finalTracks.Count, "Количество треков не должно измениться");
            Assert.IsTrue(finalTracks.Any(t => t.Artist == "Temp"), "Добавленный трек должен остаться");
        }

        // сохранение после экспорта обновляет файл
        [TestMethod]
        public void SaveChanges_UpdatesFile()
        {
            string tempFile = Path.GetTempFileName() + ".csv";
            collection.AddTrack(new MusicTrack("Первый", "Трек", "Жанр", 2000));
            collection.ExportToFile(tempFile);

            collection.AddTrack(new MusicTrack("Вторая", "Песня", "Рок", 2025));
            collection.SaveChanges();

            var newCollection = new MusicCollection(new ListView());
            newCollection.ImportFromFile(tempFile);
            var imported = GetTracksViaReflection(newCollection);
            Assert.AreEqual(2, imported.Count);
            Assert.IsTrue(imported.Any(t => t.Title == "Песня"));
            File.Delete(tempFile);
        }

        private System.Collections.Generic.List<MusicTrack> GetTracksViaReflection(MusicCollection col)
        {
            var field = typeof(MusicCollection).GetField("tracks", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            return (System.Collections.Generic.List<MusicTrack>)field.GetValue(col);
        }
    }
}
