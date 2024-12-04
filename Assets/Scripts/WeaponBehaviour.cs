using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehaviour : MonoBehaviour
{

    public void FireWeapon(RaycastHit hit)
    {
        //GetComponent<AudioSource>().Play();

        if (hit.transform.tag == "Enemy" || hit.transform.tag == "Player")
        {
            CharacterBehaviour character = hit.transform.GetComponent<CharacterBehaviour>();
            character.Hit();
        }
    }
}