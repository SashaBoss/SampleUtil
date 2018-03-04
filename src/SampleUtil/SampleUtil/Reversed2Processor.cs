namespace SampleUtil
{
    public class Reversed2Processor : IActionProcessor
    {
        public string ProcessFile(string filePath)
        {
            return $"{filePath} processed with {this} action";
        }
    } 
}