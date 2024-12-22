/*
Этот файл содержит реализацию шифра Цезаря для русского алфавита.
Класс Caesar предоставляет методы для шифрования и дешифрования строк, а также для генерации уникальных ключей.
Методы:
- Encrypt: шифрует входное сообщение, сдвигая каждую букву на заданное количество позиций (ключ).
- Decrypt: дешифрует входное сообщение, сдвигая каждую букву обратно на заданное количество позиций (ключ).
- GetKeys: генерирует уникальные ключи для шифрования, возвращая список строк с заданным количеством ключей.
*/

using System;
using System.Collections.Generic;

public static class Caesar
{
  // Алфавит для шифрования
  private static char[] alphabet = "абвгдежзийклмнопрстуфхцчшщъыьэюя".ToCharArray();
  
  // Метод для шифрования сообщения
  public static string Encrypt(string message, int key)
  {
    if (key < 1 || key > 32)
      return message;

    string encryptedMessage = "";

    foreach (char c in message)
    {
      if (!char.IsLetter(c))
      {
        encryptedMessage += c;
        continue;
      }

      bool isUpperCase = char.IsUpper(c);
      int index = Array.IndexOf(alphabet, char.ToLower(c));
      int shiftedIndex = (index + key) % alphabet.Length;

      encryptedMessage += isUpperCase ? char.ToUpper(alphabet[shiftedIndex]) : alphabet[shiftedIndex];
    }

    return encryptedMessage;
  }

  // Метод для дешифрования сообщения
  public static string Decrypt(string message, int key)
  {
    if (key < 1 || key > 32)
      return message;

    string decryptedMessage = "";

    foreach (char c in message)
    {
      if (!char.IsLetter(c))
      {
        decryptedMessage += c;
        continue;
      }

      bool isUpperCase = char.IsUpper(c);
      int index = Array.IndexOf(alphabet, char.ToLower(c));
      int shiftedIndex = (index - key + alphabet.Length) % alphabet.Length;

      decryptedMessage += isUpperCase ? char.ToUpper(alphabet[shiftedIndex]) : alphabet[shiftedIndex];
    }

    return decryptedMessage;
  }

  // Метод для генерации уникальных ключей
  public static List<string> GetKeys(int amount)
  {
    if (amount > 31)
      return new List<string>();

    List<string> keys = new List<string>();
    int attempts = 0;

    while (keys.Count < amount && attempts < 1000)
    {
      string currentKey = UnityEngine.Random.Range(1, 32).ToString();

      if (!keys.Contains(currentKey))
      {
        keys.Add(currentKey);
      }

      attempts++;
    }

    return keys;
  }
}
