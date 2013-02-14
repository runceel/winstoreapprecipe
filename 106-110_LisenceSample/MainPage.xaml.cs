using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.ApplicationModel.Store;
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

namespace LisenceSample
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


        bool GetTrialMode()
        {
            var info = default(LicenseInformation);
#if DEBUG
            info = CurrentAppSimulator.LicenseInformation;
#else
            info = CurrentApp.LicenseInformation;
#endif
            var active = info.IsActive;
            if (active)
            {
                // 有料版の挙動

                if (info.IsTrial)
                {
                    // 試用中である
                }
            }
            else
            {
                // 無料版の挙動
            }

            info.LicenseChanged += info_LicenseChanged;

            if (info.IsTrial)
            {
                // 試用期間の期限切れを取得する
                var expireOffset = info.ExpirationDate;

                // 試用期間の日付を取得する
                var date = expireOffset.Date;
            }



            return active;
        }

        void info_LicenseChanged()
        {
            // ここでライセンスの状態を判定して、処理を切り分ける
        }

        /// <summary>
        /// このページがフレームに表示されるときに呼び出されます。
        /// </summary>
        /// <param name="e">このページにどのように到達したかを説明するイベント データ。Parameter 
        /// プロパティは、通常、ページを構成するために使用します。</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            GetTrialMode();

            var html = "<html><head><title>やっほー！</title></head><body>酢酸ですよー</body></html>";
            var text = Windows.Data.Html.HtmlUtilities.ConvertToText(html);

            // 「酢酸ですよー」だけを取得することができます


        }
    }
}
