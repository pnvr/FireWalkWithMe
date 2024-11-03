using UnityEngine;

public class Key : MonoBehaviour
{
    MapManager map;
    void Start()
    {
        map = FindAnyObjectByType<MapManager>();
        var pos = map.WorldToMapCoords(transform.position);
        map.data [ pos.x ] [ pos.y ] = new MapNode(NodeType.Key, gameObject);
    }
    public void PickupKey()
    {
        GameManager.Instance.AddKey();
        Destroy(gameObject);
        Debug.Log("Avain poimittu");
    }

}
