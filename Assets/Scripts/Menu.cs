using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void StartScene()
    {
        SceneManager.LoadScene(1);
    }

    public void ShowControls()
    {
        // Show controls
    }

    public void ShowCredits()
    {
        // Show credits
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
