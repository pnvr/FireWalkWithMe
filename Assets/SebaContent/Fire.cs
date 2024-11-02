using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] private float igniteTime = 2f;
    //[SerializeField] private 
    private float timer = 0f;
    private bool active = false;

    public void Reset()
    {

    }

    public void _Start()
    {
        
    }

    private void Update()
    {
        if (active)
            return;

        if (timer <= 0)
        {
            
        }
    }

    
}
