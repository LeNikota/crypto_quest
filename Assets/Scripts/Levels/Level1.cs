using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.CodeDom.Compiler;

public class Level1 : MonoBehaviour
{
    [SerializeField] private QuestionAsker questionAsker;
    [SerializeField] private Notification notification;

    private Caesar caesar = new Caesar();

    private string[] messages = {
        "Дошел шестой легион.",
        "Враг на подходе, готовьтесь к бою!",
        "Мы должны укрепить наши позиции.",
        "Слухи о восстании требуют нашего внимания.",
        "Победа будет за нами, если мы будем едины.",
        "Не забывайте о своих товарищах на поле боя."
    };
    string correctKey;
    string message;

    void Start()
    {
        Reset();
    }

    private void Reset()
    {
        List<string> keys = GeneratedKeys();
        correctKey = keys[0];
        message = messages[Random.Range(0, messages.Length)];
        string encryptedMessage = caesar.Encrypt(message, int.Parse(correctKey));

        questionAsker.DisplayQuestion(encryptedMessage, keys);
        questionAsker.SetAnswerClickHandler(HandleAnswerClick);
    }

    private List<string> GeneratedKeys()
    {
        List<string> keys = new List<string>();
        for (int i = 0; i < 4; i++)
        {
            // do-while is used to avoid repetition in answers
            string currentKey;
            do
            {
                currentKey = Random.Range(1, 32).ToString();
            } while (keys.Contains(currentKey));
            keys.Add(currentKey);
        }

        return keys;
    }

    private void HandleAnswerClick(string answer)
    {
        questionAsker.Show(false);
        if (answer == correctKey)
        {
            notification.Notify($"Правильно!\n Ключ {correctKey}\n Сообщение: {message} ", "Далее", LoadNextLevel);
        }
        else
        {
            notification.Notify($"Неправильно!\n Ключ {correctKey}\n Сообщение: {message} ", "Снова", StartAgain);
        }
    }

    private void StartAgain()
    {
        questionAsker.Show();
        notification.Show(false);
        Reset();
    }
    private void LoadNextLevel()
    {
        SceneManager.LoadScene("Level2");
    }
}
