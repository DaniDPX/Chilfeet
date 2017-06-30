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
using System.Net.Http;
using System.IO;

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





        private static void Upload()
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("User-Agent", "CBS Brightcove API Service");

                using (var content = new MultipartFormDataContent())
                {
                    var path = @"C:\B2BAssetRoot\files\596086\596086.1.mp4";

                    string assetName = System.IO.Path.GetFileName(path);

                    var request = new HTTPBrightCoveRequest()
                    {
                        Method = "create_video",
                        Parameters = new Params()
                        {
                            CreateMultipleRenditions = "true",
                            EncodeTo = EncodeTo.Mp4.ToString().ToUpper(),
                            Token = "x8sLalfXacgn-4CzhTBm7uaCxVAPjvKqTf1oXpwLVYYoCkejZUsYtg..",
                            Video = new Video()
                            {
                                Name = assetName,
                                ReferenceId = Guid.NewGuid().ToString(),
                                ShortDescription = assetName
                            }
                        }
                    };

                    //Content-Disposition: form-data; name="json"
                    var stringContent = new StringContent(JsonConvert.SerializeObject(request));
                    stringContent.Headers.Add("Content-Disposition", "form-data; name=\"json\"");
                    content.Add(stringContent, "json");

                    FileStream fs = File.OpenRead(path);

                    var streamContent = new StreamContent(fs);
                    streamContent.Headers.Add("Content-Type", "application/octet-stream");
                    //Content-Disposition: form-data; name="file"; filename="C:\B2BAssetRoot\files\596090\596090.1.mp4";
                    streamContent.Headers.Add("Content-Disposition", "form-data; name=\"file\"; filename=\"" + Path.GetFileName(path) + "\"");
                    content.Add(streamContent, "file", System.IO.Path.GetFileName(path));

                    //content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");

                    Task<HttpResponseMessage> message = client.PostAsync("http://api.brightcove.com/services/post", content);

                    var input = message.Result.Content.ReadAsStringAsync();
                    Console.WriteLine(input.Result);
                    Console.Read();
                }
            }
        }
    }
}
