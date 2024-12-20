using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System;
using System.Linq;

public class LevelManager : MonoBehaviour
{

    [SerializeField] QuestionAsker questionAsker;
    [SerializeField] Notification notification;

    Action[] levels;
    Action currentLevel = null;

    int level = 1;
    string correctAnswer;
    string message;

    void Start()
    {
        levels = new Action[] { null, Level1, Level2, Level3, Level4, Level5, Level6 };
        
        level = PlayerPrefs.GetInt("Level");
        LoadLevel(level);
    }

    // Morse code
    void Level1()
    {
        List<string> words = Messages.GetWords(4);

        message = words[0];
        correctAnswer = words[0];

        string encodedMessage = MorseCode.Encode(message);

        questionAsker.DisplayQuestion("Декодируй код морзе", encodedMessage, words);
        questionAsker.SetAnswerClickHandler(HandleAnswerClick);
    }
    // Caeser
    void Level2()
    {
        List<string> keys = Caesar.GetKeys(4);
        correctAnswer = keys[0];

        message = Messages.Get();
        string encryptedMessage = Caesar.Encrypt(message, int.Parse(correctAnswer));

        questionAsker.DisplayQuestion("Расшифруй шифр Цезаря", encryptedMessage, keys);
        questionAsker.SetAnswerClickHandler(HandleAnswerClick);
    }
    // Vigener
    void Level3()
    {
        List<string> keys = Messages.GetWords(4);
        correctAnswer = keys[0];

        message = Messages.Get();
        string encryptedMessage = Vigenere.Encrypt(message, correctAnswer);

        questionAsker.DisplayQuestion("Расшифруй шифр Виженера", encryptedMessage, keys);
        questionAsker.SetAnswerClickHandler(HandleAnswerClick);
    }
    // Trithemius
    void Level4()
    {
        var keys = Trithemius.GetKeys(4);
        var (key, shiftFunction) = keys.ElementAt(0);
        correctAnswer = key;

        message = Messages.Get();
        string encryptedMessage = Trithemius.Encrypt(message, shiftFunction);

        questionAsker.DisplayQuestion("Расшифруй шифр Тритемий", encryptedMessage, keys.Keys.ToList());
        questionAsker.SetAnswerClickHandler(HandleAnswerClick);
    }
    // Vernam
    void Level5()
    {
        message = Vernam.GetMessage();

        List<string> keys = Vernam.GetKeys(4, message.Length);
        correctAnswer = keys[0];

        string encryptedMessage = Vernam.Encrypt(message, correctAnswer);

        questionAsker.DisplayQuestion("Расшифруй шифр Вернама", encryptedMessage, keys);
        questionAsker.SetAnswerClickHandler(HandleAnswerClick);
    }
    // Atbash
    void Level6()
    {
        List<string> answers = Messages.GetWords(4);
        correctAnswer = answers[0];

        string encryptedMessage = Atbash.Encrypt(correctAnswer);

        questionAsker.DisplayQuestion("Расшифруй шифр Атбаш", encryptedMessage, answers);
        questionAsker.SetAnswerClickHandler(HandleAnswerClick);
    }

    void HandleAnswerClick(string answer)
    {
        questionAsker.Show(false);

        bool isAnswerCorrect = answer == correctAnswer;
        string notificationMessage = (isAnswerCorrect ? "Правильно!" : "Неправильно!") +
                                     $"\nКлюч: {correctAnswer}" +
                                     $"\nСообщение: {message}";
        Action nextAction = isAnswerCorrect ? () => LoadLevel(++level) : StartAgain;

        notification.Notify(notificationMessage, "Далее", nextAction);
    }

    void StartAgain()
    {
        questionAsker.Show();
        notification.Show(false);
        currentLevel();
    }

    void LoadLevel(int level)
    {
        if (0 < level && level < levels.Length)
        {
            currentLevel = levels[level];
            StartAgain();
        }
        else
        {
            SceneManager.LoadScene("Main menu");
        }
    }
}
