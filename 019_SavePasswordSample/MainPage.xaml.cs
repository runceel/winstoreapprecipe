using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// 
using Windows.Storage;
using Windows.Security.Credentials;


namespace SavePasswordSample
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

        private void SavePassword(string username, string password)
        {
            // LocalSettingsやRoamingSettingsに保存された設定値は平文で保存される
            var local = ApplicationData.Current.LocalSettings;
            local.Values["UserName"] = username;
            local.Values["Password"] = password;
        }

        private dynamic LoadPassword()
        {
            // LocalSettingsに保存している設定値を取り出す
            var local = ApplicationData.Current.LocalSettings;
            var username = local.Values["UserName"];
            var password = local.Values["Password"];

            return new { UserName = username, Password = password };
        }

        const string RESOURCE = "jp.softbuild.PasswordSample";

        private void SecureSavePassword(string username, string password)
        {
            // 資格情報をCredential Lockerへ保存します
            var vault = new PasswordVault();
            var credential = new PasswordCredential(RESOURCE, username, password);
            vault.Add(credential);
        }

        private dynamic SecureLoadPassword(string username)
        {
            // Credential Lockerから資格情報を取得する
            PasswordVault vault = new PasswordVault();
            PasswordCredential credential = vault.Retrieve(RESOURCE, username);

            return new { UserName = credential.UserName, Password = credential.Password };
        }


        // 平文でパスワードを保存する
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // ユーザー名が「酢酸」
            // パスワードが「ch3cooh393」とする場合
            SavePassword("酢酸", "ch3cooh393");
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            dynamic userinfo = LoadPassword();
        }

        // 暗号化してパスワードを保存する
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SecureSavePassword("酢酸", "ch3cooh393");
        }

        // 暗号化したパスワードを取得する
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            dynamic userinfo = SecureLoadPassword("酢酸");
        }
    }
}
