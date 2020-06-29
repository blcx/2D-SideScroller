using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [Range(1, 10)]
    public float jumpVelocity;    
    Rigidbody2D rb;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    float horizontal;
    public float moveSpeed;

    Feet feet;

    // Start is called before the first frame update
    void Awake()
    {
       rb = GetComponent<Rigidbody2D>();
        feet = gameObject.GetComponentInChildren<Feet>();
    }

    // Update is called once per frame
    void Update()
    {

        Jump();
        BetterJump();
        Movement();
        
    }







    void Jump()
    {
        if (Input.GetButtonDown("Jump") && feet.isGround)
        {
            rb.velocity = Vector2.up * jumpVelocity;
        }
    }




    void BetterJump()
    {
        if (rb.velocity.y < 0) //if falling down
        {
            //faster fall
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;

        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump")) //if jumping up
        {

            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;


        }
    }


    void Movement()
    {

       horizontal = Input.GetAxis("Horizontal");

        transform.position += new Vector3(horizontal,0f,0f) * Time.deltaTime * moveSpeed;
    
    }











}
