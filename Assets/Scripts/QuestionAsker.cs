using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class QuestionAsker : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI taskDisplay;
    [SerializeField] private TextMeshProUGUI textDisplay;
    [SerializeField] private List<Button> answerButtons = new List<Button>(4);
    [SerializeField] private List<TextMeshProUGUI> answerButtonsText = new List<TextMeshProUGUI>(4);
    private Action<string> handleAnswerClick;



    public void DisplayQuestion(string task, string question, List<string> answers)
    {
        List<string> answersCopy = new List<string>(answers.Select(answer => string.Copy(answer)));
        for (int i = 0; i < 4; i++)
        {
            int j = UnityEngine.Random.Range(0, answers.Count);
            string answer = answers[j];
            answerButtonsText[i].text = answer;
            answerButtons[i].onClick.RemoveAllListeners();
            answerButtons[i].onClick.AddListener(() => handleAnswerClick(answer));
            answers.RemoveAt(j);
        }
        textDisplay.text = question;
        taskDisplay.text = task;
    }

    public void SetAnswerClickHandler(Action<string> buttonHandler)
    {
        handleAnswerClick = buttonHandler;
    }

    public void Show(bool state = true)
    {
        gameObject.SetActive(state);
    }
}
