using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class Level6 : BaseAskAnswerLevel
{
    private string[] keys = {
        "Сила", "Мудрость", "Свобода", "Дружба", "Сингулярность",
        "Свет", "Тьма", "Знание", "Смелость", "Надежда",
        "Любовь", "Счастье", "Терпение", "Справедливость", "Мир",
        "Судьба", "Вера", "Творчество", "Успех", "Секрет",
        "Гармония", "Доброта", "Тайна", "Энергия",
        "Вдохновение", "Понимание", "Согласие", "Сострадание", "Радость",
        "Умиротворение", "Стратегия", "Поток", "Потенциал", "Эволюция"
    };

    protected override void Reset()
    {
        message = Messages.Get();

        List<string> answers = GenerateAnswers();
        correctKey = answers[0];

        string encryptedMessage = Atbash.Encrypt(message);
        string question = "Расшифровать сообщение (Атбаш)\n" + encryptedMessage;
        questionAsker.DisplayQuestion(question, answers);
        questionAsker.SetAnswerClickHandler(HandleAnswerClick);
    }



    private List<string> GenerateAnswers()
    {
        List<string> answers = new List<string>(4);
        while (answers.Count < 5)
        {
            string randomKey = keys[Random.Range(0, keys.Length)];
            if (!answers.Contains(randomKey))
            {
                answers.Add(randomKey);
            }
        }

        return answers; 
    }

    protected override void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
