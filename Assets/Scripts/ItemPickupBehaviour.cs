using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickupBehaviour : QuadBehaviour
{
    public AudioClip pickupSound;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player") return;
        PlayerBehaviour.instance.audioSource.PlayOneShot(pickupSound);
        Pickup();
        gameObject.SetActive(false);
    }
    public virtual void Pickup() {}
}
