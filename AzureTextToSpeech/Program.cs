using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

class Program
{
    static async Task Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: azuretts -t <text_file_path> | -f <folder_path>");
            return;
        }

        var option = args[0];
        var path = args[1];

        var exeDirectory = AppContext.BaseDirectory;
        var appSettingsPath = Path.Combine(exeDirectory, "appsettings.json");

        // Set up configuration
        var builder = new ConfigurationBuilder()
            .SetBasePath(exeDirectory)
            .AddJsonFile(appSettingsPath, optional: false, reloadOnChange: true);

        IConfiguration configuration = builder.Build();

        // Set up dependency injection
        var serviceProvider = new ServiceCollection()
            .AddLogging(configure =>
            {
                configure.AddSimpleConsole(options =>
                {
                    options.SingleLine = true;
                    options.TimestampFormat = "hh:mm:ss ";
                    options.IncludeScopes = false;
                }).SetMinimumLevel(LogLevel.Information);
            })
            .AddSingleton(configuration)
            .AddSingleton<TextToSpeechService>()
            .BuildServiceProvider();

        var ttsService = serviceProvider.GetService<TextToSpeechService>();

        if (option == "-t" || option == "--text")
        {
            if (!File.Exists(path))
            {
                Console.WriteLine($"The file {path} does not exist.");
                return;
            }

            var textContent = await File.ReadAllTextAsync(path);
            var outputFilePath = Path.Combine(Path.GetDirectoryName(path), $"{Path.GetFileNameWithoutExtension(path)}.wav");

            await ttsService.SynthesizeSpeechAsync(textContent, outputFilePath);
        }
        else if (option == "-f" || option == "--folder")
        {
            if (!Directory.Exists(path))
            {
                Console.WriteLine($"The folder {path} does not exist.");
                return;
            }

            await ttsService.SynthesizeSpeechFromFolderAsync(path);
        }
        else
        {
            Console.WriteLine("Invalid option. Use -t for text file or -f for folder.");
        }
    }
}
