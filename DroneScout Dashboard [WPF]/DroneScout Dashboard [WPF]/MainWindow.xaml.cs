using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CodeX_MJPEG_Decoder;

namespace DroneScout_Dashboard__WPF_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        readonly MjpegDecoder _mjpeg;

        public MainWindow()
        {
            InitializeComponent();

            _mjpeg = new MjpegDecoder();
            _mjpeg.FrameReady += mjpeg_FrameReady;
            _mjpeg.Error += _mjpeg_Error;
        }

        private void StartFeed(object sender, RoutedEventArgs e)
        {
            _mjpeg.ParseStream(new Uri("http://192.168.137.182:51042/"));
        }

        private void mjpeg_FrameReady(object sender, FrameReadyEventArgs e)
        {
            image.Source = e.BitmapImage;
        }

        void _mjpeg_Error(object sender, ErrorEventArgs e)
        {
            System.Windows.MessageBox.Show(e.Message);
        }

        private void TakeShot(object sender, RoutedEventArgs e)
        {
            CameraPreviewImage.Source = image.Source;
        }

       



    }
}
