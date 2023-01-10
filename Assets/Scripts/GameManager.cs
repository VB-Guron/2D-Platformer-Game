
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    [Header ("Health")]
    [SerializeField] private float startingHealth;
    [SerializeField] private float currentHealth;
    [SerializeField] private float respawn;


    [Header ("Collectible")]
    [SerializeField] private float coins;


    private void Awake() {
        if(GameManager.instance != null){
           Destroy(gameObject);
           return;
        }
       
       instance = this;

        DontDestroyOnLoad(gameObject);
    }
    public void updateCurrentHealth(float number){
        currentHealth += number;
    }


    public float getCurrentHealth(){
        return currentHealth;
    }
    public float getStartingHealth(){
        return startingHealth;
    }
    public void resetHealth(){
        currentHealth = startingHealth;
    }

    public void updatedCoins(float coinGain){
        coins += coinGain;
    }

    public float getCoins(){
        return coins;
    }public void resetCoins(){
        coins = 0;
    }
    public void updateRespawn(){
        respawn = respawn + 1;
    }

    public float getRespawn(){
        return respawn;
    }

    public void resetRespawn(float points){
        respawn = points;
    }

    public void Ending(){
        StartCoroutine(endSequence());
    }

    private IEnumerator endSequence(){
        GameObject.Find("Door").GetComponent<SceneManager>().Fireworks.transform.position = GameObject.Find("Character").transform.position;
        GameObject.Find("Door").GetComponent<SceneManager>().Fireworks.SetActive(true);
        yield return new WaitForSecondsRealtime(5f);
        GameObject.Find("Door").GetComponent<SceneManager>().WinBanner.SetActive(true);
    }
}
