using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ToolsUI : MonoBehaviour
{
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] GameObject scrollViewContent;

    [SerializeField] TextMeshProUGUI display;
    [SerializeField] TMP_InputField inputText;
    [SerializeField] TMP_InputField inputKey;

    Action<string> cypherButtonClickHandler;
    Action<string, string> valueChangedHandler;

    public Action<string> CypherButtonClickHandler
    {
        get => cypherButtonClickHandler;
        set => cypherButtonClickHandler = value;
    }
    public Action<string, string> ValueChangedHandler 
    {
        get => valueChangedHandler;
        set => valueChangedHandler = value;
    }


    void Start()
    {
        Button[] buttons = scrollViewContent.GetComponentsInChildren<Button>();
        foreach (var button in buttons)
            button.onClick.AddListener(() => cypherButtonClickHandler?.Invoke(button.name));

        inputText.onValueChanged.AddListener((input) => valueChangedHandler?.Invoke(input,"text"));
        inputKey.onValueChanged.AddListener((input) => valueChangedHandler?.Invoke(input, "key"));

        // Clear test text
        display.text = "";
    }

    public void Toggle()
    {
        bool isActive = !canvasGroup.blocksRaycasts;

        canvasGroup.blocksRaycasts = isActive;
        canvasGroup.interactable = isActive;
        canvasGroup.blocksRaycasts = isActive;
        canvasGroup.alpha = isActive ? 1 : 0;
    }

    public void Display(string originalMessage, string alteredMessage, string key)
    {
        display.text = $"Оригинал: {originalMessage}\nЗашифрованый текст: {alteredMessage}\nКлюч: {key}";
    }

    public void Display(string originalMessage, string alteredMessage)
    {
        display.text = $"Оригинал: {originalMessage}\nЗашифрованый текст: {alteredMessage}";
    }
}
