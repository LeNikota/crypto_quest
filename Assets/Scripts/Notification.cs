// Класс Notification управляет отображением уведомлений с текстом и кнопкой.

using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Notification : MonoBehaviour
{

	[SerializeField] private TextMeshProUGUI notificationText;// Поле для текста уведомления.
	[SerializeField] private Button notificationButton; // Поле для кнопки уведомления.
	[SerializeField] private TextMeshProUGUI notificationButtonText; // Поле для текста на кнопке уведомления.

	// Метод Notify отображает уведомление с заданным сообщением и текстом кнопки, а также устанавливает обработчик нажатия кнопки.
	public void Notify(string message, string buttonText, Action handleButtonClick)
	{
		gameObject.SetActive(true);
		notificationButton.onClick.RemoveAllListeners();

		notificationText.text = message;
		notificationButtonText.text = buttonText;
		notificationButton.onClick.AddListener(() => handleButtonClick());
	}

	// Метод Show управляет видимостью уведомления.
	public void Show(bool state = true)
	{
		gameObject.SetActive(state);
	}
}
