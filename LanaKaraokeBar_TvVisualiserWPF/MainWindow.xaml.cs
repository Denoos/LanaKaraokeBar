using NAudio.Wave;
using NAudio.WaveFormRenderer;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LanaKaraokeBar_TvVisualiserWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static string audioFilePath = @"C:\Users\Denoos\Music\LanaKaraokeBar\Neveroyatnyj_priklyucheniya_DzhoDzho_-_Opening_2_(SkySound.cc).mp3";

        private AudioFileReader audioFile;
        private WaveOutEvent music;
        private StandardWaveFormRendererSettings rendererSettings;
        private WaveFormRenderer waveFormRenderer;
        private MaxPeakProvider peakProvider;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            audioFile = new(audioFilePath);
            music = new();

            music.Init(audioFile);
        }

        private void PlayButtonClicked(object sender, RoutedEventArgs e)
        {
            music.Play();

            RenderImage();
        }

        private void RenderImage()
        {
            waveFormRenderer = new();
            peakProvider = new();
            rendererSettings = new()
            {
                Width = 640,
                TopHeight = 64,
                BottomHeight = 64
            };

            var result = new BitmapImage();

            using (MemoryStream memory = new())
            {
                var image = waveFormRenderer.Render(new AudioFileReader(audioFilePath), peakProvider, rendererSettings);
                image.Save(memory, ImageFormat.Png);

                result.BeginInit();
                result.CacheOption = BitmapCacheOption.OnLoad;
                result.StreamSource = memory;
                result.EndInit();
            }

            VisImg.Source = result;
        }

        private void PauseButtonClicked(object sender, RoutedEventArgs e)
        {
            music.Pause();
        }

        private void RewindButtonClicked(object sender, RoutedEventArgs e)
        {
            audioFile.Position = 0;
        }

        private void StopButtonClicked(object sender, RoutedEventArgs e)
        {
            music.Stop();
            audioFile.Position = 0;
        }

        private void ChineseRenderEdition()
        {
            WasapiLoopbackCapture cap = new();
            cap.DataAvailable += (sender, e) =>
            {
                float[] allSamples = Enumerable
                .Range(0, e.BytesRecorded / 4)
                .Select(i => BitConverter.ToSingle(e.Buffer, i * 4))
                .ToArray();
            };
            cap.StartRecording();
        }
    }
}