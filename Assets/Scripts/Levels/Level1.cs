using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1 : MonoBehaviour
{
    [SerializeField] private QuestionAsker questionAsker;
    [SerializeField] private Notification notification;

    void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
        // Example question and answers
        string question = "What is the capital of France?";
        string[] answers = { "Berlin", "Madrid", "Paris", "Rome" };

        // Display the question
        questionAsker.DisplayQuestion(question, answers);

        // Set the answer click handler
        questionAsker.SetAnswerClickHandler(HandleAnswerClick);
    }

    private void HandleAnswerClick(string answer)
    {
        // Logic to handle the answer click
        if (answer == "Paris")
        {
            notification.Notify("Correct!", "Next Question", HandleNextQuestion);
        }
        else
        {
            notification.Notify("Incorrect! Try again.", "Retry", () => { /* Optionally retry logic */ });
        }
    }

    private void HandleNextQuestion()
    {
        // Logic to load the next question
        // For example, you could call StartGame() again with new questions
    }

    // TODO: Separate this functionality into another class, like pause menu
    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
}
