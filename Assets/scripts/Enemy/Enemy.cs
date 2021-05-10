using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Enemy : NetworkBehaviour
{

    public int health = 100;

    public void TakeDamage (int PlayerDamage)
    {
        health -= PlayerDamage;

        if (health <= 0)
        {
            Die();
        }

    }


    void Die ()
    {
        Destroy(gameObject);
    }






}
