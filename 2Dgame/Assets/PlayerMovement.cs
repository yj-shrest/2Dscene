using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
 
    public float speed;
    private float move;
    private Rigidbody2D rb;
    public float jump;
    private bool isJumping;
    private bool trapped;
    public GameObject startpoint;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * speed, rb.velocity.y);
       //transform.rotation = Quaternion.Euler(0, 0, 0);

        if ((Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.UpArrow)) && !isJumping)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
        }
        if(isdead() || trapped)
        {
            transform.position = startpoint.transform.position;
            trapped = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
        
        if(other.gameObject.CompareTag("Trap"))
        {
            trapped = true;
        }

    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }
    }
    private bool isdead()
    {
        if (transform.position.y < -2)
        {
            return true;
        }
        else return false;
    }
}
