namespace SampleUtil
{
    using System.IO;

    public class Util
    {
        private UtilArguments _arguments;
        private readonly UtilArgumentsFactory _argumentsFactory;
        private readonly ActionProcessorFactory _processorFactory;
        private IActionProcessor _processor;

        public Util()
        {
            _argumentsFactory = new UtilArgumentsFactory();
            _processorFactory = new ActionProcessorFactory();
        }

        public void Run(string[] commandLineArgs)
        {
            CreateArguments(commandLineArgs);
            SetupProcessor();
            ProcessFiles(_arguments.BaseFolerPath);
        }

        private void SetupProcessor()
        {
            _processor = _processorFactory.GetProcessor(_arguments.ActionType);
        }

        private void ProcessFiles(string directory)
        {
            foreach (var file in Directory.GetFiles(directory))
            {
                var processedPath = _processor.ProcessFile(file);
                WriteToResultFile(processedPath);
            }

            foreach (var d in Directory.GetDirectories(directory))
            {
                ProcessFiles(d);
            }
        }

        private void WriteToResultFile(string processedPath)
        {
            using (var writer = new StreamWriter(_arguments.ResultFilePath))
            {
                writer.WriteLine(processedPath);
            }
        }

        private void CreateArguments(string[] commandLineArgs)
        {
            _arguments = _argumentsFactory.CreateArguments(commandLineArgs);
        }
    }
}