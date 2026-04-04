using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerDeathHandler : MonoBehaviour
{
    private void Start()
    {
        Player.OnPlayerDeath += PlayerDeathHandler_OnPlayerDeath;
    }

    private void OnDestroy()
    {
        Player.OnPlayerDeath -= PlayerDeathHandler_OnPlayerDeath;
    }
    private void PlayerDeathHandler_OnPlayerDeath()
    {
        GameOverCanvas.Instance.Activate(); 
    }

}
