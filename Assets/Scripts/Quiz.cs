using System;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quiz : MonoBehaviour
{
    [SerializeField] QuestionAsker questionAsker;
    [SerializeField] Notification notification;

    int questionCount = 0;
    string question;
    string correctAnswer;

    void Start()
    {
        ResetQuiz();
    }

    void LoadNextQuestion(){
        if(questionCount >= 5)
            SceneManager.LoadScene("Main menu");

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
        }
        else
        {
            notification.Notify(
                $"Ответ неправильный!\n\n{question}\n\n{correctAnswer}",
                "Далее", ResetQuiz
            );
        }
    }

    void ResetQuiz()
    {
        questionAsker.Show();
        notification.Show(false);
        LoadNextQuestion();
    }
}