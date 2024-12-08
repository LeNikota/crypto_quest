using TMPro;
using UnityEngine;


public class ToolsUI : MonoBehaviour
{
    [SerializeField] GameObject toolPanel;
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] TextMeshProUGUI display;
    [SerializeField] TMP_InputField input;

    void Start(){
        OnValueChanged("");
        input.onValueChanged.AddListener(OnValueChanged);
    }

    public void Toggle()
    {
        bool isActive = !canvasGroup.blocksRaycasts;

        canvasGroup.blocksRaycasts = isActive;
        canvasGroup.interactable = isActive;
        canvasGroup.blocksRaycasts = isActive;
        canvasGroup.alpha = isActive ? 1 : 0;
    }

    public void OnValueChanged(string input)
    {
        display.text = "";

        char[] alphabet = "абвгдежзийклмнопрстуфхцчшщъыьэюя".ToCharArray();

        foreach (var c in alphabet)
        {
            display.text += c + " ";
        }

        if (string.IsNullOrEmpty(input) || !int.TryParse(input, out int shift))
            return;
        if(shift > 32)
            return;


        display.text += "\n";
        for (int i = 0; i < alphabet.Length; i++)
        {
            int new_i = (i - shift + alphabet.Length) % alphabet.Length;
            display.text += alphabet[new_i] + " ";
        }
    }
}
