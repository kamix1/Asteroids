using UnityEngine;

public class AsteroidSpawner:MonoBehaviour
{
    private Vector2 center;
    private float height;
    private float width;
    private float radius;
    private float angle;
    private Vector2 spawnPosition;
    private Vector2 direction;
    [SerializeField] private GameObject meteorPrefab;
    private void Start()
    {
        center = Camera.main.transform.position;
        height = Camera.main.orthographicSize;
        width = height * Camera.main.aspect;
        radius = Mathf.Sqrt(Mathf.Pow(height, 2) + Mathf.Pow(width, 2));
        angle = Random.Range(0f, Mathf.PI * 2);
        spawnPosition = center + new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        Vector2 randomPointOnScreen = FindRandomPointOnScreen();
        direction = (spawnPosition - randomPointOnScreen).normalized;
        float speed = Random.Range(2f, 5f);
        GameObject meteor = Instantiate(meteorPrefab, spawnPosition, Quaternion.identity);

    }

    private void Update()
    {

    }

    private Vector2 FindRandomPointOnScreen()
    {
        float x = Random.Range(center.x - width, center.x + width);
        float y = Random.Range(center.y - height, center.y + height);
        return new Vector2(x,y);
    } 
}
