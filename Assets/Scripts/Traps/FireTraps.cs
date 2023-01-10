using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTraps : MonoBehaviour
{
    [SerializeField] private float damage;
    [Header("FireTraps Timers")]
    [SerializeField] private float activationDelay;
    [SerializeField] private float activeTime;
    private Animator anim;

    private SpriteRenderer renderer;
    private bool triggered; //when trap gets triggered
    private bool active; //When the trap is active and can hurt the player

    public void Awake(){
        anim = GetComponent<Animator>();
        renderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(!triggered){
            //trigger the trap
            StartCoroutine(ActivateFireTrap());
        }
        if(active){
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }
    private IEnumerator ActivateFireTrap(){
        //turn the sprite red to notify player
        triggered = true;
        renderer.color = Color.red; 

        // Wait for a delay, Activate Trap, Turn on Animation, and Trigger Trap
        yield return new WaitForSeconds(activationDelay);
        renderer.color = Color.white; //Turn back to initial color
        active = true;
        anim.SetBool("activated", true);

        //Wait until x seconds, deactivate the trap, and reset all variables and animator
        yield return new WaitForSeconds(activeTime);
        active = false;
        triggered = false;
        anim.SetBool("activated", false);
        

    }

}
 