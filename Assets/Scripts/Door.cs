using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour
{
    MapManager map;
    public GameObject DoorAMessage;
    
    
    
    bool IsThereAKey()
    {
        return GameManager.Instance.CheckKey();
    }

    //void Update() {
    //    timer += Time.deltaTime;
    //    if (DoorAMessage != false && timer > 3) {

    //        DoorAMessage.SetActive(false);
    //    }
    //}

    private IEnumerator ShowForSeconds() {
        DoorAMessage.SetActive(true);
        yield return new WaitForSeconds(3);
        // DoorAMessage.SetActive(false);
        Destroy(DoorAMessage);
    }
    
    public void OpenDoor()
    {
        
        if (CompareTag("DoorA")) {
            StartCoroutine(ShowForSeconds());
            Debug.Log("Opened and destroyed Door A");
            Destroy(gameObject);
            
        }
        else if (CompareTag("DoorY")) {
            Debug.Log("Opened and destroyed Door Y");
            Destroy(gameObject);
        }
        
        //GameObject doorY = GameObject.FindWithTag("DoorY");

        //GameObject doorA = GameObject.FindWithTag("DoorA");

        //if (doorA != null) {
        //    //instantiate Door A imagesprite
        //    Debug.Log("Destroyed door A");
        //    Destroy(doorA);
        //}

        //if (doorY != null) {
        //    // Win Game
        //    Debug.Log("Destroyed door Y");
        //    Destroy(doorY);
        //}

        
        // GameManager.Instance.UseKey();
            
    }

    void Start()
    {
       map = FindAnyObjectByType<MapManager>();
       var pos = map.WorldToMapCoords(transform.position);
       map.data [ pos.x ] [ pos.y ] = new MapNode(NodeType.Door, gameObject);
       
    }
}
