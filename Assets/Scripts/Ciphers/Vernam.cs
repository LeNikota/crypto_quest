/*
Этот файл содержит реализацию шифра Вернама для русского алфавита.
Класс Vernam предоставляет методы для шифрования и дешифрования строк с использованием ключа.
Методы:
- Encrypt: шифрует входное сообщение, используя ключ, который должен быть такой же длины, как и сообщение.
- Decrypt: дешифрует зашифрованное сообщение, используя тот же ключ.
- GetMessage: получает сообщение, ограничивая его до трех слов.
- GetKeys: генерирует заданное количество случайных ключей для шифрования, каждый из которых имеет длину, равную длине сообщения.
*/

using System.Linq;
using System.Text;
using System.Collections.Generic;

public static class Vernam
{

    // Алфавит для шифрования
    private static readonly string alphabet = "абвгдежзийклмнопрстуфхцчшщъыьэюя";
    private const int RussianCharStart = 1040; // Начальный код русского символа 'А'
    private const int RussianCharEnd = 1103;   // Конечный код русского символа 'я'
    private const int RussianCharCount = RussianCharEnd - RussianCharStart + 1; // Количество русских символов

    // Метод для шифрования сообщения
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

    // Метод для дешифрования сообщения
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

    // Метод для шифрования отдельного символа
    private static char EncryptChar(char messageChar, char keyChar)
    {
        if (IsRussianChar(messageChar) && IsRussianChar(keyChar))
        {
            int encryptedValue = (messageChar - RussianCharStart + keyChar - RussianCharStart) % RussianCharCount + RussianCharStart;
            return (char)encryptedValue;
        }
        return messageChar;
    }

    // Метод для дешифрования отдельного символа
    private static char DecryptChar(char encryptedChar, char keyChar)
    {
        if (IsRussianChar(encryptedChar) && IsRussianChar(keyChar))
        {
            int decryptedValue = (encryptedChar - RussianCharStart - (keyChar - RussianCharStart) + RussianCharCount) % RussianCharCount + RussianCharStart;
            return (char)decryptedValue;
        }
        return encryptedChar;
    }

    // Метод для проверки, является ли символ русским
    private static bool IsRussianChar(char c)
    {
        return c >= RussianCharStart && c <= RussianCharEnd;
    }

    // Метод для получения сообщения
    public static string GetMessage()
    {
        string message = Messages.Get();
        string[] words = message.Split(new[] { ' ', '\t', '\n' });

        if (words.Length > 3)
            message = string.Join(" ", words.Take(3));

        return message;
    }

    // Метод для генерации случайных ключей
    public static List<string> GetKeys(int amount, int messageLength)
    {
        List<string> keys = new();
        for (int k = 0; k < 4; k++)
        {
            string key = "";
            for (int i = 0; i < messageLength; i++)
            {
                key += alphabet[UnityEngine.Random.Range(0, alphabet.Length)];
            }
            keys.Add(key);
        }
        return keys;
    }
}
