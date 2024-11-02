using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] private float igniteTime = 2f;
    [SerializeField] private GameObject visual;
    
    private float timer = 0f;
    private bool active = false;

    public void Reset()
    {
        visual.SetActive(false);
        timer = igniteTime;
        active = false;
    }

    public void _Start()
    {
        visual.SetActive(true);
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (active)
            return;

        if (timer <= 0)
        {
            active = true;
        }
    }

    public bool OnFire()
    {
        return (active);
    }
}
