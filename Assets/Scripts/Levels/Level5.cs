using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class Level5 : BaseAskAnswerLevel
{
    private static readonly string alphabet = "абвгдежзийклмнопрстуфхцчшщъыьэюя";

    protected override void Reset()
    {
        message = Messages.Get();
        string[] words = message.Split(new[] { ' ', '\t', '\n' });
        if (words.Length > 3)
        {
            message = string.Join(" ", words.Take(3));
        }
            
        List<string> keys = GenerateKeys(message.Length); 
        correctKey = keys[0];

        string encryptedMessage = Vernam.Encrypt(message, correctKey); 

        string question = "Расшифровать сообщение (Шифр Вернама)\n" + encryptedMessage; 

        questionAsker.DisplayQuestion(question, keys); 
        questionAsker.SetAnswerClickHandler(HandleAnswerClick); 
    }

    private List<string> GenerateKeys(int length)
    {
        List<string> keys = new List<string>();
        for (int k = 0; k < 4; k++)
        {
            string key = "";
            for (int i = 0; i < length; i++)
            {
                key += alphabet[Random.Range(0, alphabet.Length)]; 
            }
            keys.Add(key); 
        }
        return keys; 
    }

    protected override void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1); 
    }
}
