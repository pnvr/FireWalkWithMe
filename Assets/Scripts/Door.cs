using UnityEngine;

public class Door : MonoBehaviour
{
    bool IsThereAKey()
    {
        return GameManager.Instance.CheckKey();
    }

    bool IsKeyNear()
    {
        return true;
    }

    public void OpenDoor()
    {
        if ( IsThereAKey() && IsKeyNear())
        {
            GameManager.Instance.UseKey();
            Debug.Log("Destroyed door");
            return;
            //Destroy(gameObject);
        }
        Debug.Log("No destroy door");

    }
 
}
