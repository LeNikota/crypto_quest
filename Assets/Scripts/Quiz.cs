// Класс Quiz управляет логикой викторины, включая отображение вопросов, обработку ответов и управление временем.

using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quiz : MonoBehaviour
{
    // Поле для управления вопросами.
    [SerializeField] QuestionAsker questionAsker;
    // Поле для уведомлений.
    [SerializeField] Notification notification;
    // Поле для диалогового окна подтверждения.
    [SerializeField] ConfirmationDialog dialog;
    // Поле для отображения таймера.
    [SerializeField] GameObject timerDisplay;
    // Поле для текста таймера.
    [SerializeField] TextMeshProUGUI timerText;

    // Переменная для ограничения времени.
    bool limitByTime = false;
    
    // Таймер для отслеживания времени.
    float timer = 30f;

    // Счетчик вопросов и правильных ответов.
    int questionCount = 0;
    int correctAnswerCount = 0;
    
    // Переменные для текущего вопроса и правильного ответа.
    string question;
    string correctAnswer;

    // Метод Start инициализирует викторину и показывает диалоговое окно.
    void Start()
    {
        dialog.Show("Ограничить тест по времени?", HandleDialogButtonClick);
    }

    // Метод Update обновляет таймер и проверяет время.
    void Update()
    {
        if (!limitByTime)
            return;

        if (timer > 0)
        {
            timer -= Time.deltaTime;
            timerText.text = ((int)timer).ToString();
            return;
        }

        questionAsker.Show(false);
        timerDisplay.SetActive(false);
        notification.Notify($"Время вышло!\n\nБыло дано {correctAnswerCount} правильных ответов", "Меню", () => SceneManager.LoadScene("Main menu"));
    }

    // Метод LoadNextQuestion загружает следующий вопрос и отображает его.
    void LoadNextQuestion()
    {
        questionCount++;

        QuizQuestions.Get(out string question, out string[] answers);
        questionAsker.DisplayQuestion("Ответь правильно", question, answers.ToList());
        questionAsker.SetAnswerClickHandler(HandleAnswerButtonClick);

        this.question = question;
        // First answer is the correct one
        correctAnswer = answers[0];
    }

    // Метод HandleAnswerButtonClick обрабатывает нажатие на кнопку ответа.
    void HandleAnswerButtonClick(string answer)
    {
        questionAsker.Show(false);
        if (answer == correctAnswer)
        {
            notification.Notify(
                $"Ответ правильный!\n\n{question}\n\n{correctAnswer}",
                "Далее", ResetQuiz
            );
            correctAnswerCount++;
        }
        else
        {
            notification.Notify(
                $"Ответ неправильный!\n\n{question}\n\n{correctAnswer}",
                "Далее", ResetQuiz
            );
        }
    }

    // Метод HandleDialogButtonClick обрабатывает нажатие кнопки в диалоговом окне.
    void HandleDialogButtonClick(bool state)
    {
        ResetQuiz();
        if (!state)
            return;

        limitByTime = true;
        timerDisplay.SetActive(true);
    }

    // Метод ResetQuiz сбрасывает викторину и загружает новый вопрос.
    void ResetQuiz()
    {
        if (questionCount >= 5)
        {
            timerDisplay.SetActive(false);
            questionAsker.Show(false);
            notification.Notify($"Вопросы закончились!\n\nБыло дано {correctAnswerCount} правильных ответов", "Меню", () => SceneManager.LoadScene("Main menu"));
            return;
        }

        notification.Show(false);
        questionAsker.Show();
        LoadNextQuestion();
    }
}
