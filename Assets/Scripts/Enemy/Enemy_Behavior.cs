using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Behavior : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;
    private Transform target;
    private bool inRange;

    private bool patrolling;
    private Rigidbody2D rb;
    [SerializeField] private float walkSpeed;
    [SerializeField] private Transform Right;
    [SerializeField] private Transform Left;


    private void Awake() {
        anim = GetComponent<Animator>();
        inRange = false;
        patrolling = true;
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {

        if(patrolling){
            anim.SetBool("canMove", true);
            Patrol();
        }

    }

    public void Patrol(){
        if(transform.position != Right.transform.position){
            rb.velocity = new Vector2(walkSpeed * Time.deltaTime, rb.velocity.y);
        }else{
            walkSpeed *=-1;
        }
    }


    private void OnTriggerEnter2D(Collider2D other) {
    }
}
