using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerDeathHandler : MonoBehaviour
{
    public void Die()
    {
        GameOverCanvas.Instance.Activate();
    }
}
