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
        
        
            GameManager.Instance.UseKey();
            Debug.Log("Destroyed door");
            
            Destroy(gameObject);

        

    }

    void Start()
    {
       map = FindAnyObjectByType<MapManager>();
       var pos = map.WorldToMapCoords(transform.position);
       map.data [ pos.x ] [ pos.y ] = new MapNode(NodeType.Door, gameObject);
       
    }
}
