using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Weapon : NetworkBehaviour
{

    public GameObject bulletPrefab;
    public Transform firepoint;

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer) return;
        if (Input.GetButtonDown("Fire1"))
        {
            shootEngage(); 
        }
      

    }
[Command]//Command er en funktion for at client fortæller hvad serveren skal gøre 
  public void shootEngage(){
      Shoot();
  }
//Fortæller at alle clienter at køre den meteode 
[ClientRpc]
  public void Shoot ()
        {
            Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        }



}
