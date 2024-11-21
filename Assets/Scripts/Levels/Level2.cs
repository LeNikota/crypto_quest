using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Level2 : MonoBehaviour
{
    [SerializeField] private QuestionAsker questionAsker;
    [SerializeField] private Notification notification;

    private Vigenere vigenere = new Vigenere(); // Change to Vigenere

    private string[] messages = {
        "Дошел шестой легион.",
        "Враг на подходе, готовьтесь к бою!",
        "Мы должны укрепить наши позиции.",
        "Слухи о восстании требуют нашего внимания.",
        "Победа будет за нами, если мы будем едины.",
        "Не забывайте о своих товарищах на поле боя."
    };
    private string[] keys = {
        "Сила",
        "Мудрость",
        "Свобода",
        "Дружба",
        "Сингулярность",
        "Свет",
        "Тьма",
        "Знание",
        "Смелость",
        "Надежда",
        "Любовь",
        "Счастье",
        "Терпение",
        "Справедливость",
        "Мир",
        "Судьба",
        "Вера",
        "Творчество",
        "Успех",
        "Секрет",
        "Гармония",
        "Сила воли",
        "Доброта",
        "Тайна",
        "Энергия",
        "Вдохновение",
        "Понимание",
        "Согласие",
        "Сострадание",
        "Радость",
        "Умиротворение",
        "Стратегия",
        "Поток",
        "Потенциал",
        "Эволюция"
    };

    private string correctKey;
    private string message;

    void Start()
    {
        Reset();
    }

    private void Reset()
    {
        List<string> keys = GeneratedKeys();
        correctKey = keys[0]; // Use the first key as the correct key
        message = messages[Random.Range(0, messages.Length)];
        string encryptedMessage = vigenere.Encrypt(message, correctKey); // Use Vigenere encryption

        questionAsker.DisplayQuestion(encryptedMessage, keys);
        questionAsker.SetAnswerClickHandler(HandleAnswerClick);
    }

    private List<string> GeneratedKeys()
    {
        List<string> selectedKeys = new List<string>();
        for (int i = 0; i < 4; i++)
        {
            // Randomly select a key from the predefined array
            string currentKey;
            do
            {
                currentKey = keys[Random.Range(0, keys.Length)];
            } while (selectedKeys.Contains(currentKey));
            selectedKeys.Add(currentKey);
        }

        return selectedKeys;
    }


    private void HandleAnswerClick(string answer)
    {
        questionAsker.Show(false);
        if (answer == correctKey)
        {
            notification.Notify($"Правильно!\n Ключ: {correctKey}\n Сообщение: {message} ", "Далее", LoadNextLevel);
        }
        else
        {
            notification.Notify($"Неправильно!\n Ключ: {correctKey}\n Сообщение: {message} ", "Снова", StartAgain);
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
        SceneManager.LoadScene("Main menu");
        // SceneManager.LoadScene("Level3");
    }
}

// TODO: Make so the level123.. code is not repeated, make it into one script and just add gameManager or something