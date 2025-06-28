using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace AES_imp.Models;


/// <summary>
/// AES done with use of: 
/// https://learn.microsoft.com/pl-pl/dotnet/api/system.security.cryptography.aes?view=net-8.0 
/// simplified but sufficient for the use case
/// </summary>
public class AESHelper
{
    /// <summary>
    /// encryption key
    /// </summary>
    private readonly byte[] _key;

    /// <summary>
    /// initialization vector
    /// </summary>
    private readonly byte[] _iv;



    /// <summary>
    /// Parametirized constructor taking key and iv for encryption/decryption purposes.
    /// </summary>
    /// <param name="key">The encryption key as a string</param>
    /// <param name="iv">The initialization vector as a string</param>
    public AESHelper(string key, string iv)
    {
        _key = Encoding.UTF8.GetBytes(key.PadRight(32).Substring(0, 32)); // 32 bytes = 256 bits
        _iv = Encoding.UTF8.GetBytes(iv.PadRight(16).Substring(0, 16));   // 16 bytes = 128 bits
    }



    /// <summary>
    /// Encryps the given plain text with passed to constructor data.
    /// </summary>
    /// <param name="plainText">Text passed to encode.</param>
    /// <returns>Ciphered text.</returns>
    public string Encrypt(string plainText)
    {
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = _key; //set the key
            aesAlg.IV = _iv; //set the vector
            aesAlg.Mode = CipherMode.CBC; //mode, Cipher Block Chaining- prevents patterns
            aesAlg.Padding = PaddingMode.PKCS7;//padding, standard padding scheme, ensures block size martching

            //encryptor object
            ICryptoTransform encryptor = aesAlg.CreateEncryptor();

          //encrypyed data in memory, encryptor needs a stream
            using (MemoryStream msEncrypt = new MemoryStream())
            //encryption -> transformation done
            using (CryptoStream csEncrypt =
                new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write)) //Encrypts data as it is written.
            //plain text -> encrypted stream
            using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
            {
                swEncrypt.Write(plainText);
                swEncrypt.Close();
                return Convert.ToBase64String(msEncrypt.ToArray()); //conversion from bytes[] to Base64 string

            }
        }//using
    }//method




    /// <summary>
    /// Decrypts the passed ciphered text with use of the key and iv passed in the constructor.
    /// </summary>
    /// <param name="cipherText"></param>
    /// <returns>plain string</returns>
    public string Decrypt(string cipherText)
    {
        byte[] cipherBytes = Convert.FromBase64String(cipherText);

        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = _key;
            aesAlg.IV = _iv;
            aesAlg.Mode = CipherMode.CBC; //mode
            aesAlg.Padding = PaddingMode.PKCS7;
            //decryptor object
            ICryptoTransform decryptor = aesAlg.CreateDecryptor();
            //holding bytes in the memory -> decryptor needs a stream
            using (MemoryStream msDecrypt = new MemoryStream(cipherBytes))
            //decryption -> transformation done
            using (CryptoStream csDecrypt =
                     new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
            //ciphered text -> decrypted text (plain text)
            using (StreamReader srDecrypt = new StreamReader(csDecrypt))
            {
                return srDecrypt.ReadToEnd();
            }
        }//using
    }//method
}//class


