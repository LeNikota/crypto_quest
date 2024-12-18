using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Level4 : BaseAskAnswerLevel
{
    private (string key, Func<int, int> shiftFunc)[] keys = {
        ("2k + 1", position => 2 * position + 1),
        ("k^2", position => position * position),
        ("2k + k", position => 2 * position + position),
        ("3k", position => 3 * position),
        ("k + 5", position => position + 5),
        ("k^3", position => position * position * position),
        ("k * (k + 1)", position => position * (position + 1)),
        ("k^2 + 2k", position => position * position + 2 * position),
        ("k * 2", position => position * 2),
        ("k + 10", position => position + 10),
        ("k^2 - k", position => position * position - position),
        ("k * 3 + 1", position => 3 * position + 1),
        ("k^2 + 1", position => position * position + 1),
        ("k * (k - 1)", position => position * (position - 1)),
        ("5k", position => 5 * position),
        ("k^2 + 3k + 2", position => position * position + 3 * position + 2),
        ("k * 4", position => 4 * position),
        ("k^2 + 4", position => position * position + 4),
        ("k + k^2", position => position + position * position),
        ("k^2 + 5k", position => position * position + 5 * position),
        ("k * (k + 2)", position => position * (position + 2)),
    };

    protected override void Reset()
    {
        var keys = GenerateKeys();
        var selectedKey = keys[0];
        correctKey = selectedKey.key;
        Func<int, int> shiftFunc = selectedKey.shiftFunc;

        message = Messages.Get();
        string encryptedMessage = Trithemius.Encrypt(message, shiftFunc);

        string question = "Расшифровать сообщение (Тритемий)\n" + encryptedMessage;

        questionAsker.DisplayQuestion(question, keys.Select(k => k.key).ToList());
        questionAsker.SetAnswerClickHandler(HandleAnswerClick);
    }

    private List<(string key, Func<int, int> shiftFunc)> GenerateKeys()
    {
        List<(string key, Func<int, int> shiftFunc)> selectedKeys = new List<(string key, Func<int, int> shiftFunc)>();
        HashSet<int> selectedIndices = new HashSet<int>();

        while (selectedKeys.Count < 4)
        {
            int index = UnityEngine.Random.Range(0, keys.Length);
            if (!selectedIndices.Contains(index))
            {
                selectedKeys.Add(keys[index]);
                selectedIndices.Add(index);
            }
        }

        return selectedKeys;
    }

    protected override void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
