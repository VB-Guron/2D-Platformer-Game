using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{


    public GameObject camera;
    private void OnTriggerEnter2D(Collider2D other) {
        UnityEngine.Debug.Log(other.name);
        UnityEngine.Debug.Log(gameObject.name);
        if(other.tag == "Player"){
            other.GetComponent<Health>().TakeDamage(3);
            StartCoroutine(Counter());
        }
    }


    private IEnumerator Counter(){
        yield return new WaitForSecondsRealtime(0.4f);
        camera.SetActive(false);
    }
}
