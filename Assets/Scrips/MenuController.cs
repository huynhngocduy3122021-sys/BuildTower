using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void StartGame()
    {
        loadingController.LoadScene("GamePlay");
    }

    public void ExitGame()
    {
        Debug.Log("Quit Game Clicked");

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}
