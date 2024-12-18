using System;

public static class Caesar
{
  private static char[] alphabet = "абвгдежзийклмнопрстуфхцчшщъыьэюя".ToCharArray();

  public static string Encrypt(string message, int key)
  {
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

  public static string Decrypt(string message, int key)
  {
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
}
