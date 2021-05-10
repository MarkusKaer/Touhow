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

    //Her fort�ller onEnable vores bullets at efter de er r�get ud af vores BulletPool s� 
    //skal den destrueres igen efter 3 sekunder og s� ryger den p� en m�de tilbage i BulletPoolen igen
    private void OnEnable()
    {
        Invoke("Destroy", 3f);
    }



    // I start funktionen s�tter vi movespeeden til 5
    void Start()
    {
        moveSpeed = 5f;
    }

    // I update funktionen f�r vi vores bullet til at bev�ge sig i en specifik retning som er beregnet i fireBullet scriptet
    void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    //her g�r vi os i stand til at s�tte bullet direction fra fireBullet scriptet
    public void SetMoveDirection(Vector2 dir)
    {
        moveDirection = dir;
    }

    //Her s�tter vi vores bullet til en inactive state og venter p� at blive skudt igen
    private void Destroy()
    {
        gameObject.SetActive(false);
    }

    // I OnDisable funktionen oph�ver vi Invoke n�r vores bullets er inaktive
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




