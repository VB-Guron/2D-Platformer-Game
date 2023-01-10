using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneManager : MonoBehaviour
{   
    private  GameObject toolTip;
    private Animator Doors;
    public bool openDoors;
    public GameObject DeadBanner;
    public GameObject WinBanner;
    public GameObject Fireworks;
    
    private TextMeshProUGUI toolTipKeyText;
    private bool pressedOnce;

    private float respawn;

    public static SceneManager instance;

    bool nextLevel;

    public GameObject other;

    public GameObject placePosition1;
    public GameObject placePosition2;

    private void Start() {
        
    }

    public void Awake(){
        //if(SceneManager.instance != null){
           // Destroy(gameObject);
            //return;
        //}
        //DontDestroyOnLoad(this.gameObject);
        pressedOnce = true;
        Time.timeScale = 1;
        Doors = GetComponent<Animator>();
        openDoors = false;
        nextLevel = false;
 
        DeadBanner.SetActive(false);    
        toolTipKeyText = GameObject.FindGameObjectWithTag("ToolTipKey").GetComponent<TextMeshProUGUI>();
        toolTipKeyText.text = "";
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.E)){
            if(openDoors){
                if(nextLevel){
                    WinBanner.SetActive(true);
                    other.GetComponent<PlayerMovement>().enabled = false;
                    other.GetComponent<PlayerAttack>().enabled = false;
                }
            }
        }
        if(Input.GetKeyDown(KeyCode.Q)){
            
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
        }
        if(Input.GetKeyDown(KeyCode.R)){
            
        GameObject.FindWithTag("Player").GetComponent<Health>().TakeDamage(3);
        }

        if(Input.GetKeyDown(KeyCode.T)){
            other.transform.position = placePosition1.transform.position;
        }
        if(Input.GetKeyDown(KeyCode.Y)){
            other.transform.position = placePosition2.transform.position;
        }

    }

    public bool checkForKey(Collider2D collision){
        return collision.GetComponent<Inventory>().checkKeyInventory();
    }

    public void GameReset(){
        
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        
        GameManager.instance.resetCoins();
    }

    public void Level1(){
       UnityEngine.SceneManagement.SceneManager.LoadScene("Level1"); 
       GameManager.instance.resetCoins();
    }


    public void Level2(){
       UnityEngine.SceneManagement.SceneManager.LoadScene("Level2"); 
       GameManager.instance.resetCoins();
    }

    public void Level3(){
       UnityEngine.SceneManagement.SceneManager.LoadScene("Level3"); 
       GameManager.instance.resetCoins();
    }

    public void MainMenu(){
       UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu"); 
       GameManager.instance.resetHealth();
       GameManager.instance.resetCoins();
       GameManager.instance.resetRespawn(0);

    }

    public void NextLevel(){
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "Player"){
            if(!openDoors){
                if(checkForKey(collision)){
                    openDoors = true;
                    Doors.SetBool("DoorOpen", openDoors);
                    

                }else{
                    toolTipKeyText.text = "Please look for the key";

                }
            }else{
                

            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player"){
            Debug.Log("No Key");
            toolTipKeyText.text = "";
            nextLevel = false;

        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        if(openDoors){
            toolTipKeyText.text = "Press E to proceed to the next level";
            nextLevel = true;
        }
    }


}
