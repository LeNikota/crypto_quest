using System;
using System.Collections.Generic;

public class MorseCode
{
    private static readonly Dictionary<char, string> morseDictionary = new Dictionary<char, string>
    {
        {'А', ".-"}, {'Б', "-..."}, {'В', ".--"}, {'Г', "--."}, {'Д', "-.."},
        {'Е', "."}, {'Ё', "."}, {'Ж', "...-."}, {'З', "--.."}, {'И', ".."},
        {'Й', ".---"}, {'К', "-.-"}, {'Л', ".-.."}, {'М', "--"}, {'Н', "-."},
        {'О', "---"}, {'П', ".--."}, {'Р', ".-."}, {'С', "..."}, {'Т', "-"},
        {'У', "..-"}, {'Ф', "..-."}, {'Х', "...."}, {'Ц', "-.-."}, {'Ч', "---."},
        {'Ш', "--"}, {'Щ', "--.-"}, {'Ъ', ".--.-."}, {'Ы', "-.--"}, {'Ь', "-..-"},
        {'Э', "..-.."}, {'Ю', "..--"}, {'Я', ".-.-"}, // А-Я
        {'0', "-----"}, {'1', ".----"}, {'2', "..---"}, {'3', "...--"}, {'4', "....-"},
        {'5', "....."}, {'6', "-...."}, {'7', "--..."}, {'8', "---.."}, {'9', "----."} // 0-9
    };

    private static readonly Dictionary<string, char> reverseMorseDictionary;

    static MorseCode()
    {
        reverseMorseDictionary = new Dictionary<string, char>();
        foreach (var pair in morseDictionary)
        {
            reverseMorseDictionary[pair.Value] = pair.Key;
        }
    }

    public static string Encode(string message)
    {
        string encodedMessage = "";
        message = message.ToUpper();

        foreach (char c in message)
        {
            if (c == ' ')
            {
                encodedMessage += "   "; // Use '   ' to separate words
                continue;
            }

            if (morseDictionary.TryGetValue(c, out string morseCode))
            {
                encodedMessage += morseCode + " ";
            }
        }

        return encodedMessage.Trim();
    }

    public static string Decode(string morseMessage)
    {
        string decodedMessage = "";
        string[] morseWords = morseMessage.Split(new string[] { "   " }, StringSplitOptions.None);

        foreach (string morseWord in morseWords)
        {
            string[] morseChars = morseWord.Trim().Split(' ');

            foreach (string morseChar in morseChars)
            {
                if (reverseMorseDictionary.TryGetValue(morseChar, out char letter))
                {
                    decodedMessage += letter;
                }
            }

            decodedMessage += " "; // Add space after each word
        }

        return decodedMessage.Trim();
    }
}
