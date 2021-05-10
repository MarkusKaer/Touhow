using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class EnemyBullet : NetworkBehaviour
{

    [SerializeField]
    private int damage = 20;

    private Vector2 moveDirection;
    private float moveSpeed;

    //Her fortæller onEnable vores bullets at efter de er røget ud af vores BulletPool så 
    //skal den destrueres igen efter 3 sekunder og så ryger den på en måde tilbage i BulletPoolen igen
    private void OnEnable()
    {
        Invoke("Destroy", 3f);
    }



    // I start funktionen sætter vi movespeeden til 5
    void Start()
    {
        moveSpeed = 5f;
    }

    // I update funktionen får vi vores bullet til at bevæge sig i en specifik retning som er beregnet i fireBullet scriptet
    void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    //her gør vi os i stand til at sætte bullet direction fra fireBullet scriptet
    public void SetMoveDirection(Vector2 dir)
    {
        moveDirection = dir;
    }

    //Her sætter vi vores bullet til en inactive state og venter på at blive skudt igen
    private void Destroy()
    {
        gameObject.SetActive(false);
    }

    // I OnDisable funktionen ophæver vi Invoke når vores bullets er inaktive
    private void OnDisable()
    {
        CancelInvoke();
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Player player = hitInfo.GetComponent<Player>();
        if (player != null)
        {
            player.TakeDamage(damage);
        }
        Invoke("Destroy", 3f);
    }


}




