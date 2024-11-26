using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.Mathematics;
using UnityEngine.SceneManagement;


class Question
{
    public string QuestionText;
    private List<string> Answers;
    
    // The first answer in the list is correct one
    public Question(string questionText, List<string> answers)
    {
        QuestionText = questionText;
        Answers = new List<string>(answers);
    }

    public List<string> GetAnswers() {
        System.Random random_number_generator = new System.Random();
        List<string> shuffledAnswers = new List<string>(Answers);
        int size = 4;

        while (size > 1)
        {
            int index = random_number_generator.Next(size--);
            
            // Swap the elements at size and index
            (shuffledAnswers[index], shuffledAnswers[size]) = (shuffledAnswers[size], shuffledAnswers[index]);
        }

        return shuffledAnswers;
    }

    public bool CheckAnswer(string answer) {
        return Answers[0] == answer;
    }

    public string GetCorrectAnswer(){
        return Answers[0];
    }

    public string GetQuestion(){
        return QuestionText;
    }
}


public class Quiz : MonoBehaviour
{
    public TextMeshProUGUI questionDisplay;
    public GameObject NotificationPanel;
    public TextMeshProUGUI NotificationPanelText;

    public Button[] answerButtons = new Button[4];
    public TextMeshProUGUI[] answerButtonsText = new TextMeshProUGUI[4];

    Question currentQuestion;
    List<Question> questions = new List<Question>
    {
        new Question("Кто впервые использовал шифр Цезаря?", new List<string> { "Юлий Цезарь", "Платон", "Аристотель", "Александр Великий" }),
        new Question("Какой тип шифрования представляет собой шифр Цезаря?", new List<string> { "Симметричный шифр", "Асимметричный шифр", "Хеширование", "Шифр перестановки" }),
        // new Question("Какой максимальный сдвиг можно использовать в шифре Цезаря?", new List<string> { "25", "26", "24", "20" }),
        // new Question("Какой язык использовал шифр Цезаря в военных сообщениях?", new List<string> { "Латинский", "Греческий", "Арабский", "Китайский" }),
        // new Question("Какой из следующих шифров является более сложным, чем шифр Цезаря?", new List<string> { "Шифр Виженера", "Шифр Атбаш", "ROT13", "Шифр подстановки" }),
        // new Question("Каков результат шифрования слова 'HELLO' с помощью сдвига 5?", new List<string> { "MJQQT", "KHOOR", "OLLEH", "WORLD" }),
        // new Question("Что делает шифр Цезаря уязвимым для криптоанализа?", new List<string> { "Ограниченное количество возможных сдвигов", "Использование длинных ключей", "Сложность алгоритма", "Частотный анализ" }),
        new Question("Какой современный метод шифрования является развитием идей, заложенных в шифре Цезаря?", new List<string> { "AES", "RSA", "DES", "Blowfish" })
    };


    void AskQuestion()
    {
        int index = UnityEngine.Random.Range(0, questions.Count);

        currentQuestion = questions[index];
        questions.RemoveAt(index);

        questionDisplay.text = currentQuestion.GetQuestion();
        List<string> answers = currentQuestion.GetAnswers();

        for (int i = 0; i < 4; i++)
        {
            string answer = answers[i];

            answerButtonsText[i].text = answer;
            answerButtons[i].onClick.RemoveAllListeners();
            answerButtons[i].onClick.AddListener(() => OnAnswerClick(answer));

        }
    }

    void OnAnswerClick(string answer)
    {
        NotificationPanel.SetActive(true);

        if(currentQuestion.CheckAnswer(answer)){
            NotificationPanelText.text = $"Правильно:\n{answer}";
        } else {
            NotificationPanelText.text = $"Не правильно:\n{currentQuestion.GetCorrectAnswer()}";
        }
    }

    public void Continue()
    {
        if(questions.Count == 0){
            SceneManager.LoadSceneAsync(0);
            return;
        }

        NotificationPanel.SetActive(false);
        AskQuestion();
    }
    
    void Start()
    {
        AskQuestion();
    }
}
