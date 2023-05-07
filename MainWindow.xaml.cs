using System;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
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
            ofd.Filter = "Arquivos MP4| *.mp4";
            if(ofd.ShowDialog() == true)
            {
                mediaElementVideo.Source = new Uri(ofd.FileName);
                mediaElementVideo.Play();
            }
        }
    }
}
