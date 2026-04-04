using UnityEngine;

public class ShipVFX : MonoBehaviour
{
    [SerializeField] private GameObject fire;

    public void SetThrust(bool isMovingForward)
    {
        if(fire.activeSelf != isMovingForward)
        {
            fire.SetActive(isMovingForward);
        }
    }
}
