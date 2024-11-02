using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] private float igniteTime = 2f;
    [SerializeField] private GameObject visual;
    
    private float timer = 0f;
    private bool fireActive = false;
    private bool prefabActive = false;

    public void Reset()
    {
        visual.SetActive(false);
        timer = igniteTime;
        fireActive = false;
        prefabActive = false;
    }

    public void Start()
    {
        Reset();
    }

    public void _Start()
    {
        prefabActive = true;
    }

    private void Update()
    {
        if (!prefabActive)
        {
            return;
        }

        timer -= Time.deltaTime;

        if (fireActive)
            return;

        if (timer <= 0)
        {
            fireActive = true;
            visual.SetActive(true);
        }
    }

    public bool OnFire()
    {
        return (fireActive);
    }
}
