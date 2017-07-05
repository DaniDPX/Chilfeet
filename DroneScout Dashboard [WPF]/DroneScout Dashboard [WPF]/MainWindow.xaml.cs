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
        readonly String EndpointHost = "http://192.168.0.112:51042/";
        //readonly String EndpointAPI = "htttp://192.168.0.111:3000/upload";

        //var image = System.Windows.Clipboard.GetImage();
        

        public MainWindow()
        {
            InitializeComponent();

            _mjpeg = new MjpegDecoder();
            _mjpeg.FrameReady += mjpeg_FrameReady;
            _mjpeg.Error += _mjpeg_Error;
        }

        private void StartFeed(object sender, RoutedEventArgs e)
        {
            _mjpeg.ParseStream(new Uri(EndpointHost));
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
           
           // SaveClipboardImageToFile("temp");
        }





        public void PostMultipleFiles(string url, string[] files)
        {
            string boundary = "----------------------------" + DateTime.Now.Ticks.ToString("x");
            System.Net.HttpWebRequest httpWebRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
            httpWebRequest.ContentType = "multipart/form-data; boundary=" + boundary;
            httpWebRequest.Method = "POST";
            httpWebRequest.KeepAlive = true;
            httpWebRequest.Credentials = System.Net.CredentialCache.DefaultCredentials;
            System.IO.Stream memStream = new System.IO.MemoryStream();
            byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");
            string formdataTemplate = "\r\n--" + boundary + "\r\nContent-Disposition:  form-data; name=\"{0}\";\r\n\r\n{1}";
            string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\n Content-Type: application/octet-stream\r\n\r\n";
            memStream.Write(boundarybytes, 0, boundarybytes.Length);
            for (int i = 0; i < files.Length; i++)
            {
                string header = string.Format(headerTemplate, "file" + i, files[i]);
                //string header = string.Format(headerTemplate, "uplTheFile", files[i]);
                byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(header);
                memStream.Write(headerbytes, 0, headerbytes.Length);
                System.IO.FileStream fileStream = new System.IO.FileStream(files[i], System.IO.FileMode.Open, System.IO.FileAccess.Read);
                byte[] buffer = new byte[1024];
                int bytesRead = 0;
                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    memStream.Write(buffer, 0, bytesRead);
                }
                memStream.Write(boundarybytes, 0, boundarybytes.Length);
                fileStream.Close();
            }
            httpWebRequest.ContentLength = memStream.Length;
            System.IO.Stream requestStream = httpWebRequest.GetRequestStream();
            memStream.Position = 0;
            byte[] tempBuffer = new byte[memStream.Length];
            memStream.Read(tempBuffer, 0, tempBuffer.Length);
            memStream.Close();
            requestStream.Write(tempBuffer, 0, tempBuffer.Length);
            requestStream.Close();
            try
            {
                System.Net.WebResponse webResponse = httpWebRequest.GetResponse();
                System.IO.Stream stream = webResponse.GetResponseStream();
                System.IO.StreamReader reader = new System.IO.StreamReader(stream);
                string var = reader.ReadToEnd();

            }
            catch (Exception ex)
            {
                //response.InnerHtml = ex.Message;
            }
            httpWebRequest = null;
        }


        public static void SaveClipboardImageToFile(string filePath)
        {
            
            using (var fileStream = new System.IO.FileStream(filePath, System.IO.FileMode.Create))
            {
                BitmapEncoder encoder = new PngBitmapEncoder();
               // encoder.Frames.Add(BitmapFrame.Create(image));
                encoder.Save(fileStream);
            }
        }

        private void uploaderMethod(object sender, RoutedEventArgs e)
        {
            //PostMultipleFiles(EndpointAPI,["temp.jpg"]);
        }
    }
}
