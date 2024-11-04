using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public List<GameObject> livesFull;
    public List<GameObject> extinquisherFull;

    public AudioSource [ ] deathAudioSource = new AudioSource [ 3 ];

    private int _extinguisher;
    private int _key;
    private int _lives;
  

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
        _lives = livesFull.Count;

        if (livesFull != null)
            foreach (var g in livesFull) {
                g.SetActive(false);
            }

        SetLivesUI();

        if (extinquisherFull != null)
            foreach (var g in extinquisherFull)
            {
                g.SetActive(false);
            }
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

    public void UseLives()
    { 
        _lives--;
        if ( _lives < 1 )
        {
            Death();
        }
            SetLivesUI();
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
        int rand = Random.Range(0, 3);
        deathAudioSource [ rand ].Play();

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

    void SetLivesUI()
    {
        for ( int i = 0; i < livesFull.Count; i++ )
        {
            Debug.Log(_lives);
            if ( _lives > i )
                livesFull [ i ].SetActive(true);
            else
            {
                livesFull [ i ].SetActive(false);
            }
        }
    }

    
#endregion
}
