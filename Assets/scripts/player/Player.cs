using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Player : NetworkBehaviour
{

    public int PlayerHealth = 100;

    public void TakeDamage(int damage)
    {
        PlayerHealth -= damage;

        if (PlayerHealth <= 0)
        {
            Die();
        }

    }


    void Die()
    {
        Destroy(gameObject);
    }






}