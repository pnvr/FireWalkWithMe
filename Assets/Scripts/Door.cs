using UnityEngine;

public class Door : MonoBehaviour
{
    MapManager map;
    bool IsThereAKey()
    {
        return GameManager.Instance.CheckKey();
    }


    public void OpenDoor()
    {
        if ( IsThereAKey())
        {
            GameManager.Instance.UseKey();
            Debug.Log("Destroyed door");
            return;
            //Destroy(gameObject);
        }
        Debug.Log("No destroy door");

    }

    void Start()
    {
       map = FindAnyObjectByType<MapManager>();
       var pos = map.WorldToMapCoords(transform.position);
       map.data [ pos.x ] [ pos.y ] = new MapNode(NodeType.Door, gameObject);
       
    }
}
