namespace SampleUtil.Processors
{
    using System.Linq;
    using System;

    public class Reversed2Processor : IActionProcessor
    {
        public string ProcessFile(string filePath)
        {
            var pathComponents = filePath.Split('\\');
            var reversedComponents = pathComponents.Select(ReverseString).ToList();
            reversedComponents.Reverse();

            return string.Join("\\", reversedComponents);
        }

        private static string ReverseString(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    } 
}