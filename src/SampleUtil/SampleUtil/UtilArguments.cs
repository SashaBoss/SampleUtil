namespace SampleUtil
{
    public class UtilArguments
    {
        private const int BaseFolderPathIndex = 0;
        private const int ActionNameIndex = 1;
        private const int ResultFilePathIndex = 2;
        private const string DefaultResultFilePath = "results.txt";

        public string BaseFolerPath { get; }
        public string ActionName { get; }
        public string ResultFilePath { get; }

        public UtilArguments(string[] commandLineArgs)
        {
            BaseFolerPath = commandLineArgs[BaseFolderPathIndex];
            ActionName = commandLineArgs[ActionNameIndex];
            ResultFilePath = ResultFilePathIndex < commandLineArgs.Length ?
                commandLineArgs[ResultFilePathIndex] : DefaultResultFilePath;
        }
    }
}