using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Softbuild.Data.Csv;

namespace CSVParseSample
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var csv = new StringBuilder();
            csv.AppendLine("Src,Eqid,Version,Datetime,Lat,Lon,Magnitude,Depth,NST,Region");
            csv.AppendLine("ci,15196921,0,Wednesday August 22 2012 20:49:19 UTC,36.0780,-117.7738,1.3,3.90,15,Central California");

            var parser = CSVParser.Parse(csv.ToString());

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var csv = new StringBuilder();
            csv.AppendLine("ci,15196921,0,Wednesday August 22 2012 20:49:19 UTC,36.0780,-117.7738,1.3,3.90,15,Central California"); 
 
            var parser = CSVParser.Parse(csv.ToString());
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var csv = new StringBuilder();
            csv.AppendLine("1,2,3,4,5,6,7,8,9,10");
            csv.AppendLine("1,\"2,2\",3,4,5,6,7,8,9,10");
            csv.AppendLine("1,\"2,2|2,2\",3,4,5,6,7,8,9,10");

            var parser = CSVParser.Parse(csv.ToString());
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            var csv = new StringBuilder();
            csv.AppendLine("1,2,3,4,5,6,7,8,9,");
            csv.AppendLine("1,2,\"3\",4,5,6,7,8,9,10");
            csv.AppendLine("1,2,\"3,3,3,3,3\",4,5,6,7,8,9,10");
            csv.AppendLine("1,2,3,\"4,4\",5,6,7,8,9,10");
            csv.AppendLine("1,2,3,\"4\"\"4\",5,6,7,8,9,10");

            var parser = CSVParser.Parse(csv.ToString());
        }
    }
}
