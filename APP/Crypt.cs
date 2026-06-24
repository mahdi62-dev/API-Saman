using System.Security.Cryptography;
using System.Text;

namespace APP;

public class Crypt
{
    //public string EncryptString(string key, string plainText)
    //{
    //    var iv = new byte[16];
    //    byte[] array;

    //    using (var aes = Aes.Create())
    //    {
    //        aes.Key = Encoding.UTF8.GetBytes(key);
    //        aes.IV = iv;

    //        var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

    //        using (var memoryStream = new MemoryStream())
    //        {
    //            using (var cryptoStream =
    //                   new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
    //            {
    //                using (var streamWriter = new StreamWriter(cryptoStream))
    //                {
    //                    streamWriter.Write(plainText);
    //                }

    //                array = memoryStream.ToArray();
    //            }
    //        }
    //    }

    //    return Convert.ToBase64String(array);
    //}

    //public string DecryptString(string key, string cipherText)
    //{
    //    var incoming = cipherText.Replace('_', '/').Replace('-', '+');

    //    //switch (cipherText.Length % 4)

    //    switch (incoming.Length % 4)
    //    {
    //        case 2:
    //            incoming += "==";
    //            break;
    //        case 3:
    //            incoming += "=";
    //            break;
    //    }

    //    var iv = new byte[16];
    //    var buffer = Convert.FromBase64String(incoming);

    //    using (var aes = Aes.Create())
    //    {
    //        aes.Key = Encoding.UTF8.GetBytes(key);
    //        aes.IV = iv;
    //        var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

    //        using (var memoryStream = new MemoryStream(buffer))
    //        {
    //            using (var cryptoStream =
    //                   new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
    //            {
    //                using (var streamReader = new StreamReader(cryptoStream))
    //                {
    //                    return streamReader.ReadToEnd();
    //                }
    //            }
    //        }
    //    }
    //}

    public string EncryptString(string key, string plainText)
    {
        var iv = new byte[16];
        byte[] array;

        using (var aes = Aes.Create())
        {
            aes.Key = Encoding.UTF8.GetBytes(key);
            aes.IV = iv;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

            using (var memoryStream = new MemoryStream())
            {
                using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                using (var streamWriter = new StreamWriter(cryptoStream, Encoding.UTF8))
                {
                    streamWriter.Write(plainText);
                }

                array = memoryStream.ToArray();
            }
        }

        return Convert.ToBase64String(array)
            .Replace('+', '-')
            .Replace('/', '_')
            .TrimEnd('=');
    }
    public string DecryptString(string key, string cipherText)
    {
        var incoming = cipherText.Replace('_', '/').Replace('-', '+');

        switch (incoming.Length % 4)
        {
            case 2:
                incoming += "==";
                break;
            case 3:
                incoming += "=";
                break;
        }

        var iv = new byte[16];
        var buffer = Convert.FromBase64String(incoming);

        using (var aes = Aes.Create())
        {
            aes.Key = Encoding.UTF8.GetBytes(key);
            aes.IV = iv;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

            using (var memoryStream = new MemoryStream(buffer))
            using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
            using (var streamReader = new StreamReader(cryptoStream, Encoding.UTF8))
            {
                return streamReader.ReadToEnd();
            }
        }
    }
}