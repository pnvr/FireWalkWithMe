using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour
{
    MapManager map;
    public GameObject DoorAMessage;
    public GameObject DoorYMessage;
    //private float timer = 0f;
    //private bool messageIsVisible = false;
    
    bool IsThereAKey()
    {
        return GameManager.Instance.CheckKey();
    }

    //void Update() {
    //    if (messageIsVisible) {
    //        timer += Time.deltaTime;
    //        if (timer >= 3f) {
    //            DoorAMessage.SetActive(false);
    //            messageIsVisible = false;
    //            timer = 0f; 
    //        }

    //    }
    //}

    //private IEnumerator ShowForSeconds() {

    //    if (DoorAMessage != null) {
    //        DoorAMessage.SetActive(true);
    //        Debug.Log("DoorAMessage shown");
    //        yield return new WaitForSeconds(3);
    //        // DoorAMessage.SetActive(false);
    //        Debug.Log("3 seconds passed, destroying DoorAMessage");
    //        Destroy(DoorAMessage);
    //    } 
    //}

    void DestroyDoorMessage() {
        if (DoorAMessage != null) {
            Destroy(DoorAMessage);
            Debug.Log("DoorAMessage destroyed after 3 seconds");
        }
    }
    
    public void OpenDoor()
    {
        
        if (CompareTag("DoorA")) {
            // StartCoroutine(ShowForSeconds());
            // messageIsVisible = true;
            DoorAMessage.SetActive(true);
            Invoke("DestroyDoorMessage", 3f);
            Debug.Log("Opened and destroyed Door A");
            Destroy(gameObject);
            
        }
        else if (CompareTag("DoorY")) {
            DoorYMessage.SetActive(true);
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
