using System;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject Gun;
    [SerializeField] private GameObject BulletPrefab;
    private float nextShootTime = 0f;
    private float shootDelay = 0.25f;
    public static event Action OnShoot;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextShootTime)
        {
            OnShoot?.Invoke();
            GameObject bullet = Instantiate(BulletPrefab, Gun.transform.position, Gun.transform.rotation);
            nextShootTime = Time.time + shootDelay;
        }
    }
}
