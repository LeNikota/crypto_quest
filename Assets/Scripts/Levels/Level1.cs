using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.CodeDom.Compiler;

public class Level1 : BaseAskAnswerLevel
{
    protected override void Reset()
    {
        List<string> keys = GeneratedKeys();
        correctKey = keys[0];
        message = Messages.Get();
        string encryptedMessage = Caesar.Encrypt(message, int.Parse(correctKey));

        questionAsker.DisplayQuestion(encryptedMessage, keys);
        questionAsker.SetAnswerClickHandler(HandleAnswerClick);
    }

    private List<string> GeneratedKeys()
    {
        List<string> keys = new List<string>();
        for (int i = 0; i < 4; i++)
        {
            string currentKey;
            do
            {
                currentKey = Random.Range(1, 32).ToString();
            } while (keys.Contains(currentKey));
            keys.Add(currentKey);
        }

        return keys;
    }

    protected override void LoadNextLevel()
    {
        SceneManager.LoadScene("Level2");
    }
}