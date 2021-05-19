using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class BulletPool : NetworkBehaviour
{

    public static BulletPool bulletPoolInstance;


    [SerializeField]
    // Den her variable repræsenterer de bullets der er i poolen
    private GameObject pooledBullet;
    //Den her boolean variable hjælper os med at få flere bullets i vores pool
    private bool notEnoughBulletsInPool = true;

    private List<GameObject> bullets;

    //Her giver vi vores bullets bulletPoolInstance variablen så vi kan arbejde med den her bulletpool i et andet script og tage bullets ud af det
    private void Awake()
    {
        bulletPoolInstance = this;
    }

    // Her begynder vi vores bullet liste så vi kn fylde den med bullets
    void Start()
    {
        bullets = new List<GameObject>();
    }

    // den her funktion Invoker vi hver gang vi skal bruge en bullet. 
    public GameObject GetBullet()
    {
        // først checker vi om der er mere end 0 bullets i vores pool
        if (bullets.Count > 0)
        {
            //Hvis der er mere end 0 betyder det vi har nogen bullets
            for (int i = 0; i < bullets.Count; i++)
            {
                // Her kigger vi efter bullets der er inaktive lige nu
                if (!bullets[i].activeInHierarchy)
                {
                    //Hvis vi finder en iaktiv bullet får vi den igen
                    return bullets[i];
                }
            }
        }

        //Hvis der ikke er nogen bullets i vores pool, for eksempel når spillet begynder, eller hvis der ikke er flere i hierarkiet betyder det at vi ikke har nok.
        if (notEnoughBulletsInPool)
        {
            //Vi instantiater en bullet
            GameObject bul = Instantiate(pooledBullet);
            //sætter den til inaktiv state
            bul.SetActive(false);
            //tilføjer den til poolen
            bullets.Add(bul);
            //og vi får den igen
            return bul;
        }


        return null;


    }


}