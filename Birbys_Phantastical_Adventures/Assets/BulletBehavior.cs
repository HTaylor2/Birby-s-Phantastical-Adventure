using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float lifespan = 3f;
    public float bulletSpeed = 10f;
    public Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right*bulletSpeed;
        Destroy(gameObject,lifespan);
    }

    public void OnCollisionEnter2D(Collision2D col){
        Destroy(gameObject);
    }
}
