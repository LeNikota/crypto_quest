using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class Level1 : BaseAskAnswerLevel
{
    protected override void Reset()
    {
        List<string> words = GenerateWords();
        message  = words[0];
        correctKey = words[0];
        string encodedMessage = MorseCode.Encode(message);

        string question = "Расшифровать сообщение (код морзе)\n" + encodedMessage;

        questionAsker.DisplayQuestion(question, words);
        questionAsker.SetAnswerClickHandler(HandleAnswerClick);
    }

    private List<string> GenerateWords()
    {
        List<string> words = new List<string>();

        for (int i = 0; i < 4; i++)
        {
            string word;
            do
            {
                string[] sentence = Regex.Replace(Messages.Get(), @"[^\w\s]", "").Split();

                int j = Random.Range(0, sentence.Length);
                word = sentence[j];
                
            } while (words.Contains(word) || word.Length < 7);

            words.Add(char.ToUpper(word[0]) + word[1..].ToLower());
        }

        return words;
    }

    protected override void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
