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
    Action<string> inputTextChangedHandler;
    Action<string> inputKeyChangedHandler;
    public Action<string> CypherButtonClickHandler
    {
        get => cypherButtonClickHandler;
        set => cypherButtonClickHandler = value;
    }
    public Action<string> InputTextChangedHandler
    {
        get => inputTextChangedHandler;
        set => inputTextChangedHandler = value;
    }
    public Action<string> InputKeyChangedHandler
    {
        get => inputKeyChangedHandler;
        set => inputKeyChangedHandler = value;
    }

    void Start()
    {
        Button[] buttons = scrollViewContent.GetComponentsInChildren<Button>();
        foreach (var button in buttons)
            button.onClick.AddListener(() => OnCypherButtonClick(button.name));

        inputText.onValueChanged.AddListener(OnInputTextChanged);
        inputKey.onValueChanged.AddListener(OnInputKeyChanged);

    }

    public void Toggle()
    {
        bool isActive = !canvasGroup.blocksRaycasts;

        canvasGroup.blocksRaycasts = isActive;
        canvasGroup.interactable = isActive;
        canvasGroup.blocksRaycasts = isActive;
        canvasGroup.alpha = isActive ? 1 : 0;
    }

    public void OnCypherButtonClick(string input)
    {
        cypherButtonClickHandler?.Invoke(input);
    }

    public void OnInputTextChanged(string input)
    {
        inputTextChangedHandler?.Invoke(input);
    }

    public void OnInputKeyChanged(string input)
    {
        inputKeyChangedHandler?.Invoke(input);
    }

    public void Display(string originalMessage, string alteredMessage)
    {
        display.text = $"{originalMessage}\n\n{alteredMessage}";
    }
}
