
# Azure Text to Speech

![Azure Text to Speech CLI](./ai_text_to_speech.png)

# Spanish README
For the Spanish version of this README, please click [here](README_ES.md).

## Description

`AzureTextToSpeech` is a command-line tool written in C# that leverages Azure Cognitive Services to convert text into speech. It can process individual text files or entire folders, generating `.wav` audio files for each input.

## Features

- **Single file processing:** Converts a `.txt` file into a `.wav` audio file.
- **Batch processing:** Converts all text files within a folder into audio files.
- **Support for multiple voices and languages:** Configurable via the `appsettings.json` file.
- **Command-line arguments:** Easy to use from the terminal with options for file and folder processing.

## Installation

### Prerequisites

1. **Create a resource in Azure AI Services**:
   - Go to the [Azure Portal](https://portal.azure.com) and create a **Cognitive Services** resource in your desired region.
   - Once created, note down the **key** and **region** of the service.

2. **Update `appsettings.json`**:
   - Edit the `appsettings.json` file and add your Azure `SpeechKey` and `SpeechRegion`:
   
   ```json
   {
       "SpeechKey": "YOUR_AZURE_SPEECH_KEY",
       "SpeechRegion": "YOUR_AZURE_REGION",
       "Voice": "en-US-AriaNeural"
   }
   ```

3. **Run the installation script**:
   - On **Windows**: Run `install.ps1` with PowerShell:
   
     ```powershell
     .\install.ps1
     ```

   - On **Linux or macOS**: Run `install.sh`:
   
     ```bash
     sudo ./install.sh
     ```

This will create an executable called `tts` on your system, which you can use from any location.

## Usage

- **To synthesize a single text file**:

   ```bash
   tts -t .\TextFiles\sample.txt
   ```

- **To synthesize all text files within a folder**:

   ```bash
   tts -f .\TextFiles
   ```

## Contributions

If you want to contribute, please open a pull request or report an issue in the repository.

## License

This project is licensed under the [MIT License](LICENSE).

## Spanish Version

For the Spanish version of this README, click [here](README.md).
