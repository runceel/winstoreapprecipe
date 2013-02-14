using System;
using Windows.Media.Capture;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace PlayMovieSample
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void btnRecord_Click(object sender, RoutedEventArgs e)
        {
            // 動画ファイルをMP4フォーマットで録画する
            var capture = new CameraCaptureUI();
            capture.VideoSettings.Format = CameraCaptureUIVideoFormat.Mp4;
            var file = await capture.CaptureFileAsync(CameraCaptureUIMode.Video);
            if (file != null)
            {
                // ローカルフォルダーに録画したファイルを移動する
                var folder = ApplicationData.Current.LocalFolder;
                var movedFile = await folder.CreateFileAsync("sample.mp4", 
                    CreationCollisionOption.ReplaceExisting);

                await file.MoveAndReplaceAsync(movedFile);
            }
        }

        private void btnPlay1_Click(object sender, RoutedEventArgs e)
        {
            // メディアソースにローカルフォルダーにある動画を指定する(再生する)
            mediaElement.Source = new Uri("ms-appdata:///local/sample.mp4");
        }

        private async void btnPlay2_Click(object sender, RoutedEventArgs e)
        {
            // Uriからファイルを取得して、ストリームを開く
            var file = await StorageFile.GetFileFromApplicationUriAsync(
                new Uri("ms-appdata:///local/sample.mp4"));
            var strm = await file.OpenReadAsync();
            // ストリームを
            mediaElement.SetSource(strm, strm.ContentType);
        }
    }
}
