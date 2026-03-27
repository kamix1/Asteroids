using UnityEngine;

public class Meteor:MonoBehaviour
{
    private Vector2 center;
    private float height;
    private float width;
    private void Start()
    {
        center = Camera.main.transform.position;
        height = Camera.main.orthographicSize;
        width = height * Camera.main.aspect;
        Vector2 spawnPosition = transform.position;
        Vector2 randomPointOnScreen = FindRandomPointOnScreen();

        Vector2 direction = (randomPointOnScreen-spawnPosition).normalized;
        float speed = Random.Range(2f,5f);
        GetComponent<Rigidbody2D>().linearVelocity = direction * speed;
    }
    private Vector2 FindRandomPointOnScreen()
    {
        float x = Random.Range(center.x - width, center.x + width);
        float y = Random.Range(center.y - height, center.y + height);
        return new Vector2(x, y);
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
