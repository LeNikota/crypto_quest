// Класс MainMenu управляет основным меню игры.
// Он предоставляет методы для загрузки различных сцен, таких как игра, уровни и выход из игры.

using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public void LoadLevel(int level){
        SceneManager.LoadSceneAsync(level);
    }

    public void LoadLevel(string name){
        SceneManager.LoadSceneAsync(name);
    }

    public void LoadMainGame(int level){
        PlayerPrefs.SetInt("Level", level);
        PlayerPrefs.Save();

        SceneManager.LoadSceneAsync("Main game");
    }

    public void QuitGame(){
        Application.Quit();
    }
}
