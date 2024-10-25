using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class encryptor : MonoBehaviour
{
    public GameObject notificationPanelCorrect;
    public GameObject notificationPanelIncorrect;
    public TextMeshProUGUI notificationPanelIncorrectText;

    TextMeshProUGUI encryptedDisplay;
    Button[] answerButtons = new Button[4];
    TextMeshProUGUI[] answerButtonsText = new TextMeshProUGUI[4];

    string[] messages = {
    "От Цезаря: Дошел шестой легион",
    "От Цезаря: Враг на подходе, готовьтесь к бою!",
    "От Цезаря: Мы должны укрепить наши позиции.",
    "От Цезаря: Слухи о восстании требуют нашего внимания.",
    "От Цезаря: Победа будет за нами, если мы будем едины.",
    "От Цезаря: Не забывайте о своих товарищах на поле боя."
    };
    string encryptedMessage;
    char[] alphabet = "абвгдежзийклмнопрстуфхцчшщъыьэюя".ToCharArray();
    int correctKey;
    int correctButtonIndex;

    void EncryptText(int key)
    {
        string message = messages[UnityEngine.Random.Range(0, messages.Length)];
        encryptedMessage = "";

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

        encryptedDisplay.text = encryptedMessage;
    }

    void DecryptText(int key)
    {
        string decryptedMessage = "";

        foreach (char c in encryptedMessage)
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

        encryptedDisplay.text = decryptedMessage;
    }

    void Init()
    {
        encryptedDisplay = GameObject.Find("Encrypted text").GetComponent<TextMeshProUGUI>();
        for (int i = 0; i < 4; i++)
        {
            answerButtons[i] = GameObject.Find("Answer " + i).GetComponent<Button>();
            answerButtonsText[i] = GameObject.Find("Text button " + i).GetComponent<TextMeshProUGUI>();
        }

    }

    void DisplayGameResult(bool state){
        if (state)
        {
            notificationPanelCorrect.SetActive(true);
        } else
        {
            notificationPanelIncorrect.SetActive(true);
            notificationPanelIncorrectText.text = $"Неправильно\nКлюч: {correctKey}";
        }
    }


    public void Reset()
    {
        correctKey = UnityEngine.Random.Range(1, alphabet.Length);
        correctButtonIndex = UnityEngine.Random.Range(0, 4);
        List<int> keys = new List<int> { correctKey };

        for (int i = 0; i < 4; i++)
        {
            int key;
            
            if (correctButtonIndex == i)
            {
                key = correctKey;
            }
            else
            {
                do
                {
                    key = UnityEngine.Random.Range(1, alphabet.Length);

                } while (keys.Contains(key));
                keys.Add(key);
            }


            answerButtonsText[i].text = key.ToString();
            answerButtons[i].onClick.RemoveAllListeners();
            answerButtons[i].onClick.AddListener(() => OnAnswerClick(key));

            notificationPanelIncorrect.SetActive(false);
        }

        EncryptText(correctKey);
    }
    
    public void OnAnswerClick(int key)
    {
        DecryptText(correctKey);
        DisplayGameResult(key == correctKey);
    }

    public void LoadMenu() {
        SceneManager.LoadScene(0);
    }


    void Start()
    {
        Init();
        Reset();
    }
}
