using UnityEngine;

public class LifesHUD : MonoBehaviour
{
    [SerializeField] private GameObject lifesTemplate;
    private GameObject[] lifeContainers;
    private int lifesCount;
    private void Awake()
    {
        lifesTemplate.SetActive(false);
    }

    private void Start()
    {
        Player.OnLifeLost += LifeHUD_OnLifeLost;
        lifesCount = Player.Instance.GetLifesCount();
        lifeContainers = new GameObject[lifesCount];
        CreateLifesImages();
    }

    private void LifeHUD_OnLifeLost(GameObject ship)
    {
        if (lifesCount > 0)
        {
            Destroy(lifeContainers[lifesCount - 1]);
            lifesCount--;
        }
        else
        {
            Debug.Log("no lifes");
        }
    }

    private void CreateLifesImages()
    {
        for(int i = 0; i<lifesCount; i++)
        {
            lifeContainers[i] = Instantiate(lifesTemplate, gameObject.transform.position, Quaternion.identity, gameObject.transform);
        }
        foreach(GameObject el in lifeContainers)
        {
            el.SetActive(true);
        }
    }

    private void OnDestroy()
    {
        Player.OnLifeLost -= LifeHUD_OnLifeLost;
    }
}
