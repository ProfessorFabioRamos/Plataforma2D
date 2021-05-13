using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float movementSpeed = 2;
    Rigidbody2D rig;
    SpriteRenderer spr;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        rig.velocity = new Vector2(movementSpeed, rig.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Limit"){
            movementSpeed *= -1;
            Flip();
        }
    }

    void Flip(){
        spr.flipX = !spr.flipX;
    }
}
