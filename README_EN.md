
# Azure Text to Speech

## Description

`AzureTextToSpeech` is a command-line tool written in C# that leverages Azure Cognitive Services to convert text into speech. It can process individual text files or entire folders, generating `.wav` audio files for each input.

## Features

- **Single file processing:** Converts a `.txt` file into a `.wav` audio file.
- **Batch processing:** Converts all text files within a folder into audio files.
- **Support for multiple voices and languages:** Configurable via the `appsettings.json` file.
- **Command-line arguments:** Easy to use from the terminal with options for file and folder processing.

## Requirements

- .NET 6.0 or later
- An Azure account with the Cognitive Services Speech resource configured.
- Azure Speech Key and Region.

## Usage

1. **Clone the repository:**
   
   ```bash
   git clone https://github.com/your-username/azure-text-to-speech.git
   cd azure-text-to-speech
   ```

2. **Configure the project:**
   
   - Edit the `appsettings.json` file and add your Azure Speech `SpeechKey` and `SpeechRegion`.
   - Optionally, set the desired voice under `Voice`.

3. **Build and run the application:**

   - To synthesize a single text file:

     ```bash
     azuretts -t .\TextFiles\sample.txt
     ```

   - To synthesize all text files within a folder:

     ```bash
     azuretts -f .\TextFiles
     ```

## Configuration

Make sure to configure the `appsettings.json` file with the following structure:

```json
{
    "SpeechKey": "YOUR_AZURE_SPEECH_KEY",
    "SpeechRegion": "YOUR_AZURE_REGION",
    "Voice": "en-US-AriaNeural"
}
```

## Contributions

If you want to contribute, please open a pull request or report an issue in the repository.

## License

This project is licensed under the [MIT License](LICENSE).
