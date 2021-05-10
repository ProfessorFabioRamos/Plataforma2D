using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //MOVIMENTACAO
    public float moveSpeed = 2.0f;

    //PULO
    public float jumpForce = 200;
    public Transform groundCheck;
    public float circleOverlapRadius = 0.2f;
    public LayerMask whatIsGround;

    //COMPONENTES
    private Rigidbody2D rig;
    private Animator anim;
    private SpriteRenderer spr;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
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
    }

    void Flip(bool faceRight){
        spr.flipX = !faceRight;
    }
}
