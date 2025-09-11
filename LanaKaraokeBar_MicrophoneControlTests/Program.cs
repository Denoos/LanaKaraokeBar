using NAudio.CoreAudioApi;
using NAudio.Wave;

namespace LanaKaraokeBar_MicrophoneControlTests
{
    public class Program()
    {
        private static WasapiCapture capture;
        private static BufferedWaveProvider bufferedWaveProvider;
        private static WaveOutEvent outputDevice;

        public static void StartMonitoring()
        {
            // Инициализация захвата с микрофона
            capture = new WasapiCapture();

            // Создаем буферизованный провайдер волн с таким же форматом, как у захвата
            bufferedWaveProvider = new BufferedWaveProvider(capture.WaveFormat);
            bufferedWaveProvider.DiscardOnBufferOverflow = true; // Важно для реального времени

            // Инициализация устройства вывода
            outputDevice = new WaveOutEvent();
            outputDevice.Init(bufferedWaveProvider);

            // Подписываемся на событие получения данных с микрофона
            capture.DataAvailable += Capture_DataAvailable;

            // Запускаем захват и воспроизведение
            capture.StartRecording();
            outputDevice.Play();

            Console.WriteLine("Мониторинг запущен. Нажмите Enter для остановки...");
            Console.ReadLine();

            //Отписываемся от события(важно это не забыть(и да, это писал не DeepSeek))
            capture.DataAvailable -= Capture_DataAvailable;

            // Остановка и очистка
            StopMonitoring();
        }

        private static void Capture_DataAvailable(object sender, WaveInEventArgs e)
        {
            // Добавляем данные в буфер для воспроизведения
            bufferedWaveProvider.AddSamples(e.Buffer, 0, e.BytesRecorded);
        }

        public static void StopMonitoring()
        {
            capture?.StopRecording();
            outputDevice?.Stop();
            capture?.Dispose();
            outputDevice?.Dispose();
        }

        static void Main(string[] args)
        {
            StartMonitoring();
        }
    }
}