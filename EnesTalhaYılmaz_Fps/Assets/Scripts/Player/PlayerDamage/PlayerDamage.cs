using System.Collections;
using System.Collections.Generic;
using EnesTalhaYılmaz_Fps.Projectile;
using UnityEngine;

public class PlayerDamage : MonoBehaviour, IDamageable
{
    [SerializeField] ResourceTypes healthResource;
    [SerializeField] ResourceManager resourceManager;
    AudioSource audioSource;
    private void Awake() {
        audioSource=GetComponent<AudioSource>();
    }
    public void Damage(int damagePoint)
    {
        resourceManager.ChangeResAmount(healthResource, damagePoint, OperatorType.Dec);
        PreventSoundOverlap();
        Debug.Log("audioSource.isPlaying"+audioSource.isPlaying);
        if (resourceManager.HealthAmount <= 0)
        {
            Destroy(gameObject);
        }

    }

    private void PreventSoundOverlap()
    {
        if (!audioSource.isPlaying)
        { SoundManager.Instance.PlaySound(SoundType.PlayerHit, audioSource); }
    }
}
