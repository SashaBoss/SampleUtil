namespace SampleUtil.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class UtilTests
    {
        [TestMethod]
        public void Process_ValidArgs_FilesProcessed()
        {
            string basePath = @"E:\SampleUtilTestFolder";
            string actionName = "reversed2";
            string resultFolderPath = @"E:\output.txt";
            string[] args = { basePath, actionName, resultFolderPath };

            new Util().Run(args);
        }
    }
}