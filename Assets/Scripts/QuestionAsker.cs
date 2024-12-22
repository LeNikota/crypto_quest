// Класс QuestionAsker управляет отображением вопросов и ответов, а также обработкой нажатий на кнопки ответов.

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class QuestionAsker : MonoBehaviour
{
    // Поле для отображения задачи.
    [SerializeField] private TextMeshProUGUI taskDisplay;
    // Поле для отображения текста вопроса.
    [SerializeField] private TextMeshProUGUI textDisplay;
    // Список кнопок для ответов.
    [SerializeField] private List<Button> answerButtons = new List<Button>(4);
    // Список текстов на кнопках ответов.
    [SerializeField] private List<TextMeshProUGUI> answerButtonsText = new List<TextMeshProUGUI>(4);

    // Обработчик нажатия на кнопку ответа.
    private Action<string> handleAnswerClick;

    // Метод DisplayQuestion отображает вопрос и случайные ответы.
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

    // Метод SetAnswerClickHandler устанавливает обработчик нажатия на кнопку ответа.
    public void SetAnswerClickHandler(Action<string> buttonHandler)
    {
        handleAnswerClick = buttonHandler;
    }

    // Метод Show управляет видимостью вопроса.
    public void Show(bool state = true)
    {
        gameObject.SetActive(state);
    }
}
