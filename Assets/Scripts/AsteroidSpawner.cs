using UnityEngine;

public class AsteroidSpawner:MonoBehaviour
{
    private Vector2 center;
    private float height;
    private float width;
    private float radius;
    private int aliveMeteorNumber { get; set; }
    private int currentWaveNumber = 1;
    private float angle;
    private Vector2 direction;
    [SerializeField] private GameObject meteorPrefab;

    private void Awake()
    {
        Meteor.meteorDied += AsteroidSpawner_meteorDied;
        Meteor.meteorSpawned += AsteroidSpawner_meteorSpawned;
    }

    private void Start()
    {
        center = Camera.main.transform.position;
        height = Camera.main.orthographicSize;
        width = height * Camera.main.aspect;
        WaveSpawn(currentWaveNumber);
    }
    private void WaveSpawn(int waveNumber)
    {
        int meteorithsNumber = waveNumber;
        for(int i = 0; i<meteorithsNumber; i++)
        {
            SpawnMeteor();
        }
    }
    private void AsteroidSpawner_meteorSpawned(Meteor obj)
    {
        aliveMeteorNumber++;
    }
    private void AsteroidSpawner_meteorDied(Meteor obj)
    {
        aliveMeteorNumber--;
        if(aliveMeteorNumber <= 0)
        {
            currentWaveNumber++;
            WaveSpawn(currentWaveNumber);
        }
    }

    private void SpawnMeteor()
    {
        Vector2 spawnPosition = CalculateSpawnPosition();
        GameObject meteor = Instantiate(meteorPrefab, spawnPosition, Quaternion.identity);
        meteor.GetComponent<Meteor>().Init(Meteor.MeteorType.large);
    }
    private Vector2 CalculateSpawnPosition()
    {
        radius = Mathf.Sqrt(Mathf.Pow(height, 2) + Mathf.Pow(width, 2));
        angle = Random.Range(0f, Mathf.PI * 2);
        Vector2 spawnPosition = center + new Vector2(Mathf.Sin(angle), Mathf.Cos(angle))*radius;
        return spawnPosition;
    }
    

}
