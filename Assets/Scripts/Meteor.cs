using System;
using UnityEngine;

public class Meteor:MonoBehaviour
{
    private Vector2 center;
    private float height;
    private float width;
    private float size;
    private float speed;
    public MeteorType meteorType;
    public static event Action<Meteor> meteorDied;
    public static event Action<Meteor> meteorSpawned;
    public enum MeteorType
    {
        large,
        medium,
        small
    }

    private void Awake()
    {
        meteorSpawned?.Invoke(this);
    }
    public void Init(MeteorType meteorType)
    {
        speed = UnityEngine.Random.Range(1f, 2f);
        this.meteorType = meteorType;
        float size = SetSize(meteorType);
        transform.localScale = new Vector3(size, size, size);
    }
    public void Init(MeteorType meteorType, float size, float speed)
    {
        this.speed = speed;
        this.meteorType = meteorType;
        transform.localScale = new Vector3(size, size, size);
    }

    private void Start()
    {
        center = Camera.main.transform.position;
        height = Camera.main.orthographicSize;
        width = height * Camera.main.aspect;
        Vector2 spawnPosition = transform.position;
        Vector2 randomPointOnScreen = FindRandomPointOnScreen();

        Vector2 direction = (randomPointOnScreen-spawnPosition).normalized;
        GetComponent<Rigidbody2D>().linearVelocity = direction * speed;
    }

    private float SetSize(MeteorType meteorType)
    {
        size = meteorType switch
        {
            MeteorType.large => UnityEngine.Random.Range(1f, 0.7f),
            MeteorType.medium => UnityEngine.Random.Range(0.7f, 0.4f),
            MeteorType.small => UnityEngine.Random.Range(0.4f, 0.1f),
            _ => UnityEngine.Random.Range(0.4f, 0.1f)
        };
        return size;
    }

    private Vector2 FindRandomPointOnScreen()
    {
        float x = UnityEngine.Random.Range(center.x - width, center.x + width);
        float y = UnityEngine.Random.Range(center.y - height, center.y + height);
        return new Vector2(x, y);
    }

    public void Die()
    {
        if (meteorType == MeteorType.small)
        {
            Destroy(gameObject);
        }
        else
        {
            MeteorType nextType = meteorType switch
            {
                MeteorType.large => MeteorType.medium,
                MeteorType.medium => MeteorType.small,
                _ => MeteorType.small
            };

            float size = SetSize(nextType);
            for (int i = 0; i < 2; i++)
            {
                GameObject newMeteor = Instantiate(gameObject, transform.position, Quaternion.identity);
                newMeteor.GetComponent<Meteor>().Init(nextType, size, speed);
            }
            Destroy(gameObject);
        }
        meteorDied?.Invoke(this);
    }
}
