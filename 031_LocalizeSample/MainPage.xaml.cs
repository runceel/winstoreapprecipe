using Windows.ApplicationModel.Resources.Core;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Controls;

namespace LocalizeSample
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            // リソースマップを作成
            var map = ResourceManager.Current.MainResourceMap;

            // ボタンをテキスト部分を変更
            btnOpen.Content = map.GetValue("Resources/LabelOpen").ValueAsString;
        }
    }
}
