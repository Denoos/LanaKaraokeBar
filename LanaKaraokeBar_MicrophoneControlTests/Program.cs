using NAudio.CoreAudioApi;
using NAudio.Wave;
using System;
using System.Linq;
using System.Threading;

class SimpleAudioVisualizer
{
    private WasapiCapture capture;
    private WaveOutEvent outputDevice;
    private BufferedWaveProvider bufferedWaveProvider;
    private const int SampleRate = 44100;
    private const int Channels = 1;
    private readonly object lockObject = new object();
    private float currentVolume = 0;

    public void Start()
    {
        Console.Title = "Простой аудио визуализатор";
        Console.CursorVisible = false;

        try
        {
            // Инициализация захвата звука
            capture = new WasapiCapture();

            // Создаем буферизованный провайдер для воспроизведения
            bufferedWaveProvider = new BufferedWaveProvider(capture.WaveFormat)
            {
                DiscardOnBufferOverflow = true
            };

            // Инициализация устройства вывода
            outputDevice = new WaveOutEvent();
            outputDevice.Init(bufferedWaveProvider);

            // Подписываемся на событие получения данных
            capture.DataAvailable += Capture_DataAvailable;

            // Запускаем визуализацию в отдельном потоке
            var visualizationThread = new Thread(VisualizationLoop)
            {
                IsBackground = true
            };
            visualizationThread.Start();

            // Запускаем захват и воспроизведение
            capture.StartRecording();
            outputDevice.Play();

            Console.WriteLine("Визуализатор запущен. Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
        finally
        {
            Stop();
        }
    }

    private void Capture_DataAvailable(object sender, WaveInEventArgs e)
    {
        // Добавляем данные в буфер для воспроизведения
        bufferedWaveProvider.AddSamples(e.Buffer, 0, e.BytesRecorded);

        // Рассчитываем уровень громкости
        float max = 0;
        for (int i = 0; i < e.BytesRecorded; i += 2)
        {
            short sample = BitConverter.ToInt16(e.Buffer, i);
            float sample32 = sample / 32768f;
            if (sample32 < 0) sample32 = -sample32;
            if (sample32 > max) max = sample32;
        }

        lock (lockObject)
        {
            currentVolume = max;
        }
    }

    private void VisualizationLoop()
    {
        while (true)
        {
            Thread.Sleep(50); // Ограничиваем частоту обновления

            float volume;
            lock (lockObject)
            {
                volume = currentVolume;
            }

            // Очищаем консоль
            Console.Clear();

            // Вычисляем высоту полосы (от 0 до 20)
            int height = (int)(volume * 20);

            // Рисуем вертикальную полосу
            for (int i = 0; i < 20; i++)
            {
                Console.SetCursorPosition(10, 19 - i);

                if (i < height)
                {
                    // Выбираем цвет в зависимости от высоты
                    if (i < 7)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else if (i < 14)
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    else
                        Console.ForegroundColor = ConsoleColor.Red;

                    Console.Write("█");
                }
                else
                {
                    Console.Write(" ");
                }
            }

            // Выводим информацию о громкости
            Console.SetCursorPosition(0, 21);
            Console.ResetColor();
            Console.WriteLine($"Громкость: {volume * 100:0.0}%");

            // Рисуем горизонтальную шкалу
            Console.SetCursorPosition(0, 22);
            Console.Write("0%");
            Console.SetCursorPosition(18, 22);
            Console.Write("100%");
        }
    }

    public void Stop()
    {
        capture?.StopRecording();
        outputDevice?.Stop();
        capture?.Dispose();
        outputDevice?.Dispose();
        Console.CursorVisible = true;
        Console.ResetColor();
        Console.Clear();
    }

    static void Main(string[] args)
    {
        var visualizer = new SimpleAudioVisualizer();
        visualizer.Start();
    }
}