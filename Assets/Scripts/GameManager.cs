using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public List<GameObject> extinquisherEmpty;
    public List<GameObject> extinquisherFull;

    public GameObject controls;
    public GameObject credits;
    
    private int _extinguisher;
    private int _key;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        if(extinquisherFull != null)
            foreach (var g in extinquisherFull)
            {
                g.SetActive(false);
            }
        
        if(controls != null)
            controls.SetActive(false);
        
        if (credits != null)
            credits.SetActive(false);
    }

    public void AddExtinguisher()
    {


        for ( int i = 0; i < extinquisherFull.Count; i++ )
        {
            if ( _extinguisher >= extinquisherFull.Count )
                return;
            _extinguisher++;
            SetExtinquisherUI();
        }
    }

    public bool CheckExtinguisher()
    {
        return _extinguisher > 0;
    }
    
    public void UseExtinguisher()
    {
        if(_extinguisher < 1)
            return;
        
        _extinguisher--;
        SetExtinquisherUI();
    }
    
    public void AddKey()
    {
        _key++;
    }

    public bool CheckKey()
    {
        return _key > 0;
    }
    
    public void UseKey()
    {
        _key--;
    }
    public void StartScene()
    {
        SceneManager.LoadScene(1);
    }
    public void Death()
    {
        Debug.Log("Death");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
#region UI

    void SetExtinquisherUI()
    {
        for (int i = 0; i < extinquisherFull.Count; i++)
        {
            if(_extinguisher > i)
                extinquisherFull[i].SetActive(true);
            else
            {
                extinquisherFull[i].SetActive(false);
            }
        }
    }

    public void Controls(bool show)
    {
        controls.SetActive(show);
    }

    public void Credits(bool show)
    {
        credits.SetActive(show);
    }
    
#endregion
}
