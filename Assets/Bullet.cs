using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float BulletSpeed = 20f;
    public Rigidbody2D rb;



    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.up * BulletSpeed;
    }

 
}
