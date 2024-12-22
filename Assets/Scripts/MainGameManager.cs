// Класс LevelManager управляет уровнями игры, связанными с шифрованием и дешифрованием сообщений.
// Он отвечает за инициализацию уровней, отображение вопросов игроку, обработку ответов и переход между уровнями.
// Уровни включают различные методы шифрования, такие как шифр Морзе, шифр Цезаря, шифр Виженера, шифр Тритемия, шифр Вернама и шифр Атбаш.
// Класс использует компоненты QuestionAsker для отображения вопросов и Notification для уведомления игрока о правильности ответов.

using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System;
using System.Linq;

public class LevelManager : MonoBehaviour
{
    [SerializeField] QuestionAsker questionAsker; // Компонент для отображения вопросов игроку
    [SerializeField] Notification notification; // Компонент для отображения уведомлений

    Action[] levels; // Массив действий, представляющих уровни
    Action currentLevel = null; // Текущий уровень

    int level = 1; // Уровень, на котором находится игрок
    string correctAnswer; // Правильный ответ на текущий вопрос
    string message; // Сообщение, связанное с текущим вопросом

    // Метод Start вызывается при инициализации объекта. Он загружает уровень из PlayerPrefs и начинает игру.
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

    // Метод HandleAnswerClick обрабатывает нажатие на ответ игрока.
    // Он скрывает вопрос, проверяет правильность ответа и отображает уведомление с результатом.
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

    // Метод перезапускает текущий уровень.
    void StartAgain()
    {
        questionAsker.Show();
        notification.Show(false);
        currentLevel();
    }

    // Метод LoadLevel загружает уровень по указанному номеру.
    // Если уровень вне допустимого диапазона, загружает главное меню.
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
