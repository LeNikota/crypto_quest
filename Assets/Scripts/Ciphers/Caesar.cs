using System;
using System.Collections.Generic;
using UnityEngine;

public class Caesar : MonoBehaviour
{
//     string[] messages = {
//         "Дошел шестой легион",
//         "Враг на подходе, готовьтесь к бою!",
//         "Мы должны укрепить наши позиции.",
//         "Слухи о восстании требуют нашего внимания.",
//         "Победа будет за нами, если мы будем едины.",
//         "Не забывайте о своих товарищах на поле боя."
//     };
//     string encryptedMessage;
//     char[] alphabet = "абвгдежзийклмнопрстуфхцчшщъыьэюя".ToCharArray();
//     int correctKey;

//     void EncryptText(int key)
//     {
//         string message = messages[UnityEngine.Random.Range(0, messages.Length)];
//         encryptedMessage = "";

//         foreach (char c in message)
//         {
//             if (!char.IsLetter(c))
//             {
//                 encryptedMessage += c;
//                 continue;
//             }

//             bool isUpperCase = char.IsUpper(c);
//             int index = Array.IndexOf(alphabet, char.ToLower(c));
//             int shiftedIndex = (index + key) % alphabet.Length;

//             encryptedMessage += isUpperCase ? char.ToUpper(alphabet[shiftedIndex]) : alphabet[shiftedIndex];
//         }

//         encryptedDisplay.text = encryptedMessage;
//     }

//     void DecryptText(int key)
//     {
//         string decryptedMessage = "";

//         foreach (char c in encryptedMessage)
//         {
//             if (!char.IsLetter(c))
//             {
//                 decryptedMessage += c;
//                 continue;
//             }

//             bool isUpperCase = char.IsUpper(c);
//             int index = Array.IndexOf(alphabet, char.ToLower(c));
//             int shiftedIndex = (index - key + alphabet.Length) % alphabet.Length;

//             decryptedMessage += isUpperCase ? char.ToUpper(alphabet[shiftedIndex]) : alphabet[shiftedIndex];
//         }

//         encryptedDisplay.text = decryptedMessage;
//     }

//   public void Reset()
//     {
//         correctKey = UnityEngine.Random.Range(1, alphabet.Length);
//         correctButtonIndex = UnityEngine.Random.Range(0, 4);
//         List<int> keys = new List<int> { correctKey };

//         for (int i = 0; i < 4; i++)
//         {
//             int key;
            
//             if (correctButtonIndex == i)
//             {
//                 key = correctKey;
//             }
//             else
//             {
//                 do
//                 {
//                     key = UnityEngine.Random.Range(1, alphabet.Length);

//                 } while (keys.Contains(key));
//                 keys.Add(key);
//             }


//             answerButtonsText[i].text = key.ToString();
//             answerButtons[i].onClick.RemoveAllListeners();
//             answerButtons[i].onClick.AddListener(() => OnAnswerClick(key));

//             notificationPanelIncorrect.SetActive(false);
//         }

//         EncryptText(correctKey);
//     }

}
