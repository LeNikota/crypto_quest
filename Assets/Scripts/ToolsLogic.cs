using UnityEngine;


class ToolsLogic : MonoBehaviour
{
    [SerializeField] ToolsUI toolsUI;

    void Start(){
        toolsUI.CypherButtonClickHandler = HandelCypherButtonClick;
    }

    void HandelCypherButtonClick(string cypher)
    {
        switch (cypher)
        {
            case "Caesar":
                break;
            // case "":
            //     break;
            // case "":
            //     break;
        }

        // display.text = "";

        // char[] alphabet = "абвгдежзийклмнопрстуфхцчшщъыьэюя".ToCharArray();

        // foreach (var c in alphabet)
        // {
        //     display.text += c + " ";
        // }

        // if (string.IsNullOrEmpty(input) || !int.TryParse(input, out int shift))
        //     return;
        // if(shift > 32)
        //     return;


        // display.text += "\n";
        // for (int i = 0; i < alphabet.Length; i++)
        // {
        //     int new_i = (i - shift + alphabet.Length) % alphabet.Length;
        //     display.text += alphabet[new_i] + " ";
        // }
    }
}
