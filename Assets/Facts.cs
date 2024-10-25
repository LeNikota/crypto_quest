using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;


public class Facts : MonoBehaviour
{
    public TextMeshProUGUI questionDisplay;
    public GameObject NotificationPanel;
    public TextMeshProUGUI NotificationPanelText;

    Button[] answerButtons = new Button[4];
    TextMeshProUGUI[] answerButtonsText = new TextMeshProUGUI[4];

    string[] questions = {
    "От Цезаря: Дошел шестой легион",
    "От Цезаря: Враг на подходе, готовьтесь к бою!",
    };
    int correctButtonIndex;

    // void AskQuestion()
    // {

    // }

    // void CheckAnswer(string answer)
    // {
        
    // }

    // void Init()
    // {
    //     for (int i = 0; i < 4; i++)
    //     {
    //         answerButtons[i] = GameObject.Find("Answer " + i).GetComponent<Button>();
    //         answerButtonsText[i] = GameObject.Find("Text button " + i).GetComponent<TextMeshProUGUI>();
    //     }

    // }

    // void DisplayGameResult(bool state){
    //     if (state)
    //     {
    //         NotificationPanel.SetActive(true);
    //     } else
    //     {
    //         NotificationPanel.SetActive(true);
    //         NotificationPanelText.text = $"Неправильно\nКлюч: {correctKey}";
    //     }
    // }


    // public void Reset()
    // {
    //     correctButtonIndex = UnityEngine.Random.Range(0, 4);
    //     List<int> keys = new List<int> { correctButtonIndex };

    //     for (int i = 0; i < 4; i++)
    //     {
    //         int key;
            
    //         if (correctButtonIndex == i)
    //         {
    //             key = correctKey;
    //         }
    //         else
    //         {
    //             do
    //             {
    //                 key = UnityEngine.Random.Range(1, alphabet.Length);

    //             } while (keys.Contains(key));
    //             keys.Add(key);
    //         }


    //         answerButtonsText[i].text = key.ToString();
    //         answerButtons[i].onClick.RemoveAllListeners();
    //         answerButtons[i].onClick.AddListener(() => OnAnswerClick(key));

    //         NotificationPanelIncorrect.SetActive(false);
    //     }

    //     EncryptText(correctKey);
    // }
    
    // public void OnAnswerClick(int key)
    // {
    //     DecryptText(correctKey);
    //     DisplayGameResult(key == correctKey);
    // }

    // public void LoadMenu() {
    //     SceneManager.LoadScene(0);
    // }


    // void Start()
    // {
    //     Init();
    //     Reset();
    // }
}
