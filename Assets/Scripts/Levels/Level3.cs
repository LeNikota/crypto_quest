using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Level3 : BaseAskAnswerLevel
{
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

    protected override void Reset()
    {
        List<string> keys = GenerateKeys();
        correctKey = keys[0];
        message = Messages.Get();
        string encryptedMessage = Vigenere.Encrypt(message, correctKey);

        questionAsker.DisplayQuestion(encryptedMessage, keys);
        questionAsker.SetAnswerClickHandler(HandleAnswerClick);
    }

    private List<string> GenerateKeys()
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

    protected override void LoadNextLevel()
    {
        SceneManager.LoadScene("Main menu");
    }
}
