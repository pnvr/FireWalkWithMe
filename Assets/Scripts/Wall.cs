using UnityEngine;

public class Wall : MonoBehaviour
{
    MapManager map;
    
    void Start()
    {
        map = FindAnyObjectByType<MapManager>();
        var pos = map.WorldToMapCoords(transform.position);
        map.data [ pos.x ] [ pos.y ] = new MapNode(NodeType.Wall, gameObject);
    }

    void Update()
    {
        
    }
}
