using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    Rigidbody2D rb;
    Transform currentPoint;
    public float speed = 12;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPoint = pointA;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 direction = (currentPoint.position - transform.position).normalized;
        rb.velocity = direction * speed;

        if(Mathf.Abs(transform.position.x - currentPoint.position.x) < 10f){
            if(currentPoint == pointA){
                currentPoint = pointB;
            }
            else{
                currentPoint = pointA;
            }
        }
    }
}
