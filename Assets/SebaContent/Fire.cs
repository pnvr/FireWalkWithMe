using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] private float igniteTime = 2f;
    [SerializeField] private GameObject fireVisual;

    private float timer = 0f;
    private bool fireActive = false;
    private bool prefabActive = false;
    private MapManager mapManager;
    private MapNode previousNodeData = new MapNode();

    public void Reset()
    {
        fireVisual.SetActive(false);
        timer = igniteTime;
        fireActive = false;
        prefabActive = false;
    }

    private void Start()
    {
        Reset();
    }

    public void Setup(MapManager mapManager)
    {
        this.mapManager = mapManager;
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
        {
            return;
        }

        if (timer <= 0)
        {
            fireActive = true;
            fireVisual.SetActive(true);
            SetFireOn();
        }
    }

    private void SetFireOn()
    {
        if (previousNodeData.obj)
        {
            var previousPos = mapManager.WorldToMapCoords(previousNodeData.obj.transform.position);
            mapManager.data[previousPos.x][previousPos.y] = new MapNode(NodeType.Wall, previousNodeData.obj);
        }

        var currentPos = mapManager.WorldToMapCoords(transform.position);
        previousNodeData = mapManager.data[currentPos.x][currentPos.y];
        mapManager.data[currentPos.x][currentPos.y] = new MapNode(NodeType.Fire, gameObject);
    }
}
