using UnityEngine;

public class AsteroidSpawner:MonoBehaviour
{
    private Vector2 center;
    private float height;
    private float width;
    private float radius;
    private float angle;
    private Vector2 direction;
    [SerializeField] private GameObject meteorPrefab;
    private void Start()
    {
        center = Camera.main.transform.position;
        height = Camera.main.orthographicSize;
        width = height * Camera.main.aspect;
        Vector2 spawnPosition = CalculateSpawnPosition(); 
        GameObject meteor = Instantiate(meteorPrefab, spawnPosition, Quaternion.identity);  
    }

    private void Update()
    {

    }

    private Vector2 CalculateSpawnPosition()
    {
        radius = Mathf.Sqrt(Mathf.Pow(height, 2) + Mathf.Pow(width, 2));
        angle = Random.Range(0f, Mathf.PI * 2);
        Vector2 spawnPosition = center + new Vector2(Mathf.Sin(angle), Mathf.Cos(angle))*radius;
        return spawnPosition;
    }
}
