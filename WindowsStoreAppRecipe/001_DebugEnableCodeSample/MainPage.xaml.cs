using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// 空白ページのアイテム テンプレートについては、http://go.microsoft.com/fwlink/?LinkId=234238 を参照してください

namespace DebugEnableCodeSample
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

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
#if DEBUG
            // デバッグ以外のコンパイルでは、この部分は含まれない
            await new MessageDialog("デバッグ時のみ有効な処理").ShowAsync();
#endif
            await new MessageDialog("普通の処理").ShowAsync();
        }

        [System.Diagnostics.Conditional("DEBUG")]
        private async void DebugMethod()
        {
            // デバッグ時のみメソッドの呼び出しが有効になる
            await new MessageDialog("デバッグ時のみ有効な処理").ShowAsync();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // デバッグ以外のコンパイルでは、このメソッドは呼び出されない
            DebugMethod();
        }

    }
}
