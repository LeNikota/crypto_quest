using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public void PlayGame(){
        SceneManager.LoadSceneAsync(1);
    }

    public void LoadLevel(int level){
        SceneManager.LoadSceneAsync(level);
    }

    public void QuitGame(){
        Application.Quit();
    }
}
