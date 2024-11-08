using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void StartScene()
    {
        SceneManager.LoadScene(2);
    }

  /*  public void QuitButton() {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    
    }*/
}
