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


using System.Reflection; // 拡張メソッドのGetRuntimeMethodメソッドに必要

namespace StringToCreateInstanceSample
{
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Itemクラスの型情報を取得
            var type = Type.GetType("Sample.Item");

            // コンストラクタ引数無しでインスタンスを生成
            var instance = Activator.CreateInstance(type);

            // GetIDメソッドの属性などの情報を取得
            var methodInfo = type.GetTypeInfo().GetDeclaredMethod("GetID");

            // GetIDメソッドの実行
            var obj = methodInfo.Invoke(instance, null);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            // Nantokaクラスの型情報を取得
            var type = Type.GetType("Sample.Item");

            // コンストラクタ引数を指定してインスタンスを生成
            var instance = Activator.CreateInstance(type, new object[] { 393 });

            // GetIDメソッドの属性などの情報を取得
            var methodInfo = type.GetTypeInfo().GetDeclaredMethod("GetID");

            // GetIDメソッドの実行
            var obj = methodInfo.Invoke(instance, null);
        }
    }
}
