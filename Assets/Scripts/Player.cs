using UnityEngine;

public class Player : MonoBehaviour
{
    PlayerDeathHandler playerDeathHandler;
    private void Start()
    {
        playerDeathHandler = GetComponent<PlayerDeathHandler>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Meteor"))
        playerDeathHandler.Die();
    }
}
