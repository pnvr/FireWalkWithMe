using UnityEngine;

public class Sensor : MonoBehaviour
{
    public LayerMask Layer = 1 << 8;
    public string Tag = "";

    /// <summary>
    /// Returns true if there is an object in front of the agent
    /// </summary>
    public bool CheckForwardLocal()
    {
        return Check(transform.forward);
    }

    /// <summary>
    /// Returns True if there is an object left of the agent
    /// </summary>
    public bool CheckLeftLocal()
    {
        return Check(-transform.right);
    }

    /// <summary>
    /// Returns True if there is an object right of the agent
    /// </summary>
    public bool CheckRightLocal()
    {
        return Check(transform.right);
    }

    /// <summary>
    /// Returns True if there is an object behind of the agent 
    /// </summary>
    public bool CheckBackwardLocal()
    {
        return Check(-transform.forward);
    }

    public bool Check(Vector3 worldDirection)
    {
        return Helpers.Check(worldDirection, transform.position, Layer, Tag);
    }
}
