using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AES_imp.Models;
using System;
namespace AES_imp.ViewModels;


/// <summary>
/// Main class with all the basic logics. It uses Generator class and AEShelper for the logics.
/// The variables are bonded with MVVM rules to the Views/MainWindowView classes.
/// </summary>
public partial class MainWindowViewModel : ViewModelBase
{

    /// <summary>
    /// Input text from the cipher block which is the text to be deciphered by the cipher button.
    /// </summary>
    [ObservableProperty]
    private string text = "";

    /// Output text from the decipher block which is the deciphered text. 
    /// It appears after clicking the decipher button which also converts 
    /// the plain text to encoded.
    /// </summary>
    [ObservableProperty]
    private string cipheredText = "";

    /// <summary>
    /// Output text from the decipher block which is the deciphered text. 
    /// It appears after clicking the decipher button which also converts 
    /// the encoded text to decoded.
    /// </summary>
    [ObservableProperty]
    private string decipheredText = "";


    /// <summary>
    /// Input text from the decipher block which is the text to be deciphered.
    /// </summary>
    [ObservableProperty]
    private string cipherText = "";



    /// <summary>
    /// A key needed for the AES helper to be passed. It is randomly generated while started by use 
    /// of Generator static class which assigns a proper 32-bit number to it. 
    /// Then it is converted from byte[] to string.
    /// </summary>
    private string? key = Convert.ToBase64String(Generator.GenerateRandomKey()); //i tried with ToString() conversion but it does nor return what is desired as a byte is used

    /// <summary>
    /// An iv (initalizaion vector) needed for the AES helper to be passed. It is randomly 
    /// generated while started by use of Generator static class which assigns 
    /// a proper 32-bit number to it. Then it is converted from byte[] to string.
    /// </summary>
    private string? iv = Convert.ToBase64String(Generator.GenerateRandomIV());



    /// <summary>
    /// Method bonded with the cipher button which encodes Text input from the Cipher box. 
    /// It calls AEShelper to provide the encryption service.
    /// </summary>
    [RelayCommand]
    public void Cipher()
    {

        AESHelper aESHelper = new(key, iv);
        CipheredText = aESHelper.Encrypt(Text);


    }

    /// <summary>
    /// Method bonded with the decipher button which encodes CipherText input from the Decipher box. 
    /// It calls AEShelper to provide the decryption service.
    /// </summary>
    [RelayCommand]
    public void Decipher()
    {

        AESHelper aESHelper = new(key, iv);
        DecipheredText = aESHelper.Decrypt(CipherText);

    }

}
