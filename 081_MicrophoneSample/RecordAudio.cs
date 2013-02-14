using System;
using System.Threading.Tasks;
using Windows.Media.Capture;
using Windows.Media.MediaProperties;
using Windows.Storage;

namespace MicrophoneSample
{
    /// <summary>
    /// 録音をおこなうクラス
    /// </summary>
    public class RecordAudio
    {
        MediaCapture mediaCapture = null;

        public async Task InitializeAsync()
        {
            // 録音をおこなうためのオブジェクトを生成する
            mediaCapture = new MediaCapture();

            // 録音用の初期化を開始する
            var settings = new MediaCaptureInitializationSettings();
            settings.StreamingCaptureMode = StreamingCaptureMode.Audio;
            await mediaCapture.InitializeAsync(settings);
        }

        public async Task StartRecordAsync()
        {
            var fileName = "foo.m4a"; // 保存するファイル名

            // 録音したファイルはローカルフォルダへ保存する
            var local =  ApplicationData.Current.LocalFolder;

            // 録音したデータを書き込むファイルを作成する
            var file = await local.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
            
            // AACフォーマットで録音を開始する
            var profile = MediaEncodingProfile.CreateM4a(AudioEncodingQuality.High);
            await mediaCapture.StartRecordToStorageFileAsync(profile, file);
        }

        public async Task StopRecordAsync()
        {
            // 録音を終了します
            await mediaCapture.StopRecordAsync();
        }
    }
}
