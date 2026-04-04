using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; set; }
    public static event Action OnPlayerDeath;
    public static event Action OnLifeLost;
    private int lifeCount;

    private void Awake()
    {
        Instance = this;
        lifeCount = 3;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Meteor") && lifeCount == 0)
        {
            OnPlayerDeath?.Invoke();
        }
        else if (collision.gameObject.CompareTag("Meteor"))
        {
            OnLifeLost?.Invoke();
            revive();
        }
    }

    private void revive()
    {
        lifeCount--;
        ReturnToStartPosition();
    }

    private void ReturnToStartPosition()
    {
        gameObject.transform.position = new Vector3(0,0,0);
    }

    public int GetLifesCount()
    {
        return lifeCount;
    }
}
