namespace SampleUtil
{
    internal class UtilArgumentsFactory
    {
        public UtilArguments CreateArguments(string[] commandLineArgs)
        {
            return new UtilArguments(commandLineArgs);
        }
    }
}