using System;
using UnityEngine;


class ToolsLogic : MonoBehaviour
{
    [SerializeField] ToolsUI toolsUI;

    Action selectedTool = null;

    string text;
    string key;

    void Start()
    {
        toolsUI.CypherButtonClickHandler = HandelCypherButtonClick;
        toolsUI.ValueChangedHandler = HandleValueChanged;
    }

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
