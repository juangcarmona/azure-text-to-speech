
# Azure Text to Speech

## English Version

For the English version of this README, please click [here](README_en.md).

## Descripción

`AzureTextToSpeech` es una herramienta de línea de comandos escrita en C# que utiliza el servicio Azure Cognitive Services para sintetizar voz a partir de texto. Puedes procesar archivos de texto individuales o carpetas completas, generando archivos de audio en formato `.wav` para cada entrada.

## Características

- **Procesamiento de archivos individuales:** Convierte un archivo `.txt` en un archivo de audio `.wav`.
- **Procesamiento por lotes:** Convierte todos los archivos de texto dentro de una carpeta en archivos de audio.
- **Soporte para múltiples voces e idiomas:** Configurable a través del archivo `appsettings.json`.
- **Argumentos de línea de comandos:** Fácil de usar desde la terminal con opciones para archivo y carpeta.

## Requisitos

- .NET 6.0 o superior
- Una cuenta de Azure con el servicio Cognitive Services configurado.
- Clave y región del servicio Azure Speech.

## Uso

1. **Clonar el repositorio:**
   
   ```bash
   git clone https://github.com/tu-usuario/azure-text-to-speech.git
   cd azure-text-to-speech
   ```

2. **Configurar el proyecto:**
   
   - Edita el archivo `appsettings.json` y añade tu clave (`SpeechKey`) y región (`SpeechRegion`) de Azure Speech.
   - Opcionalmente, configura la voz deseada en `Voice`.

3. **Compilar y ejecutar:**
   
   - Para sintetizar un archivo de texto individual:

     ```bash
     azuretts -t .\TextFiles\sample.txt
     ```

   - Para sintetizar todos los archivos de una carpeta:

     ```bash
     azuretts -f .\TextFiles
     ```

## Configuración

Asegúrate de tener configurado el archivo `appsettings.json` con la siguiente estructura:

```json
{
    "SpeechKey": "YOUR_AZURE_SPEECH_KEY",
    "SpeechRegion": "YOUR_AZURE_REGION",
    "Voice": "en-US-AriaNeural"
}
```

## Contribuciones

Si deseas contribuir, por favor abre un pull request o reporta un issue en el repositorio.

## Licencia

Este proyecto está licenciado bajo la [Licencia MIT](LICENSE).
