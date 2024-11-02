using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;

public class Player : MonoBehaviour
{
    //GameObject agent;
    public bool canIMove;

    void Start()
    {
      
       // agent = GameObject.Find("Cube");
    }

    void Update()
    {

        if ( Input.GetKeyDown(KeyCode.UpArrow) && MayIMove() )
        {
            transform.position = transform.position + Vector3.forward;
            // liikuta yksi yksikkö ylöspäin

        }
        if ( Input.GetKeyDown(KeyCode.DownArrow) && MayIMove())
        {
            transform.position = transform.position + Vector3.back;
        }
        if ( Input.GetKeyDown(KeyCode.LeftArrow) && MayIMove())
        {
            transform.position = transform.position + Vector3.left;
        }
        if ( Input.GetKeyDown(KeyCode.RightArrow) && MayIMove() )
        {
            transform.position = transform.position + Vector3.right;
        }
        //Sensor sensor = agent.GetComponent<Sensor>();
        //Mover instantMover = agent.GetComponent<Mover>();

        //if ( Input.GetKey(KeyCode.UpArrow) && !sensor.CheckForwardLocal() )
        //{
        //    instantMover.Move();

        //}

        //if ( Input.GetKeyDown(KeyCode.LeftArrow) && !sensor.CheckLeftLocal() )
        //{
        //    instantMover.TurnLeft();

        //}
        //if ( Input.GetKeyDown(KeyCode.RightArrow) && !sensor.CheckRightLocal() )
        //{
        //    instantMover.TurnRight();
        //}
    }

    bool MayIMove()
    {
        //tarkistaa saako kävellä
        return canIMove;
    }


    }



