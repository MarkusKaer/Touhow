using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class FireBullets : NetworkBehaviour
{

    [SerializeField]
    //Det her er hvor mange bullets vi gerne vil skyde ud p� samme tid
    private int bulletsAmount = 10;

    [SerializeField]
    //Det bestemmer den vinkel vi vil skyde bullet ud af
    private float startAngle = 90f, endAngle = 270f;

    //styrer bare bullet directionen som er beregnet med trigonomitri
    private Vector2 bulletMoveDirection;


    // I start definerer vi basically vores firerate, s� hvert andet sekund skyder vi en bullet ud
    void Start()
    {
        InvokeRepeating("Fire", 1f, 2f);
    }

    //N�r fjenden skyder
    private void Fire()
    {
        // Her s�rger vi for at bulletsne bliver spredt ud equally
        float angleStep = (endAngle - startAngle) / bulletsAmount;
        // her s�tter vi bare vores vinkel til start vinkel som bliver brugt til vores movedirection beregninger
        float angle = startAngle;

        float deg2rad = Mathf.PI / 180f;

        //Her bruger vi trigonomitri til at vise bulletsne hvilken retning de skal flyve hen
        for (int i = 0; i < bulletsAmount + 1; i++)
        {

            float bulDirX = transform.position.x + Mathf.Sin(angle * deg2rad);
            float bulDirY = transform.position.y + Mathf.Cos(angle * deg2rad);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position);

            GameObject bul = BulletPool.bulletPoolInstance.GetBullet();
            bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;
            bul.SetActive(true);
            bul.GetComponent<EnemyBullet>().SetMoveDirection(bulDir);

            angle += angleStep;


        }
    }
}
