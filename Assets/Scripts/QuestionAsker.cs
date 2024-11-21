using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class QuestionAsker : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI display;
    [SerializeField] private List<Button> answerButtons = new List<Button>(4);
    [SerializeField] private List<TextMeshProUGUI> answerButtonsText = new List<TextMeshProUGUI>(4);
    private Action<string> handleAnswerClick;



    public void DisplayQuestion(string question, string[] answers)
    {
        display.text = question;

        List<string> answersList = new List<string>(answers);
        for (int i = 0; i < 4; i++)
        {

            int j = UnityEngine.Random.Range(0, answersList.Count - 1);
            string answer = answersList[j];
            answerButtonsText[i].text = answer;
            answerButtons[i].onClick.RemoveAllListeners();
            answerButtons[i].onClick.AddListener(() => handleAnswerClick(answer));
            answersList.RemoveAt(j);
        }
    }

    public void SetAnswerClickHandler(Action<string> buttonHandler)
    {
        handleAnswerClick = buttonHandler;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
    public void Show()
    {
        gameObject.SetActive(true);
    }
}
