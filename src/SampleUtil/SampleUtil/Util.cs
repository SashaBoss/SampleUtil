namespace SampleUtil
{
    using System;
    using System.Threading.Tasks;
    using System.IO;
    using Processors;

    public class Util
    {
        private UtilArguments _arguments;
        private IActionProcessor _processor;

        public async void Run(string[] commandLineArgs)
        {
            _arguments = new UtilArguments(commandLineArgs);
            _processor = ServiceLocator.Instance.GetService<IActionProcessor>(_arguments.ActionName);
            await ProcessFiles(_arguments.BaseFolerPath);
        }

        private Task ProcessFiles(string directory)
        {
            return Task.Run(async () =>
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
                        await WriteToResultFile(processedPath);
                    }
                }

                foreach (var d in Directory.GetDirectories(directory))
                {
                    await ProcessFiles(d);
                }
            });
        }

        private async Task WriteToResultFile(string processedPath)
        {
            using (var writer = new StreamWriter(_arguments.ResultFilePath, true))
            {
                await writer.WriteLineAsync(processedPath);
            }
        }
    }
}