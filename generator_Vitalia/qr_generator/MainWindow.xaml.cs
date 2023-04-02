using System.Windows;
using System.Drawing;
using System.Windows.Media.Imaging;
using System.IO;
using QRCoder;

namespace generator_Vitalia
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnQrCodeGenerator_Click(object sender, RoutedEventArgs e)
        {
            QRCodeGenerator qr = new QRCodeGenerator();
            QRCodeData data = qr.CreateQrCode(txtQrCode.Text, QRCoder.QRCodeGenerator.ECCLevel.L);
            QRCode code = new QRCode(data);
            Bitmap bitmap = code.GetGraphic(100);
            using(MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();
                qrImageView.Source = bitmapimage;
             }
        }
    }
}
