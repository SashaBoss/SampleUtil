using System;
using System.Linq;

namespace SampleUtil
{
    public class UtilArguments
    {
        private const int BaseFolderPathIndex = 0;
        private const int ActionNameIndex = 1;
        private const int ResultFilePathIndex = 2;
        private const string DefaultResultFilePath = "results.txt";

        public string BaseFolerPath { get; }
        public ActionType ActionType { get; }
        public string ResultFilePath { get; }

        public UtilArguments(string[] commandLineArgs)
        {
            BaseFolerPath = commandLineArgs[BaseFolderPathIndex];
            ActionType = ParseActionTypeName(commandLineArgs[ActionNameIndex]);
            ResultFilePath = ResultFilePathIndex < commandLineArgs.Length ?
                commandLineArgs[ResultFilePathIndex] : DefaultResultFilePath;
        }

        private ActionType ParseActionTypeName(string actionTypeName)
        {
            switch (actionTypeName)
            {
                case "all":
                    return ActionType.All;
                case "cpp":
                    return ActionType.Cpp;
                case "reversed1":
                    return ActionType.Reversed1;
                case "reversed2":
                    return ActionType.Reversed2;
                default:
                    throw new Exception("Not supported command");
            }
        }
    }
}