using System.Collections;
using UnityEngine;

public class ShipVFX : MonoBehaviour
{
    public static ShipVFX Instance { get; private set; }
    [SerializeField] private GameObject fire;
    [SerializeField] private GameObject explosion;
    [SerializeField] private GameObject[] shipParts;
    private bool Invincible = false;
    private float debriesSpeed = 7f;
    private Coroutine blinking;

    private void Start()
    {
        Player.OnStartInvincibility += Player_OnStartInvincibility;
        Player.OnEndInvincibility += Player_OnEndInvincibility;
    }

    private void Player_OnEndInvincibility()
    {
        Invincible = false;
    }

    private void Player_OnStartInvincibility()
    {
        Invincible = true;
    }

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (Invincible && blinking == null)
        {
            blinking = StartCoroutine(Blinking());
        }
    }

    private IEnumerator Blinking()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        bool fadingOut = true;

        while(Invincible)
        {
            Color color = sr.color;
            if (fadingOut)
            {
                color.a -= 0.05f;
                if (color.a < 0.2f) fadingOut = false;
            }
            else
            {
                color.a += 0.05f;
                if (color.a > 0.8f) fadingOut = true;
            }
            sr.color = color;
            yield return null;
        }

        Color finalColor = sr.color;
        finalColor.a = 1f;
        sr.color = finalColor;
        blinking = null;
    }

    public void SetThrust(bool isMovingForward)
    {
        if(fire.activeSelf != isMovingForward)
        {
            fire.SetActive(isMovingForward);
        }
    }

    public Vector2 GetRandomDirection()
    {
        Vector2 center = Camera.main.transform.position;
        float height = Camera.main.orthographicSize;
        float width = height * Camera.main.aspect;

        float randomX = Random.Range(center.x - width, center.y + width);
        float randomY = Random.Range(center.x - height, center.y + height);

        return new Vector2(randomX, randomY);
    }
    public void ShipDestraction(GameObject ship)
    {
        foreach(GameObject part in shipParts)
        {
            GameObject currentPart = Instantiate(part, ship.transform.position, ship.transform.rotation);
            Rigidbody2D rb2D = currentPart.GetComponent<Rigidbody2D>();
            Vector2 direction = (GetRandomDirection() - new Vector2(ship.transform.position.x,ship.transform.position.y)).normalized;
            rb2D.linearVelocity = direction * debriesSpeed;
        }
    }
    public void BlowUp(GameObject ship)
    {
        Instantiate(explosion, ship.transform.position, Quaternion.identity);
    }
}
