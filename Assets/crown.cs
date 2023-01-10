using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crown : MonoBehaviour
{
    public bool canbePickedUp;



     private void Awake() {
        canbePickedUp = false;
    }

    private void Update() {
        if(canbePickedUp){
            if(Input.GetKeyDown(KeyCode.E)){
                
                    GameObject.Find("Character").GetComponent<PlayerMovement>().Win();
                    GameObject.Find("Character").GetComponent<PlayerMovement>().WinAnimation();
                    
                    GameObject.Find("Character").GetComponent<PlayerMovement>().enabled = false;
                    GameObject.Find("Character").GetComponent<PlayerAttack>().enabled = false;
                    GameManager.instance.Ending();
                    Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        canbePickedUp = true;
    }

    private void OnTriggerExit2D(Collider2D other) {
        canbePickedUp = false;
    }

}
