using System.Collections.Generic;
using CustomMultipartFormDataStreamProvider.FileColumnsFormatter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessLayerTest.FileColumnsFormatterTest
{
    [TestClass]
    public class FileColumnsFormatterTest
    {
        private FileColumnsFormatter _fileColumnsFormatter;

        [TestInitialize]
        public void SetUp()
        {
            _fileColumnsFormatter = new FileColumnsFormatter();
        }

        [TestMethod]
        public void ColumnIndexesReader_WithValuesCall_ReturnDictionary()
        {
            var initialValues = new []{ "TestValue1", "AnotherTestValue", "Eye more values", "Last value" };

            var expectedResultsDictionary = new Dictionary<string, int>
            {
                {initialValues[0], 0},
                {initialValues[1], 1},
                {initialValues[2], 2},
                {initialValues[3], 3}
            };

            var results = _fileColumnsFormatter.ReadColumnIndexes(initialValues);

            Assert.IsNotNull(results);
            Assert.AreEqual(expectedResultsDictionary[initialValues[0]], results[initialValues[0]]);
            Assert.AreEqual(expectedResultsDictionary[initialValues[3]], results[initialValues[3]]);
        }

        [TestMethod]
        public void ColumnIndexesReader_NullCall_ReturnEmpty()
        {
            string[] initialValues = null;

            var results = _fileColumnsFormatter.ReadColumnIndexes(initialValues);

            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        public void ColumnIndexesReader_EmptyCall_ReturnEmpty()
        {
            string[] initialValues = new string[0];

            var results = _fileColumnsFormatter.ReadColumnIndexes(initialValues);

            Assert.AreEqual(0, results.Count);
        }
    }
}
