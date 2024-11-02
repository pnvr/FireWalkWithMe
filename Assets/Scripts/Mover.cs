using UnityEngine;
using UnityEngine.Rendering;

public class Mover : MonoBehaviour
{
    bool canMove = true;

    void Start()
    {
    }//Shows the enabled checkbox

    /// <summary>
    /// Moves the agent one tile forward
    /// </summary>
    public void Move()
    {
        if ( !canMove || !enabled )
            return;

        // prevent moving if wall in front
        if ( Helpers.CheckWall(transform.forward, transform.position + Vector3.up * 0.5f) )
        {
       
            canMove = false;
        }
        else
        {
            transform.position += transform.forward;
        }
    }

    /// <summary>
    /// Turns the agent 90 degrees right
    /// </summary>
    public void TurnRight()
    {
        if ( !canMove || !enabled )
            return;

        transform.Rotate(0, 90, 0);
    }

    /// <summary>
    /// Turns the agent 90 degrees left
    /// </summary>
    public void TurnLeft()
    {
        if ( !canMove || !enabled )
            return;

        transform.Rotate(0, -90, 0);
    }
}
