using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace MicrophoneSample
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        RecordAudio recordAudio = null;
        bool recording = false;

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            // 初期化する
            recordAudio = new RecordAudio();
            await recordAudio.InitializeAsync();
        }

        private async void btnRecording_Click(object sender, RoutedEventArgs e)
        {
            if (!recording)
            {
                await recordAudio.StartRecordAsync();
                recording = true;
                btnRecording.Content = "録音 終了";
            }
            else
            {
                await recordAudio.StopRecordAsync();
                recording = false;
                btnRecording.Content = "録音 開始";
            }
        }
    }
}

