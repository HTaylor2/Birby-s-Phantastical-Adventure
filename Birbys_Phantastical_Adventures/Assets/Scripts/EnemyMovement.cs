using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Callbacks;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyMovement : MonoBehaviour
{
    Transform target;
    Rigidbody2D rb;
    [SerializeField]private float moveSpeed;
    private Vector2 moveDirection;

    // Start is called before the first frame update
    private void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(target){
            Vector3 direction = (target.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x)*Mathf.Rad2Deg;
            angle += 180f;
            rb.rotation = angle;
            rb.velocity = direction * moveSpeed;
        }
    }
}
