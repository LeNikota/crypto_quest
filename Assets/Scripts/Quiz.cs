using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quiz : MonoBehaviour
{
    [SerializeField] QuestionAsker questionAsker;
    [SerializeField] Notification notification;
    [SerializeField] ConfirmationDialog dialog;

    [SerializeField] GameObject timerDisplay;
    [SerializeField] TextMeshProUGUI timerText;

    bool limitByTime = false;
    float timer = 30f;

    int questionCount = 0;
    int correctAnswerCount = 0;
    string question;
    string correctAnswer;

    void Start()
    {
        dialog.Show("Ограничить тест по времени?", HandleDialogButtonClick);
    }

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

    void LoadNextQuestion()
    {
        questionCount++;

        QuizQuestions.Get(out string question, out string[] answers);
        questionAsker.DisplayQuestion(question, answers.ToList());
        questionAsker.SetAnswerClickHandler(HandleAnswerButtonClick);

        this.question = question;
        // First answer is the correct one
        correctAnswer = answers[0];
    }

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

    void HandleDialogButtonClick(bool state)
    {
        ResetQuiz();
        if (!state)
            return;

        limitByTime = true;
        timerDisplay.SetActive(true);
    }

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
