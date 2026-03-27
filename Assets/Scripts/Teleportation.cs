using UnityEngine;

public class Teleportation : MonoBehaviour
{
    private GameObject ship;
    private float offset = 0.05f;
    private void Start()
    {
        ship = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        Vector3 viewPos = Camera.main.WorldToViewportPoint(ship.transform.position);
        if (viewPos.x + offset < 0) viewPos.x = 1f + offset;
        else if (viewPos.x - offset > 1) viewPos.x = 0f - offset;
        if (viewPos.y + offset < 0)
        {
            viewPos.y = 1f + 0.04f;
            Debug.Log("переместился вверх");
        }
        else if (viewPos.y - offset > 1)
        {
            viewPos.y = 0f - 0.04f;
            Debug.Log("переместился вниз");
        }
        ship.transform.position = Camera.main.ViewportToWorldPoint(viewPos);
    }
}
