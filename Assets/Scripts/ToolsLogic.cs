// Класс ToolsLogic управляет логикой инструментов шифрования и дешифрования, взаимодействуя с пользовательским интерфейсом.

using System;
using UnityEngine;


class ToolsLogic : MonoBehaviour
{
    // Поле для пользовательского интерфейса инструментов.
    [SerializeField] ToolsUI toolsUI;

    // Действие, представляющее выбранный инструмент.
    Action selectedTool = null;

    // Переменные для хранения текста и ключа.
    string text;
    string key;

    // Метод Start инициализирует обработчики событий для кнопок и изменения значений.
    void Start()
    {
        toolsUI.CypherButtonClickHandler = HandelCypherButtonClick;
        toolsUI.ValueChangedHandler = HandleValueChanged;
    }

    // Метод HandelCypherButtonClick обрабатывает нажатие кнопки шифрования и устанавливает выбранный инструмент.
    void HandelCypherButtonClick(string cypher)
    {
        switch (cypher)
        {
            case "Morse":
                selectedTool = DecryptMorse;
                break;
            case "Caesar":
                selectedTool = DecryptCaesar;
                break;
            case "Vigenere":
                selectedTool = DecryptVigenere;
                break;
            case "Trithemius":
                selectedTool = DecryptTrithemius;
                break;
            case "Vernam":
                selectedTool = DecryptVernam;
                break;
            case "Atbash":
                selectedTool = DecryptAtbash;
                break;
        }
    }

    // Метод HandleValueChanged обрабатывает изменения входных данных и вызывает выбранный инструмент.
    void HandleValueChanged(string input, string type)
    {
        if (type == "text") text = input;
        else key = input;

        selectedTool?.Invoke();
    }

    void DecryptCaesar()
    {
        if (!int.TryParse(key, out int shift))
            return;
        if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(key))
            return;

        string result = Caesar.Decrypt(text, shift);
        toolsUI.Display(text, result, key);
    }

    void DecryptMorse()
    {
        if (string.IsNullOrEmpty(text))
            return;

        string result = MorseCode.Decode(text);
        toolsUI.Display(text, result);
    }

    void DecryptVigenere()
    {
        if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(key))
            return;

        string result = Vigenere.Decrypt(text, key);
        toolsUI.Display(text, result, key);
    }

    void DecryptTrithemius()
    {
        if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(key))
            return;

        Func<int, int> shiftFunction = Trithemius.GetShiftFunction(key);
        if (shiftFunction == null)
            return;

        string result = Trithemius.Decrypt(text, shiftFunction);
        toolsUI.Display(text, result, key);
    }

    void DecryptVernam()
    {
        if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(key))
            return;

        string result = Vernam.Decrypt(text, key);
        toolsUI.Display(text, result, key);
    }

    void DecryptAtbash()
    {
        if (string.IsNullOrEmpty(text))
            return;

        string result = Atbash.Decrypt(text);
        toolsUI.Display(text, result);
    }
}
