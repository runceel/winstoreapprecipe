using System;
using Windows.UI.ApplicationSettings;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace SettingsPaneSample
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        // ページ遷移時に実行される
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // Windows.UI.ApplicationSettings名前空間の設定ペインのオブジェクトを取得
            var settings = SettingsPane.GetForCurrentView();
            // ユーザーが設定ペインを表示するときに呼び出される設定項目の初期化処理
            settings.CommandsRequested += settings_CommandsRequested;
        }

        // 設定ペインが表示された
        void settings_CommandsRequested(SettingsPane sender, SettingsPaneCommandsRequestedEventArgs args)
        {
            // 設定コメントを作成します
            var command = new SettingsCommand("ID1", "○○設定",
                new UICommandInvokedHandler(async (target) =>
                {
                    // メッセージダイアログで表示する
                    var dialog = new MessageDialog("○○の設定ですよ");
                    await dialog.ShowAsync();
                }));
            args.Request.ApplicationCommands.Add(command);
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            // 設定ペインを表示する
            SettingsPane.Show();
        }

    }
}
