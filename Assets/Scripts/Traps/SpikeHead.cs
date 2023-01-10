using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeHead : EnemyDamage
{
    [Header("SpikeHead Attributes")]
    [SerializeField] private float speed;
    [SerializeField] private float range;
    [SerializeField] private float delayCheck;
    [SerializeField] private LayerMask playerLayer;
    private float checkTimer;
    private Vector3 destination;
    private Vector2 origin;

    private bool attacking;
    private Vector3[] directions = new Vector3[4];

    private void Awake() {
        origin = transform.position;
    }
    private void OnEnable() {
        Stop();
    }
    public void Update(){
        if(attacking)
            transform.Translate(destination * Time.deltaTime * speed);
        else{
            checkTimer += Time.deltaTime;
            if(checkTimer > delayCheck){
                returnToOrigin();
                CheckForPlayer();
            }else{
            }
        }
    }

    private void returnToOrigin(){
        transform.position = Vector2.MoveTowards(transform.position, origin, 0.08f);
    }

    private void CheckForPlayer(){
        CalculateDirections();

        for(int i = 0; i < directions.Length; i++){
            Debug.DrawRay(transform.position, directions[i], Color.red);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, directions[i], range, playerLayer);

            if(hit.collider != null && !attacking){
                attacking = true;
                destination = directions[i];
                checkTimer = 0;
            }
        }
    }

    private void CalculateDirections(){
        directions[0] = transform.right * range; // right direction
        directions[1] = -transform.right * range;//left direction
        directions[2] = transform.up * range; //up   
        directions[3] = -transform.up * range; // down
    }

    private void Stop(){
        destination = transform.position;
        attacking = false;
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        base.OnTriggerEnter2D(collider);
        Stop();


    }

}
