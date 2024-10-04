using Microsoft.CognitiveServices.Speech;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.IO;

public class TextToSpeechService
{
    private readonly SpeechConfig _speechConfig;
    private readonly ILogger<TextToSpeechService> _logger;

    public TextToSpeechService(IConfiguration configuration, ILogger<TextToSpeechService> logger)
    {
        var subscriptionKey = configuration["SpeechKey"];
        var serviceRegion = configuration["SpeechRegion"];
        var voice = configuration["Voice"];

        _speechConfig = SpeechConfig.FromSubscription(subscriptionKey, serviceRegion);
        _speechConfig.SpeechSynthesisVoiceName = voice;
        _logger = logger;
    }

    public async Task SynthesizeSpeechAsync(string text, string outputFilePath)
    {
        try
        {
            _logger.LogInformation($"Synthesizing text to speech: {text}");

            using var synthesizer = new SpeechSynthesizer(_speechConfig, null);
            var result = await synthesizer.SpeakTextAsync(text);

            if (result.Reason == ResultReason.SynthesizingAudioCompleted)
            {
                File.WriteAllBytes(outputFilePath, result.AudioData);
                _logger.LogInformation($"Audio saved to {outputFilePath}");
            }
            else if (result.Reason == ResultReason.Canceled)
            {
                var cancellation = SpeechSynthesisCancellationDetails.FromResult(result);
                _logger.LogError($"CANCELED: Reason={cancellation.Reason}");
                _logger.LogError($"ErrorDetails={cancellation.ErrorDetails}");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"An error occurred during speech synthesis: {ex.Message}");
        }
    }

    public async Task SynthesizeSpeechFromFolderAsync(string folderPath)
    {
        try
        {
            var directoryInfo = new DirectoryInfo(folderPath);
            FileInfo[] fileInfos = directoryInfo.GetFiles("*.txt");

            var outputDirectory = Path.Combine(Path.GetDirectoryName(folderPath), "AudioOutput");
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            foreach (var fileInfo in fileInfos)
            {
                _logger.LogInformation($"Processing text file: {fileInfo.FullName}");
                var textContent = await File.ReadAllTextAsync(fileInfo.FullName);
                var outputFilePath = Path.Combine(folderPath, "AudioOutput", $"{Path.GetFileNameWithoutExtension(fileInfo.Name)}.wav");

                await SynthesizeSpeechAsync(textContent, outputFilePath);
            }
        }
        catch (UnauthorizedAccessException ex)
        {
            _logger.LogError($"Access denied to the folder: {folderPath}. Exception: {ex.Message}");
        }
        catch (IOException ex)
        {
            _logger.LogError($"I/O error when accessing the folder: {folderPath}. Exception: {ex.Message}");
        }
        catch (Exception ex)
        {
            _logger.LogError($"An error occurred: {ex.Message}");
        }
    }
}