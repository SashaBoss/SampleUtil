namespace SampleUtil.Processors
{
    using System.Linq;

    public class Reversed1Processor : IActionProcessor
    {
        public string ProcessFile(string filePath)
        {
            var pathComponents = filePath.Split('\\');

            return string.Join("\\", pathComponents.Reverse());
        }
    }
}