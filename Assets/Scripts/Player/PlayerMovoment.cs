using UnityEngine;

public class PlayerMovoment : MonoBehaviour
{
    private float force = 8f;
    private float rotationSpeed = 200f;
    private GameObject spaceship;
    private Rigidbody2D rb2D;
    private bool thrustInput;
    float rotationInput;
    [SerializeField] private ShipVFX shipVFX;

    private void Awake()
    {
        spaceship = gameObject;
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        
    }

    private void Update()
    {
        thrustInput = Input.GetKey(KeyCode.UpArrow);
        rotationInput = Input.GetAxis("Horizontal");

        shipVFX.SetThrust(thrustInput);
    }
    void FixedUpdate()
    {
        if (thrustInput)
        {
            rb2D.AddForce(transform.up * force);
        }
        transform.Rotate(0, 0, -rotationInput * rotationSpeed * Time.deltaTime);
    }
}
