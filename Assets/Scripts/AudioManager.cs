using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;
    private AudioSource shipEngine;
    [SerializeField] private AudioClip[] shootSound;
    [SerializeField] private AudioClip shipExplosionSound;
    [SerializeField] private AudioClip rocketEngineSound;
    [SerializeField] private AudioClip meteorDestroySound;
    [SerializeField] private AudioClip gameOverSound;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Player.OnLifeLost += Player_OnLifeLost;
        Player.OnPlayerDeath += Player_OnPlayerDeath;
        Meteor.meteorDied += Meteor_meteorDied;
        PlayerMovement.OnShipAxelerating += PlayerMovement_OnShipAxelerating;
        PlayerShooting.OnShoot += PlayerShooting_OnShoot;
    }

    private void PlayerShooting_OnShoot()
    {
        AudioClip audioclip = shootSound[Random.Range(0, shootSound.Length)];
        PlaySound(audioclip, 0.27f);
    }

    private void PlayerMovement_OnShipAxelerating(bool axelerating)
    {
        if (axelerating && shipEngine == null)
        {
            shipEngine = PlayLoopSound(rocketEngineSound, 1f);
        }
        else if(!axelerating)
        {
            if (shipEngine != null)
            {
                StopLoopSound(shipEngine);
            }
        }
    }

    public AudioSource PlayLoopSound(AudioClip audioClip, float volume)
    {
        GameObject tempSoundManager = new GameObject("LoopSound_" + audioClip.name);
        tempSoundManager.transform.SetParent(gameObject.transform);
        AudioSource src = tempSoundManager.AddComponent<AudioSource>();
        src.clip = audioClip;
        src.loop = true;
        src.spatialBlend = 0f;
        src.volume = volume;
        src.playOnAwake = false;
        src.Play();
        return src;
    }

    public void StopLoopSound(AudioSource src)
    {
        src.Stop();
        Destroy(src.gameObject);
    }

    private void Meteor_meteorDied(Meteor obj)
    {
        PlaySound(meteorDestroySound, 0.2f);
    }

    private void Player_OnPlayerDeath(GameObject obj)
    {
        PlaySound(gameOverSound);
        if (shipEngine != null)
        {
            StopLoopSound(shipEngine);
        }
    }

    private void Player_OnLifeLost(GameObject obj)
    {
        PlaySound(shipExplosionSound,0.2f);
    }

    private void PlaySound(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }

    private void PlaySound(AudioClip audioClip, float volume)
    {
        audioSource.volume = volume;
        audioSource.PlayOneShot(audioClip);
    }

    private void OnDestroy()
    {
        Player.OnLifeLost -= Player_OnLifeLost;
        Player.OnPlayerDeath -= Player_OnPlayerDeath;
        Meteor.meteorDied -= Meteor_meteorDied;
        PlayerMovement.OnShipAxelerating -= PlayerMovement_OnShipAxelerating;
        PlayerShooting.OnShoot -= PlayerShooting_OnShoot;
    }
}
