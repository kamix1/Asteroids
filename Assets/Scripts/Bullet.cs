using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private float speed;
    private float lifeSpan = 1f;
    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        speed = 500f;
        rb2D.AddForce(transform.up * speed);
        Destroy(gameObject, lifeSpan);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Meteor"))
        {
            Destroy(gameObject);
            Meteor meteor = collision.gameObject.GetComponent<Meteor>();
            if(meteor != null)
            {
                meteor.Die();
            }
            else
            {
                Debug.Log("object is not meteor");
            }
        }
    }
}
