namespace SampleUtil.Tests
{
    using Unity.Exceptions;
    using Processors;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class UtilTests
    {
        [TestMethod]
        public void CppProsesorProcessFile_CppFileGiven_ReturnsPathWithSlash()
        {
            // Arrange 
            var path = @"E:\test.cpp";
            var expectedResult = @"E:\test.cpp/";
            var processor = new CppProcessor();

            // Act
            var actualResult = processor.ProcessFile(path);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void CppProsesorProcessFile_TxtFileGiven_ReturnsEmptyString()
        {
            // Arrange 
            var path = @"E:\test.txt";
            var expectedResult = string.Empty;
            var processor = new CppProcessor();

            // Act
            var actualResult = processor.ProcessFile(path);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Reversed1ProcessorProcessFile_TxtFileGiven_ReturnsReversedPath()
        {
            // Arrange 
            var path = @"E:\test.txt";
            var expectedResult = @"test.txt\E:";
            var processor = new Reversed1Processor();

            // Act
            var actualResult = processor.ProcessFile(path);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Reversed2ProcessorProcessFile_TxtFileGiven_ReturnsReversedPathWithReversedPathComponents()
        {
            // Arrange 
            var path = @"E:\test.txt";
            var expectedResult = @"test.txt\E:";
            var processor = new Reversed1Processor();

            // Act
            var actualResult = processor.ProcessFile(path);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void ServiceLocatorGetService_ValidActionNames_ReturnsConcreteProcessors()
        {
            // Arrange 
            var expectedResult = typeof(IActionProcessor);

            // Act
            var allProcessor = ServiceLocator.Instance.GetService<IActionProcessor>("all");
            var cppProcessor = ServiceLocator.Instance.GetService<IActionProcessor>("cpp");
            var reversed1Processor = ServiceLocator.Instance.GetService<IActionProcessor>("reversed1");
            var reversed2Processor = ServiceLocator.Instance.GetService<IActionProcessor>("reversed2");

            // Assert
            Assert.IsInstanceOfType(allProcessor, expectedResult);
            Assert.IsInstanceOfType(cppProcessor, expectedResult);
            Assert.IsInstanceOfType(reversed1Processor, expectedResult);
            Assert.IsInstanceOfType(reversed2Processor, expectedResult);
        }

        [TestMethod]
        [ExpectedException(typeof(ResolutionFailedException))]
        public void ServiceLocatorGetService_InvalidActionName_ThrowsException()
        {
            ServiceLocator.Instance.GetService<IActionProcessor>("invalidName");
        }
    }
}