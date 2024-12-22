/*
Этот файл содержит реализацию диалогового окна подтверждения для пользовательского интерфейса в Unity.
Класс ConfirmationDialog предоставляет методы для отображения диалогового окна с сообщением и кнопками "Да" и "Нет".
Методы:
- Show(string message, Action<bool> handleButtonClick): отображает диалоговое окно с заданным сообщением и обрабатывает нажатия кнопок.
- Show(bool state = true): включает или выключает диалоговое окно в зависимости от переданного состояния.
*/

using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ConfirmationDialog : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI dialogText; // Текстовое поле для отображения сообщения
	[SerializeField] private Button yesButton; // Кнопка "Да"
	[SerializeField] private Button noButton; // Кнопка "Нет"

	// Метод для отображения диалогового окна с сообщением и обработкой нажатий кнопок
	public void Show(string message, Action<bool> handleButtonClick)
	{
		gameObject.SetActive(true);

		dialogText.text = message;

		yesButton.onClick.RemoveAllListeners();
		noButton.onClick.RemoveAllListeners();
		yesButton.onClick.AddListener(() =>
		{
			handleButtonClick(true);
			gameObject.SetActive(false);
		});
		noButton.onClick.AddListener(() =>
		{
			handleButtonClick(false);
			gameObject.SetActive(false);
		});
	}
	
	// Метод для включения или выключения диалогового окна
	public void Show(bool state = true)
	{
		gameObject.SetActive(state);
	}
}
