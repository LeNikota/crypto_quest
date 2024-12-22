// Класс ToolsUI управляет пользовательским интерфейсом инструментов шифрования и дешифрования.

using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ToolsUI : MonoBehaviour
{
    // Поле для группы канваса, управляющего видимостью интерфейса.
    [SerializeField] CanvasGroup canvasGroup;
    // Поле для содержимого прокручиваемого представления.
    [SerializeField] GameObject scrollViewContent;

    // Поля для отображения текста и ввода данных.
    [SerializeField] TextMeshProUGUI display;
    [SerializeField] TMP_InputField inputText;
    [SerializeField] TMP_InputField inputKey;

    // Обработчики событий для нажатий кнопок и изменения значений.
    Action<string> cypherButtonClickHandler;
    Action<string, string> valueChangedHandler;

    // Свойство для установки обработчика нажатия кнопки шифрования.
    public Action<string> CypherButtonClickHandler
    {
        get => cypherButtonClickHandler;
        set => cypherButtonClickHandler = value;
    }

    // Свойство для установки обработчика изменения значений.
    public Action<string, string> ValueChangedHandler
    {
        get => valueChangedHandler;
        set => valueChangedHandler = value;
    }

    // Метод Start инициализирует обработчики событий для кнопок и полей ввода.
    void Start()
    {
        Button[] buttons = scrollViewContent.GetComponentsInChildren<Button>();
        foreach (var button in buttons)
            button.onClick.AddListener(() => cypherButtonClickHandler?.Invoke(button.name));

        inputText.onValueChanged.AddListener((input) => valueChangedHandler?.Invoke(input, "text"));
        inputKey.onValueChanged.AddListener((input) => valueChangedHandler?.Invoke(input, "key"));

        // Clear test text
        display.text = "";
    }

    // Метод Toggle переключает видимость интерфейса.
    public void Toggle()
    {
        bool isActive = !canvasGroup.blocksRaycasts;

        canvasGroup.blocksRaycasts = isActive;
        canvasGroup.interactable = isActive;
        canvasGroup.blocksRaycasts = isActive;
        canvasGroup.alpha = isActive ? 1 : 0;
    }

    // Метод Display отображает оригинальное и зашифрованное сообщение с ключом.
    public void Display(string originalMessage, string alteredMessage, string key)
    {
        display.text = $"Оригинал: {originalMessage}\nЗашифрованый текст: {alteredMessage}\nКлюч: {key}";
    }

    // Перегруженный метод Display отображает оригинальное и зашифрованное сообщение без ключа.
    public void Display(string originalMessage, string alteredMessage)
    {
        display.text = $"Оригинал: {originalMessage}\nЗашифрованый текст: {alteredMessage}";
    }
}
