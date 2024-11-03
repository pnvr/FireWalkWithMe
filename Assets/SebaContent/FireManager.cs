using UnityEngine;
using System.Collections.Generic;

public class FireManager : MonoBehaviour
{
    //Objects
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject fireObject;
    [SerializeField] private MapManager mapManager;

    [SerializeField] private LayerMask layerMask;

    //
    //[SerializeField] private Vector3 UpDirection = new Vector3(0f, 1f, 0f);
    [SerializeField] private int SpawnAmount = 50;

    [SerializeField] private Vector3 OverlapHalfSize = new Vector3(0.5f, 0.5f, 0.5f);

    //
    [SerializeField] private float tick = 0.1f;

    private float timer = 0f;
    private Vector3 previousPlayerPosition = Vector3.zero;
    private List<GameObject> firePool = new List<GameObject>();
    private int amountInUse = 0;

    private void Start()
    {
        previousPlayerPosition = player.transform.position;
        SpawnChunk();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        while (timer >= 0)
        {
            TryPlaceFire();
            timer -= tick;
        }
    }

    private void SpawnChunk()
    {
        for (int i = 0; i < SpawnAmount; i++)
        {
            GameObject temp = Instantiate<GameObject>(fireObject);
            temp.transform.parent = this.transform;
            firePool.Add(temp);
            temp.GetComponent<Fire>().Setup(mapManager);
        }
    }

    public void Reset()
    {
        foreach (GameObject f in firePool)
        {
            Fire fire = f.GetComponent<Fire>();
            if (fire)
            {
                fire.Reset();
            }
        }
        amountInUse = 0;
    }

    private void TryPlaceFire()
    {
        if (!CanPlaceFire())
        {
            return;
        }

        previousPlayerPosition = player.transform.position;

        GameObject fireObject = firePool[amountInUse];
        fireObject.transform.position = player.transform.position;
        fireObject.GetComponent<Fire>()._Start();
        amountInUse++;

        if (amountInUse >= firePool.Count)
        {
            SpawnChunk();
        }
    }

    private bool CanPlaceFire()
    {
        if (previousPlayerPosition == player.transform.position)
        {
            return (false);
        }

        Collider[] objects = Physics.OverlapBox(player.transform.position, OverlapHalfSize, player.transform.rotation, layerMask);
        foreach (Collider col in objects)
        {
            Fire fire = col.GetComponentInParent<Fire>();
            
            if (fire)
            {
                return (false);
            }
        }

        return (true);
    }
}
