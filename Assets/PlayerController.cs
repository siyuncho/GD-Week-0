using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{   
    private Vector2 movementVector;
    private Rigidbody2D rb;
    private bool canJump = false;
    private bool canDoubleJump = false;
    [SerializeField] int speed = 0;

    // Start is called before thes first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //rb.velocity = movementVector;
        rb.velocity = new Vector2(speed*rb.velocity.x,rb.velocity.y);
    }

    void OnMove(InputValue value)
    {
        movementVector = value.Get<Vector2>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            canJump = true;
            canDoubleJump = true;
        }
        rb.AddForce(new Vector2(0,200));
    }

    void OnJump()
    {
        if(canJump == true && canDoubleJump == true)
        {
            rb.AddForce(new Vector2(0,300));
            canJump = false;
        }
        else if(canJump == false && canDoubleJump == true)
        {
            rb.AddForce(new Vector2(0,300));
            canDoubleJump = false;
        }
    }
}
