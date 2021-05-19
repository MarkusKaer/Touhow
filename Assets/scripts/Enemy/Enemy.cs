using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;

public class Enemy : NetworkBehaviour
{



    [SyncVar]
    public int health;

    GameObject nMan;

    Network nM;
    
    public void Start()
    {
        health = 500;
        
        nMan = GameObject.FindWithTag("NetworkManager");

        nM = nMan.GetComponent<Network>();
    }
    
    
    
    
    
    public void TakeDamage (int PlayerDamage)
    {
        health -= PlayerDamage;

        if (health <= 0)
        {
            nM.EndGame = true;
        }

        if (nM.EndGame == true)
        {
            health = 100;
        }


    }






}
