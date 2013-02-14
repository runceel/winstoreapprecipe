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

namespace HashAlgorithmSample
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

        private void btnSha1_Click(object sender, RoutedEventArgs e)
        {
            HashAlgorithm algorithm = new HashAlgorithm();
            var sha1 = algorithm.ComputeSHA1Hash("CH3COOH");
            // 出力：baa44006e5e94bd226df8b898ec921436bfe42f5
        }

        private void btnMd5_Click(object sender, RoutedEventArgs e)
        {
            HashAlgorithm algorithm = new HashAlgorithm();
            var md5 = algorithm.ComputeMD5Hash("CH3COOH");
            // 出力：e69e27380a0146e24533c9ea5bbf1e86
        }
    }
}
