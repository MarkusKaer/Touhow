using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;

public class Player : NetworkBehaviour
{

    GameObject nMan;

    Network nM;


    [SyncVar]
    public int PlayerHealth = 100;


    public void Start()
    {

        nMan = GameObject.FindWithTag("NetworkManager");

        nM = nMan.GetComponent<Network>();
    }

    public void TakeDamage(int damage)
    {
        PlayerHealth -= damage;

        if (PlayerHealth <= 0)
        {
            nM.WinGame = true; 
        }

    }

}