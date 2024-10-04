
# Azure Text to Speech

## Descripción

`AzureTextToSpeech` es una herramienta de línea de comandos escrita en C# que utiliza el servicio Azure Cognitive Services para sintetizar voz a partir de texto. Puedes procesar archivos de texto individuales o carpetas completas, generando archivos de audio en formato `.wav` para cada entrada.

## Características

- **Procesamiento de archivos individuales:** Convierte un archivo `.txt` en un archivo de audio `.wav`.
- **Procesamiento por lotes:** Convierte todos los archivos de texto dentro de una carpeta en archivos de audio.
- **Soporte para múltiples voces e idiomas:** Configurable a través del archivo `appsettings.json`.
- **Argumentos de línea de comandos:** Fácil de usar desde la terminal con opciones para archivo y carpeta.

## Instalación

### Requisitos previos

1. **Configurar un recurso en Azure AI Services**:
   - Accede a [Azure Portal](https://portal.azure.com) y crea un recurso de **Cognitive Services** en la región que prefieras.
   - Una vez creado, anota la **clave (key)** y la **región** del servicio.

2. **Actualizar `appsettings.json`**:
   - Edita el archivo `appsettings.json` y añade tu clave (`SpeechKey`) y la región (`SpeechRegion`):
   
   ```json
   {
       "SpeechKey": "TU_CLAVE_DE_AZURE",
       "SpeechRegion": "TU_REGION_DE_AZURE",
       "Voice": "es-ES-AlvaroNeural"
   }
   ```

3. **Ejecutar el script de instalación**:
   - En **Windows**: Ejecuta `install.ps1` con PowerShell:
   
     ```powershell
     .\install.ps1
     ```

   - En **Linux o macOS**: Ejecuta `install.sh`:
   
     ```bash
     sudo ./install.sh
     ```

Esto creará un ejecutable llamado `tts` en tu sistema, que podrás usar desde cualquier ubicación.

## Uso

- **Para sintetizar un archivo de texto individual**:

   ```bash
   tts -t .\TextFiles\sample.txt
   ```

- **Para sintetizar todos los archivos de texto dentro de una carpeta**:

   ```bash
   tts -f .\TextFiles
   ```

## Contribuciones

Si deseas contribuir, por favor abre un pull request o reporta un issue en el repositorio.

## Licencia

Este proyecto está licenciado bajo la [Licencia MIT](LICENSE).

## Versión en Inglés

Para la versión en inglés de este README, haz clic [aquí](README_EN.md).
