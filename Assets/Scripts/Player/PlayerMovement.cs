using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float force = 8f;
    private float rotationSpeed = 200f;
    private GameObject spaceship;
    private Rigidbody2D rb2D;
    private bool thrustInput;
    float rotationInput;
    [SerializeField] private ShipVFX shipVFX;
    public static event Action<bool> OnShipAxelerating;

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
        if (thrustInput)
        {
            OnShipAxelerating?.Invoke(true);
        }
        else
        {
            OnShipAxelerating?.Invoke(false);
        }

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
