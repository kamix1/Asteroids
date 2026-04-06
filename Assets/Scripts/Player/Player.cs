using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; set; }
    public static event Action<GameObject> OnPlayerDeath;
    public static event Action<GameObject> OnLifeLost;
    public static event Action OnStartInvincibility;
    public static event Action OnEndInvincibility;
    private int lifeCount;
    private float InvincibilityTime = 3f;
    private float InvincibilityTimer = 0f;
    private bool isInvincible;

    private void Awake()
    {
        Instance = this;
        lifeCount = 3;
    }

    private void Update()
    {
        if (isInvincible)
        {
            InvincibilityTimer += Time.deltaTime;
            if(InvincibilityTimer >= InvincibilityTime)
            {
                EndInvincibility();
                InvincibilityTimer = 0f;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Meteor") && lifeCount == 0)
        {
            OnLifeLost?.Invoke(gameObject);
            OnPlayerDeath?.Invoke(gameObject);
        }
        else if (collision.gameObject.CompareTag("Meteor"))
        {
            OnLifeLost?.Invoke(gameObject);
            revive();
        }
    }

    private void revive()
    {
        lifeCount--;
        BecomeInvincible();
        ReturnToStartPosition();
    }

    private void BecomeInvincible()
    {
        isInvincible = true;
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Meteor"), isInvincible);
        OnStartInvincibility?.Invoke();
    }

    private void EndInvincibility()
    {
        isInvincible = false;
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Meteor"), isInvincible);
        OnEndInvincibility?.Invoke();
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
