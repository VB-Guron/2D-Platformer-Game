using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinFunctions : MonoBehaviour
{

    private void Start() {
    }    

    
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "Player"){
            collision.GetComponent<Inventory>().addCoin(1);
            gameObject.SetActive(false);
            
        }
    }
}
