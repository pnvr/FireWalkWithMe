using UnityEngine;

public class UITester : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            GameManager.Instance.AddExtinguisher();
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            GameManager.Instance.UseExtinguisher();
        }
    }
}
