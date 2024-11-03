using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public List<GameObject> extinquisherEmpty;
    public List<GameObject> extinquisherFull;
    
    
    private int _extinguisher;
    private int _key = 1;

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
        foreach (var g in extinquisherFull)
        {
            g.SetActive(false);
        }
    }

    public void AddExtinguisher()
    {
        if(_extinguisher >= extinquisherFull.Count)
            return;
        
        _extinguisher++;
        SetExtinquisherUI();
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

#endregion
}
