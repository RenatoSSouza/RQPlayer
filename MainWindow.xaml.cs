using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using Microsoft.Win32;
using System.Windows.Threading;

namespace RQPlayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            mediaElementVideo.LoadedBehavior = MediaState.Manual;
            sliderVolume.Value = 50;
            mediaElementVideo.Volume = sliderVolume.Value / 100;
            
        }

        private void sliderVolume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            mediaElementVideo.Volume = sliderVolume.Value / 100;
            labelVolume.Content = ((int)sliderVolume.Value).ToString() + "%";
        }

        private void buttonPlay_Click(object sender, RoutedEventArgs e)
        {
            mediaElementVideo.Play();

        }

        private void buttonPause_Click(object sender, RoutedEventArgs e)
        {
            mediaElementVideo.Pause();
        }

        private void buttonStop_Click(object sender, RoutedEventArgs e)
        {
            mediaElementVideo.Stop();
        }

        private void buttonOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = "c:\\";
            ofd.Filter = "Todos os arquivos de vídeo|*.mp4;*.avi;*.wmv;*.mov;*.mkv;*.flv;*.webm|Todos os arquivos|*.*";
        
            if (ofd.ShowDialog() == true)
            {
                mediaElementVideo.Source = new Uri(ofd.FileName);
                mediaElementVideo.GetType();
                mediaElementVideo.Play();
                SetDurationLabels();
            }

        }
        private void SetDurationLabels()
        {
            Duration duration = mediaElementVideo.NaturalDuration;
            if (duration.HasTimeSpan)
            {
                TimeSpan timeSpan = duration.TimeSpan;
                int totalSeconds = (int)timeSpan.TotalSeconds;
                // Set slider maximum to total number of seconds in the video
                sliderLenghtVideo.Maximum = totalSeconds;

                // Convert seconds to hours, minutes, and seconds
                int hours = totalSeconds / 3600;
                int minutes = (totalSeconds % 3600) / 60;
                int seconds = totalSeconds % 60;

                // Set labels to display the duration in hours, minutes, and seconds
                labelDurationTimer.Content = $"{hours}:{minutes}:{seconds}";
                
                
            } 
        }

        
    }
}
