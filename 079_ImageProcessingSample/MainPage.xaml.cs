using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI;

// usingディレクティブに以下の宣言が必要
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;


namespace ImageProcessingSample
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async Task<WriteableBitmap> LoadTestImageAsync()
        {
            // 後で上書きするので適当なサイズを指定してWriteableBitmapオブジェクトを生成する
            var bitmap = new WriteableBitmap(1, 1);

            //System.IO.Stream
            //Windows.Storage.Streams.IRandomAccessStream
            //bitmap.FromStream(

            // ARGBのバイト配列
            //bitmap.FromByteArray

            // Uriを指定してWriteableBitmapオブジェクトを読み出す
            bitmap = await bitmap.FromContent(new Uri("ms-appx:///Assets/hiyoko.png"));
            return bitmap;
        }

        private async void btnCrop_Click(object sender, RoutedEventArgs e)
        {
            var bitmap = await LoadTestImageAsync();

            // 開始座標(50,50)の位置から60x60の画像を切り抜く
            image.Source = bitmap.Crop(50, 50, 60, 60);
        }

        private async void btnResize_Click(object sender, RoutedEventArgs e)
        {
            var bitmap = await LoadTestImageAsync();

            // 画像を400x400の画像に拡大する
            image.Source = bitmap.Resize(400, 400, WriteableBitmapExtensions.Interpolation.Bilinear);
        }

        private async void btnRotate_Click(object sender, RoutedEventArgs e)
        {
            var bitmap = await LoadTestImageAsync();

            // 画像を180度回転させる
            image.Source = bitmap.Rotate(180);
        }

        private async void btnDraw_Click(object sender, RoutedEventArgs e)
        {
            var bitmap = await LoadTestImageAsync();

            // 画像上にピンク色の塗りつぶしの円を描画する
            bitmap.FillEllipse(30, 30, 100, 100, Colors.Pink);

            // 画像上に青色の線を引く
            bitmap.DrawLine(100, 10, 20, 60, Colors.Blue);

            image.Source = bitmap;
        }





    }
}
