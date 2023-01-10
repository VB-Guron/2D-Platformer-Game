/* This class is used to keep track of the player's inventory. */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public bool key;
    public float coin;
    public Text coinCounter;
    public AudioSource sound;

    private void Awake(){
        key = false;
        sound = GameObject.Find("colectSound").GetComponent<AudioSource>();
    }

    private void Start(){
        
        if(GameManager.instance.getCoins() == 0){

        }else{
            coin = GameManager.instance.getCoins();
            coinCounter.text = coin + "";
        }
    }

    public void Update(){
        coinCounter.text = coin + "";
    }


    public void hasKey(bool change){
        key = change;
    }

    public bool checkKeyInventory(){
        return key;
    }

    public void addCoin(float amount){
        sound.PlayOneShot(sound.clip, 0.3f);
        GameManager.instance.updatedCoins(amount);
        coin += amount;
    }
}


