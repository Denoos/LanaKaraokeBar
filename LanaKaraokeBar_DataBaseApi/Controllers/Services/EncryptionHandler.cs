using LanaKaraokeBar_DataBaseApi.Models;
using System.Security.Cryptography;
using System.Text;

namespace LanaKaraokeBar_DataBaseApi.Controllers.Services
{
    public class EncryptionHandler
    {
        public string Encrypt(string key)
        {
            key = BaseEncrypt(key);
            key = AdditionalEncryption(key);
            return key;
        }

        private string BaseEncrypt(string key)
        {
            var keyBytes = Encoding.UTF8.GetBytes(key);
            keyBytes = SHA256.HashData(keyBytes);

            key = Convert.ToHexString(keyBytes).ToLower();

            return key;
        }

        private string AdditionalEncryption(string key)
        {
            var keyArray = key.ToCharArray().ToList();

            for (int i = 0; i < keyArray.Count - 3; i += EncryptionNumbers.StepNumber)
            {
                (keyArray[i], keyArray[i + 3]) = (keyArray[i + 3], keyArray[i]);
            }

            if (keyArray.Count > 10)
            {
                (keyArray[EncryptionNumbers.FirstCrypter], keyArray[EncryptionNumbers.SecondCrypter]) = (keyArray[EncryptionNumbers.SecondCrypter], keyArray[EncryptionNumbers.FirstCrypter]);
            }

            key = new string([.. keyArray]);

            return key;
        }
    }
}