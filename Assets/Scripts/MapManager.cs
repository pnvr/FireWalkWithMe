using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public enum NodeType{Empty, Wall, Fire, Door}

[System.Serializable]
public struct MapNode
{
    public NodeType type;
    public GameObject obj;
    public MapNode(NodeType type, GameObject obj)
    {
        this.type = type;
        this.obj = obj;
    }
}
public class MapManager : MonoBehaviour
{
    public Vector2Int size;
    public List<List<MapNode>> data = new List<List<MapNode>>();

    private void Awake()
    {
        for ( int i = 0; i < size.x; i++ )
        {
            data.Add(new List<MapNode>());
            for ( int j = 0; j < size.y; j++ )
            {
                data [ i ].Add(new MapNode());
            }
        }
    }

    public Vector2Int WorldToMapCoords(Vector3 pos)
    {
        return new Vector2Int(  Mathf.RoundToInt(pos.x), 
                                Mathf.RoundToInt(pos.z));
    }

    public Vector3 MapToWorldCoords(Vector2Int pos)
    {
        return new Vector3(pos.x, 0, pos.y); 
    }
}
