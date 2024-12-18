using System;
using System.Text;

public static class Vernam
{
    
    private const int RussianCharStart = 1040; 
    private const int RussianCharEnd = 1103;   
    private const int RussianCharCount = RussianCharEnd - RussianCharStart + 1;

    public static string Encrypt(string message, string key)
    {
        if (message.Length != key.Length)
            return message;

        StringBuilder encryptedMessage = new StringBuilder();

        for (int i = 0; i < message.Length; i++)
        {
            char encryptedChar = EncryptChar(message[i], key[i]);
            encryptedMessage.Append(encryptedChar);
        }

        return encryptedMessage.ToString();
    }

    public static string Decrypt(string encryptedMessage, string key)
    {
        if (encryptedMessage.Length != key.Length)
            return encryptedMessage;

        StringBuilder decryptedMessage = new StringBuilder();

        for (int i = 0; i < encryptedMessage.Length; i++)
        {
            char decryptedChar = DecryptChar(encryptedMessage[i], key[i]);
            decryptedMessage.Append(decryptedChar);
        }

        return decryptedMessage.ToString();
    }

    private static char EncryptChar(char messageChar, char keyChar)
    {
        if (IsRussianChar(messageChar) && IsRussianChar(keyChar))
        {
            int encryptedValue = (messageChar - RussianCharStart + keyChar - RussianCharStart) % RussianCharCount + RussianCharStart;
            return (char)encryptedValue;
        }
        return messageChar;
    }

    private static char DecryptChar(char encryptedChar, char keyChar)
    {
        if (IsRussianChar(encryptedChar) && IsRussianChar(keyChar))
        {
            int decryptedValue = (encryptedChar - RussianCharStart - (keyChar - RussianCharStart) + RussianCharCount) % RussianCharCount + RussianCharStart;
            return (char)decryptedValue;
        }
        return encryptedChar; 
    }

    private static bool IsRussianChar(char c)
    {
        return c >= RussianCharStart && c <= RussianCharEnd;
    }
}
