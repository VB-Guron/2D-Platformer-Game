
/* It's a class that handles the health of the player and enemies */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public GameObject DeadPanel;
    [Header ("Health")]
    [SerializeField] private float startingHealth;
    public float currentHealth {get; private set;}
    private Animator anim;
    private bool dead;

    [Header ("iFrames")]    
    [SerializeField] private float invulnerabilityDuration;
    [SerializeField] private float numberOfFlashes;
    private SpriteRenderer spriteRend;

    private SceneManager Manager;

    public GameObject[] RespawnUI;

    private bool cantakeDamage;

    private void Start() {
        cantakeDamage = true;



    }
    private void Awake(){
        if(gameObject.tag == "Player"){
            
            currentHealth = GameManager.instance.getStartingHealth();
            howManyRespawnsLeft();

        }else if(gameObject.tag == "Enemy"){
            currentHealth = 3;
        }

        anim =GetComponent<Animator>();

        spriteRend = GetComponent<SpriteRenderer>();
        


    }

    public void TakeDamage(float _damage){
        if(cantakeDamage){
                currentHealth = Mathf.Clamp(currentHealth - _damage, 0 , startingHealth);
            if(currentHealth > 0){
                anim.SetTrigger("hurt");
                StartCoroutine(Invulnerability());
            }else{
                if(GameManager.instance.getRespawn() == 2){
                    anim.SetTrigger("die");
                    GetComponent<PlayerMovement>().enabled = false;
                    GetComponent<PlayerAttack>().enabled = false;
                    dead = true;
                    GameManager.instance.resetRespawn(0);
                    DeadPanel.SetActive(true);
                    GameObject.Find("GamePlay").SetActive(false);
                }else{
                    cantakeDamage = false;
                    Debug.Log("respawning");
                    anim.SetTrigger("die");
                    StartCoroutine(RespawnSequence());
                }
            }
        }
    }
    public void DamageEnemy(float _damage){
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0 , startingHealth);
        if(currentHealth > 0){
            anim.SetTrigger("hurt");
            StartCoroutine(Invulnerability());
        }else{
            if(!dead){
                
                if(gameObject.name == "Boss"){
                    gameObject.GetComponent<dropping>().DropCrown();
                }
                GetComponent<Enemy_Patrol>().enabled = false;
                GetComponent<Enemy_Attack>().enabled = false;
                anim.SetTrigger("die");
                dead = true;
            }
        }
        
    }
    public void Destroy(){
        gameObject.SetActive(false);
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<Enemy_Patrol>().enabled = false;
        
        Debug.Log("Disabled");
    }

    public void DEAD(){
    }

    public void STOP(){
        
       GetComponent<Enemy_Patrol>().Stop();
    }


    public void AddHealth(float _value){
        
        currentHealth = Mathf.Clamp(currentHealth + _value, 0 , startingHealth);
    }

    private IEnumerator Invulnerability(){
        Physics2D.IgnoreLayerCollision(10, 11, true);
        for(int i = 0; i <numberOfFlashes;i++){
            spriteRend.color = new Color(1,0,0, 0.5f);
            yield return new WaitForSeconds(invulnerabilityDuration/(numberOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(invulnerabilityDuration/(numberOfFlashes * 2));
        }
        //invulnerability duration
        Physics2D.IgnoreLayerCollision(10, 11, false);
    }


    private IEnumerator RespawnSequence(){
        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<PlayerAttack>().enabled = false;
        
                GameManager.instance.updateRespawn();
                GameManager.instance.resetHealth();
        yield return new WaitForSecondsRealtime(2f);
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }

    private void howManyRespawnsLeft(){
        //currently 2(3) | 2 - 0
        Debug.Log("Starting Respawn Count");
        for (int i = 0; i < (3 - GameManager.instance.getRespawn()); i++)
        {
            Debug.Log("Opening " + i +" | " + (3 - GameManager.instance.getRespawn()));
            RespawnUI[i].SetActive(true);
        }
    }
}
