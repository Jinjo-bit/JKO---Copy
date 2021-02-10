using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;

    private Animator anim;
    private Rigidbody2D MyRigidbody;

    private bool PlayerMoving;

    private Vector2 lastMove;
    // Start is called before the first frame update
    void Start()
    {
        
        anim = GetComponent<Animator>();
        MyRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoving = false;
        if (Input.GetAxisRaw("Horizontal")>0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            //transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
            MyRigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal")*moveSpeed, MyRigidbody.velocity.y);
              PlayerMoving = true;

            lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
        }

        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f) 
        {
            // transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime,  0f));
            MyRigidbody.velocity = new Vector2(MyRigidbody.velocity.x, Input.GetAxisRaw("Vertical")* moveSpeed);
            PlayerMoving = true;
            lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
        }

        if(Input.GetAxisRaw("Horizontal") <0.5f && Input.GetAxisRaw("Horizontal") > -0.5f)
        {
            MyRigidbody.velocity = new Vector2(0f, MyRigidbody.velocity.y);
        }

        if (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f)
        {
            MyRigidbody.velocity = new Vector2(MyRigidbody.velocity.x, 0f);
        }


            anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anim.SetBool("PlayerMoving", PlayerMoving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);
    }
}
