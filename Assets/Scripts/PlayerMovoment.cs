using UnityEngine;

public class PlayerMovoment : MonoBehaviour
{
    private float force = 5f;
    private float rotationSpeed = 100f;
    private GameObject spaceship;
    private Rigidbody2D rb2D;

    private void Awake()
    {
        spaceship = gameObject;
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb2D.AddForce(transform.up * force);
        }
        float rotation = Input.GetAxis("Horizontal");
        transform.Rotate(0, 0, -rotation * rotationSpeed * Time.deltaTime);
    }
}
