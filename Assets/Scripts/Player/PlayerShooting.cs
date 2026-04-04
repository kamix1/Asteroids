using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject Gun;
    [SerializeField] private GameObject BulletPrefab;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = Instantiate(BulletPrefab, Gun.transform.position, Gun.transform.rotation);
        }
    }
}
