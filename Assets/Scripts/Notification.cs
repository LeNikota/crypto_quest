using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Notification : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI notificationText;
	[SerializeField] private Button notificationButton;
	[SerializeField] private TextMeshProUGUI notificationButtonText;

	public void Notify(string message, string buttonText, Action handleButtonClick)
	{
		gameObject.SetActive(true);
		notificationButton.onClick.RemoveAllListeners();

		notificationText.text = message;
		notificationButtonText.text = buttonText;
		notificationButton.onClick.AddListener(() => handleButtonClick());
	}

	public void Show(bool state = true)
	{
		gameObject.SetActive(state);
	}
}
