using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : MonoBehaviour
{
    public GameObject UIKey;
    public GameObject Cage;

    public GameObject[] Enemies;

 
    private void Awake() {
        Cage = GameObject.FindGameObjectWithTag("Cage");
    }

    private void Update() {
        if(CheckForEnemies()){
            Cage.SetActive(false);
        }
    }



    private bool CheckForEnemies(){
        for(int i = 0; i < Enemies.Length;i++){
            return !Enemies[i].activeInHierarchy;
        }
        return false;
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(CheckForEnemies()){
            if(collision.tag == "Player"){
                
                collision.GetComponent<Inventory>().hasKey(true);
                gameObject.SetActive(false);
                UIKey.SetActive(true);
            }             
        }
    }





}
