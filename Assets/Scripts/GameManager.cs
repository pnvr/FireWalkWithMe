using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    private int _extinguisher;
    private int _key;

    private void Awake()
    {
        if (Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void AddExtinguisher()
    {
        _extinguisher++;
    }

    public bool CheckExtinguisher()
    {
        return _extinguisher == 1;
    }
    
    public void UseExtinguisher()
    {
        _extinguisher--;
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
}
