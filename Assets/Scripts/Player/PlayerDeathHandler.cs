using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerDeathHandler : MonoBehaviour
{
    private void Start()
    {
        Player.OnPlayerDeath += PlayerDeathHandler_OnPlayerDeath;
        Player.OnLifeLost += Player_OnLifeLost;
    }

    private void Player_OnLifeLost(GameObject ship)
    {
        ShipVFX.Instance.BlowUp(ship);
        ShipVFX.Instance.ShipDestraction(ship);
    }

    private void PlayerDeathHandler_OnPlayerDeath(GameObject ship)
    {
        Destroy(ship);
        GameOverCanvas.Instance.Activate(); 
    }

    private void OnDestroy()
    {
        Player.OnPlayerDeath -= PlayerDeathHandler_OnPlayerDeath;
        Player.OnLifeLost -= Player_OnLifeLost;
    }
}
