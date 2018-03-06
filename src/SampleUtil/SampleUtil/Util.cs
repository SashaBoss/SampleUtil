namespace SampleUtil
{
    using System;
    using System.IO;
    using Processors;

    public class Util
    {
        private UtilArguments _arguments;
        private IActionProcessor _processor;

        public void Run(string[] commandLineArgs)
        {
            _arguments = new UtilArguments(commandLineArgs);
            _processor = ServiceLocator.Instance.GetService<IActionProcessor>(_arguments.ActionName);
            ProcessFiles(_arguments.BaseFolerPath);
        }

        private void ProcessFiles(string directory)
        {

            if (!Directory.Exists(directory))
            {
                throw new ArgumentException();
            }

            foreach (var file in Directory.GetFiles(directory))
            {
                var processedPath = _processor.ProcessFile(file);

                if (!string.IsNullOrEmpty(processedPath))
                {
                    WriteToResultFile(processedPath);
                }
            }

            foreach (var d in Directory.GetDirectories(directory))
            {
                ProcessFiles(d);
            }
        }

        private void WriteToResultFile(string processedPath)
        {
            using (var writer = new StreamWriter(_arguments.ResultFilePath, true))
            {
                writer.WriteLineAsync(processedPath);
            }
        }
    }
}