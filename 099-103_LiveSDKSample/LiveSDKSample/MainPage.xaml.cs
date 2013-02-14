using Microsoft.Live;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// 空白ページのアイテム テンプレートについては、http://go.microsoft.com/fwlink/?LinkId=234238 を参照してください

namespace LiveSDKSample
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// このページがフレームに表示されるときに呼び出されます。
        /// </summary>
        /// <param name="e">このページにどのように到達したかを説明するイベント データ。Parameter 
        /// プロパティは、通常、ページを構成するために使用します。</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        // ログイン時のセッション情報を保持する
        LiveConnectSession Session { get; set; }

        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            // 認証用インスタンスを生成
            var authClient = new LiveAuthClient();

            // スコープを設定
            var scopes = new List<string>() { "wl.signin", "wl.skydrive_update" };

            // ログイン用ダイアログを表示する
            var authResult = await authClient.LoginAsync(scopes);
            if (authResult.Status == LiveConnectSessionStatus.Connected)
            {
                Session = authResult.Session;
            }
            else
            {
                // サインインに失敗
                return;
            }
        }

        private async void btnFindFolder_Click(object sender, RoutedEventArgs e)
        {
            var client = new LiveConnectClient(Session); // セッションを取得済みであることが前提

            // SkyDrive上のフォルダ、アルバム一覧を取得
            var result1 = await client.GetAsync("me/skydrive/files?filter=folders,albums");
            var folders = (List<object>)result1.Result["data"];
            foreach (dynamic item in folders)
            {
                string name = item.name;
                string id = item.id;

                // デバッグ出力
                System.Diagnostics.Debug.WriteLine("{0}：{1}", name, id);
            }
        }

        private async void btnCreateFolder_Click(object sender, RoutedEventArgs e)
        {
            var client = new LiveConnectClient(Session); // セッションを取得済みであることが前提

            // 作成するフォルダの名前
            var FOLDER_NAME = "{ここにフォルダーの名前を入れる}"; 

            // フォルダの名前やその他の情報を決める
            var data = new Dictionary<string, object>();
            data.Add("name", FOLDER_NAME);
            data.Add("description", "このフォルダは○○アプリで作成した写真を保存するフォルダです");

            // フォルダ作成の要求
            var result = await client.PostAsync("me/skydrive", data);

            // 成功すれば作成したフォルダの情報が取得できる
            var id = result.Result["id"] as string;
            var description = result.Result["description"] as string;

            System.Diagnostics.Debug.WriteLine("{0}：{1}", id, description);
        }

        private async void btnUploadFile_Click(object sender, RoutedEventArgs e)
        {
            // 既にセッションを取得済みであることが前提
            var client = new LiveConnectClient(Session);

            // SkyDrive上のアルバム一覧を取得
            var result1 = await client.GetAsync("me/skydrive/files?filter=albums");
            var folders = (List<dynamic>)result1.Result["data"];

            // PicturesフォルダーのIDをフォルダー取得する
            var picturesFolder = folders.Single(item => item.name == "Pictures");
            var folderID = picturesFolder.id;

            // SkyDriveにアップロードするファイルの名前を指定する
            var fileName = "test.png";

            // SkyDriveへ写真を非同期でバックグランドアップロードする
            var uri = new Uri("ms-appx:///Assets/SmallLogo.png");
            var file = await Windows.Storage.StorageFile.GetFileFromApplicationUriAsync(uri);
            var result2 = await client.BackgroundUploadAsync(folderID, fileName, file, OverwriteOption.Overwrite);
            
            // 成功すればアップロードしたファイルの情報が取得できる
            var source = (string)result2.Result.source;

            System.Diagnostics.Debug.WriteLine("source：{0}", source);
        }
    }
}
