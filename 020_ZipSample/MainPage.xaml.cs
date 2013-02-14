using System;
using System.IO;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace ZipSample
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        // Zipファイルを解凍する
        private async void btnUnzip_Click(object sender, RoutedEventArgs e)
        {
            // ZipファイルへのUriオブジェクトを生成する
            var url = new Uri("ms-appx:///Assets/piyo.zip");

            // アプリケーション パッケージ内に格納されたZIPファイルのストリームを取得する
            var file = await Windows.Storage.StorageFile.GetFileFromApplicationUriAsync(url);

            // ZipファイルのストリームからZipArchiveクラスのオブジェクトを生成する
            using (var randomStrm = await file.OpenReadAsync())            
            using (var strm = randomStrm.AsStream())
            using (var archive = new System.IO.Compression.ZipArchive(strm))
            {
                // Zipファイルに含まれているファイルの一覧を表示する
                foreach (var entry in archive.Entries)
                {
                    System.Diagnostics.Debug.WriteLine(entry.FullName);
                }

                // Zipファイルに含まれているファイルをアプリケーション ローカル フォルダーへ保存する
                foreach (var entry in archive.Entries)
                {
                    // Zipファイルから特定のファイルを解凍して、アプリケーションローカルへ書き出す
                    var fileA = await Windows.Storage.ApplicationData.Current.LocalFolder.CreateFileAsync(entry.FullName);
                    using (var unzipStrm = entry.Open())
                    using (var writer = await fileA.OpenStreamForWriteAsync())
                    {
                        await unzipStrm.CopyToAsync(writer);
                        await writer.FlushAsync();
                    }
                }
            }
        }
    }
}
