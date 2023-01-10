using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Lever : MonoBehaviour
{
   public Sprite On;
   public Sprite Off;
   public GameObject platform;
   public GameObject myLever;
   public bool toggle;
   public bool nearLever;
   
    public TextMeshProUGUI toolTipKeyText;

   private void Awake() {
       toggle = false;
       nearLever = false;
   }



    private void Update() {
        if(Input.GetKeyDown(KeyCode.E)){
        if(nearLever){
            if(!toggle){
                myLever.GetComponent<SpriteRenderer>().sprite = On;
                platform.SetActive(true);
                toggle = true;
            }else{
                myLever.GetComponent<SpriteRenderer>().sprite = Off;
                platform.SetActive(false);
                toggle = false;
            }
        }
   }
    }

   private void OnTriggerEnter2D(Collider2D other) {
       if(other.tag == "Player"){
           nearLever = true;
           toolTipKeyText.text = "Press [e] to toggle the lever";
       }
   }

   private void OnTriggerExit2D(Collider2D other) {
       if(other.tag == "Player"){
           nearLever = false;
           toolTipKeyText.text = "";

       }
   }
}
