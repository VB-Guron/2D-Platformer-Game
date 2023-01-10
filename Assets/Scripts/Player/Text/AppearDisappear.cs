using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AppearDisappear : MonoBehaviour
{
    private TextMeshProUGUI cageText;



    private void Awake() {
        cageText = GameObject.FindGameObjectWithTag("CageText").GetComponent<TextMeshProUGUI>();
        cageText.text = "";

    }


    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            cageText.text = "Defeat the enemy to unlock the cage";
        }
    }


    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player"){
            cageText.text = "";
        }
    }
}
