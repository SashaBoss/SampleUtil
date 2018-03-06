namespace SampleUtil.Processors
{
    using System.IO;

    public class CppProcessor : IActionProcessor
    {
        private const string CppExtension = ".cpp";

        public string ProcessFile(string filePath)
        {
            var extension = Path.GetExtension(filePath);

            if (extension != null && extension.Equals(CppExtension))
            {
                filePath += "/";
                return filePath;
            } 

            return string.Empty;
        }
    }
}