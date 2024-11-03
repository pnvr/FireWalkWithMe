using UnityEngine;

public class Extinguisher : MonoBehaviour
{
    MapManager map;
    void Start()
    {
        map = FindAnyObjectByType<MapManager>();
        var pos = map.WorldToMapCoords(transform.position);
        map.data [ pos.x ] [ pos.y ] = new MapNode(NodeType.Extinguisher, gameObject);
    }

    public void PickupExtinguisher()
    {
        GameManager.Instance.AddExtinguisher();
        Destroy(gameObject);
        Debug.Log("Sammutin poimittu");
    }
}
