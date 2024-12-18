using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ConfirmationDialog : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI dialogText;
	[SerializeField] private Button yesButton;
	[SerializeField] private Button noButton;

	public void Show(string message, Action<bool> handleButtonClick)
	{
		gameObject.SetActive(true);

		dialogText.text = message;

        yesButton.onClick.RemoveAllListeners();
		noButton.onClick.RemoveAllListeners();
        yesButton.onClick.AddListener(() => {
			handleButtonClick(true);
			gameObject.SetActive(false);
		});
        noButton.onClick.AddListener(() => {
			handleButtonClick(false);
			gameObject.SetActive(false);
		});
	}

	public void Show(bool state = true)
	{
		gameObject.SetActive(state);
	}
}
