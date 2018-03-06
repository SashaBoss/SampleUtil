namespace SampleUtil.Processors
{
    public class AllProcessor : IActionProcessor
    {
        public string ProcessFile(string filePath)
        {
            return filePath;
        }
    }
}