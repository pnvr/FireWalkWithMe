using UnityEngine;

public class Extinguisher : MonoBehaviour {
    MapManager map;
    void Start() {
        map = FindAnyObjectByType<MapManager>();
        var pos = map.WorldToMapCoords(transform.position);
        map.data[pos.x][pos.y] = new MapNode(NodeType.Extinguisher, gameObject);
    }

    public void PickupExtinguisher() {
        GameManager.Instance.AddExtinguisher();

        var pos = map.WorldToMapCoords(transform.position);
        map.data[pos.x][pos.y] = new MapNode(NodeType.Empty, gameObject);
        gameObject.SetActive(false);
        Debug.Log("Sammutin poimittu");
    }
}
//    public void Reset() {
//        var pos = map.MapToWorldCoords(transform.position);
//        map.data[pos.x][pos.y] = new MapNode(NodeType.Extinguisher, gameObject);
//        gameObject.SetActive(true);
//        Debug.Log("Sammutin palautettu käyttöön");
//    }
//}
