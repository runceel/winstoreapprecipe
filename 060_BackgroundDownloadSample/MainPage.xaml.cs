using System;
using Windows.Networking.BackgroundTransfer;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace BackgroundDownloadSample
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        // ダウンロード中の進捗率更新の通知を受け取る
        private void NotificationProgress(DownloadOperation obj)
        {
            double progress = ((double)obj.Progress.BytesReceived / obj.Progress.TotalBytesToReceive);
            System.Diagnostics.Debug.WriteLine("{0}%", progress * 100);
        }

        // 非同期ダウンロードする
        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // ダウンロードしたファイルの保存先を指定する
            var uri = new Uri("http://download.thinkbroadband.com/100MB.zip");
//            var uri = new Uri("{バックグランドでダウンロードするファイルのURL}");

            var file = await Windows.Storage.ApplicationData.Current.LocalFolder.CreateFileAsync("example.zip", 
                Windows.Storage.CreationCollisionOption.ReplaceExisting);

            // バックグランドで非同期ダウンロードする
            var downloader = new Windows.Networking.BackgroundTransfer.BackgroundDownloader();
            DownloadOperation downloadOperation = downloader.CreateDownload(uri, file);
            var progress = new Progress<DownloadOperation>(NotificationProgress);
            await downloadOperation.StartAsync().AsTask(progress);
        }
    }
}
