using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;
using Windows.Storage.Streams;

namespace HashAlgorithmSample
{
    public class HashAlgorithm
    {
        public string ComputeMD5Hash(string input)
        {
            // MD5のハッシュプロバイダーを取得する
            var algorithm = HashAlgorithmProvider.OpenAlgorithm("MD5");
            // 暗号前の文字列をバイナリ形式のバッファに変換する
            IBuffer buffer = CryptographicBuffer.ConvertStringToBinary(input, BinaryStringEncoding.Utf8);
            // バッファからハッシュ化されたデータを取得する
            var hash = algorithm.HashData(buffer);
            // ハッシュ化されたデータを16進数の文字列へ変換
            return CryptographicBuffer.EncodeToHexString(hash);
        }

        public string ComputeSHA1Hash(string input)
        {
            // SHA1のハッシュプロバイダーを取得する
            var algorithm = HashAlgorithmProvider.OpenAlgorithm("SHA1");
            // 暗号前の文字列をバイナリ形式のバッファに変換する
            IBuffer buffer = CryptographicBuffer.ConvertStringToBinary(input, BinaryStringEncoding.Utf8);
            // バッファからハッシュ化されたデータを取得する
            var hash = algorithm.HashData(buffer);
            // ハッシュ化されたデータを16進数の文字列へ変換
            return CryptographicBuffer.EncodeToHexString(hash);
        }
    }
}
