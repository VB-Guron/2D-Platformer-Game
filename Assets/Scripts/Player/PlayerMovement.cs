
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] public float speed;
    [SerializeField] public float jumpPower;
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;

    private float wallJumpCooldown;
    float horizontalInput;

    public AudioSource footsteps;


    private void Awake(){
        //Grab Reference from the Character
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        footsteps = GetComponent<AudioSource>();

    

    }

    public void Footstep(){
        footsteps.Play();
    }

    private void Update(){
        // Movement Left and Right
        horizontalInput = Input.GetAxis("Horizontal");

        //Character Facing
        if(horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if(horizontalInput < -0.01f)  
            transform.localScale = new Vector3(-1,1,1);


        // JUMP
        
        
        //Set Animator Parameters
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", isGrounded());
        anim.SetBool("onWalls", onWall());

        //Wall Jump Logic
        if(wallJumpCooldown > 0.2f){
            
            
            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
        
            if(onWall() && !isGrounded()){
                body.gravityScale = 0.9f;
                body.velocity = Vector2.zero;
            }else
                body.gravityScale = 2;

            if(Input.GetKey(KeyCode.Space)){
                Jump();
            }    
            
        }else{
            wallJumpCooldown += Time.deltaTime;
        }
        
        if(Input.GetKey(KeyCode.E)){
        }
    }

    public void LevelWin(){
    }
    public void WinAnimation(){
        
            anim.SetTrigger("win");
    }
    public void Win(){
            body.velocity = new Vector2(body.velocity.x, 4);
    }

    private void Jump(){
        if(isGrounded()){
            body.velocity = new Vector2(body.velocity.x, jumpPower);
            anim.SetTrigger("jump");
        }else if(onWall() && !isGrounded()){
            
            wallJumpCooldown = 0;
            body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x)*1, 5);
        }
    }


    private bool isGrounded(){
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
    private bool onWall(){
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x,0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }

    public bool canAttack(){
        return !onWall();
    }
}
