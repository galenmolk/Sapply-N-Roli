using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BramblyMead;
using System;

public class SoundEffects : Singleton<SoundEffects>
{
    public SFX waterPickup;
    public SFX sunPickup;
    public SFX grow;
    public SFX newRequest;
    public SFX partialDelivery;
    public SFX enemyHit;

    [Serializable]
    public class SFX
    {
        public AudioClip audioClip;
        public float volume;
    }

    public void WaterPickedUp()
    {
        AudioSource.PlayClipAtPoint(waterPickup.audioClip, Vector3.zero, waterPickup.volume);
    }

    public void SunPickedUp()
    {
        AudioSource.PlayClipAtPoint(sunPickup.audioClip, Vector3.zero, sunPickup.volume);
    }

    public void Grow()
    {
        AudioSource.PlayClipAtPoint(grow.audioClip, Vector3.zero, grow.volume);
    }

    public void NewRequest()
    {
        AudioSource.PlayClipAtPoint(newRequest.audioClip, Vector3.zero, newRequest.volume);
    }

    public void PartialDelivery()
    {
        AudioSource.PlayClipAtPoint(partialDelivery.audioClip, Vector3.zero, partialDelivery.volume);
    }

    public void EnemyHit()
    {
        AudioSource.PlayClipAtPoint(enemyHit.audioClip, Vector3.zero, enemyHit.volume);
    }
}
