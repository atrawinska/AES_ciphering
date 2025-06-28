using System.Security.Cryptography;


namespace AES_imp.Models;


/// <summary>
/// Static class which generates random variables 
/// (key, initalization vector (iv) for the AES encryption/decryption) with the standard sizes.
/// Available methods: GenerateRandomKey() and GenerateRandomIV() with optional parameters.
/// </summary>
public static class Generator
{

/// <summary>
/// Generates a random key needed for AES encryption. 
/// It has an optional parameters for the size, the default value there is 32 as a standard.
/// </summary>
/// <param name="size">Size of the byte[] for AES encryption.</param>
/// <returns>byte[] which is an array of bytes for the encryption.</returns>
    public static byte[] GenerateRandomKey(int size = 32) //size in bytes, 32 =>256 bits
    {

        byte[] key = new byte[size]; 
        using (var rng = RandomNumberGenerator.Create() ){
            rng.GetBytes(key);
        }
        return key;
    }


/// <summary>
/// Generates a random initialization vector (iv) needed for AES encryption. 
/// It has an optional parameters for the size, the default value there is 16 as a standard.
/// </summary>
/// <param name="size">Size of the byte[] for AES encryption.</param>
/// <returns>byte[] which is an array of bytes for the encryption.</returns>
    public static byte[] GenerateRandomIV(int size = 16) //16 bytes=>128 bits
    {
        byte[] iv = new byte[size];
        using (var rng = RandomNumberGenerator.Create() ) {
            rng.GetBytes(iv);
        }
        return iv;
    }

}


