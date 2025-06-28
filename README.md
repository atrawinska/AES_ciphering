# AES Ciphering Application

This project is a desktop application built using **C#** and **Avalonia UI** that demonstrates the use of the **Advanced Encryption Standard (AES)** for text encryption and decryption. It was developed as part of the *Introduction to Computer Security (2025)* course at **Högskolan Kristianstad** and according to the examples provided by Microsoft Learn (URL: https://learn.microsoft.com/en-gb/dotnet/api/system.security.cryptography.aes?view=net-8.0).

## ✨ Functionalities

- Encrypt any text using AES with a randomly generated key and IV.
- Decrypt encrypted Base64 text securely.
- User-friendly interface with separate blocks for ciphering and deciphering.
- Implements MVVM architecture using `CommunityToolkit.Mvvm`.

## 🛠️ Technologies

- C# (.NET 9)
- Avalonia UI
- System.Security.Cryptography
- MVVM (Model-View-ViewModel) structure with CommunityToolkit 
- Visual Studio Code

## ⚙ How It Works

### 1. Key and IV Generation
- A 256-bit encryption key and a 128-bit Initialization Vector (IV) are randomly generated using `RandomNumberGenerator`.

### 2. Encryption
- (string) plaintext is encrypted and the output is a **Base64-encoded** string suitable for display and storage.

### 3. Decryption
- Base64 input is converted back into bytes and decrypted using the same key and IV.
- Error handling ensures that incorrect input does not crash the application (try-catch block).

## 🖼️ User Interface

The application has two containers:
- **Cipher** block – encrypts input text and displays the result,
- **Decipher** block – decrypts input Base64 ciphertext and displays the original message.

## 🚀 Getting Started

### Software tools
- .NET 9 SDK
- Avalonia templates (`dotnet new install Avalonia.Templates`)
- A C# IDE (e.g., Visual Studio Code)

### Run the App

```bash
git clone https://github.com/atrawinska/AES_ciphering
cd AES_ciphering
dotnet run
