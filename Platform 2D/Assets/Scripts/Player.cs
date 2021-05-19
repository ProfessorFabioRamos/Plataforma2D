using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //MOVIMENTACAO
    public float moveSpeed = 2.0f;
    private float xOrientation = 1;

    //PULO
    public float jumpForce = 200;
    public Transform groundCheck;
    public float circleOverlapRadius = 0.2f;
    public LayerMask whatIsGround;

    public BoxCollider2D attackArea;
    //COMPONENTES
    private Rigidbody2D rig;
    private Animator anim;
    private SpriteRenderer spr;
    private Enemy enemyInArea = null;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
        attackArea = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        rig.velocity = new Vector2(h*moveSpeed, rig.velocity.y);
        anim.SetFloat("speed", Mathf.Abs(h));

        if(h > 0 ) Flip(true);
        else if(h <0) Flip(false);

        bool grounded = Physics2D.OverlapCircle(groundCheck.position, circleOverlapRadius, whatIsGround);

        if(Input.GetButtonDown("Jump") && grounded){
            rig.AddForce(new Vector2(0, jumpForce),ForceMode2D.Force);
        }
        anim.SetBool("grounded", grounded);

        if(Input.GetKeyDown(KeyCode.X)){
            AttackAnimation();
        }
    }

    void AttackAnimation(){
        anim.SetTrigger("attack");
    }

    public void DamageEnemy(){
        if(enemyInArea != null && enemyInArea.enemyHP > 0){
            enemyInArea.TakeDamage(1);
        }
    }

    void Flip(bool faceRight){
        spr.flipX = !faceRight;

        if(faceRight) xOrientation=1;
        else xOrientation=-1;
        attackArea.offset = new Vector2(xOrientation,attackArea.offset.y);
    }

    void OnTriggerStay2D(Collider2D other){
        if(other.gameObject.layer == 7){
            enemyInArea = other.GetComponent<Enemy>();
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.layer == 7){
            enemyInArea = null;
        }
    }
}
