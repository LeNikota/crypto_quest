using UnityEngine;

public abstract class BaseAskAnswerLevel : MonoBehaviour
{
    [SerializeField] protected QuestionAsker questionAsker;
    [SerializeField] protected Notification notification;

    protected string correctKey;
    protected string message;

    protected virtual void Start()
    {
        Reset();
    }

    protected abstract void Reset();

    protected void HandleAnswerClick(string answer)
    {
        questionAsker.Show(false);
        if (answer == correctKey)
        {
            notification.Notify($"Правильно!\n Ключ: {correctKey}\n Сообщение: {message} ", "Далее", LoadNextLevel);
        }
        else
        {
            notification.Notify($"Неправильно!\n Ключ: {correctKey}\n Сообщение: {message} ", "Снова", StartAgain);
        }
    }

    protected void StartAgain()
    {
        questionAsker.Show();
        notification.Show(false);
        Reset();
    }

    protected abstract void LoadNextLevel();
}
