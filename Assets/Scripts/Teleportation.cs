using UnityEngine;

public class Teleportation : MonoBehaviour
{
    [SerializeField] private float offset = 0.05f;
    private void Start()
    {
    }
    private void Update()
    {
        Vector3 viewPos = Camera.main.WorldToViewportPoint(gameObject.transform.position);
        if (viewPos.x + offset < 0) viewPos.x = 1f + offset;
        else if (viewPos.x - offset > 1) viewPos.x = 0f - offset;
        if (viewPos.y + offset < 0)
        {
            viewPos.y = 1f + (offset - (offset * 0.2f));
        }
        else if (viewPos.y - offset > 1)
        {
            viewPos.y = 0f - (offset - (offset * 0.2f));
        }
        gameObject.transform.position = Camera.main.ViewportToWorldPoint(viewPos);
    }
}
