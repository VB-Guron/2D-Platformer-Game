using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEnemy : MonoBehaviour
{
    [SerializeField] private float damage;
    private float cooldownTimer = Mathf.Infinity;
    [SerializeField] private float attackCooldown;

    private BoxCollider2D collider;

    public AudioSource audio;

    public void Awake(){
        audio = GetComponent<AudioSource>();
        collider = GetComponent<BoxCollider2D>();
    }

    public void Update(){
        if(Input.GetMouseButton(0)){
            audio.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "Enemy"){
            collision.GetComponent<Health>().DamageEnemy(damage);
            
        }
    }

        private void Attack(){
            collider.enabled = true;
            cooldownTimer = 0;
    }
}
