using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerMovement : MonoBehaviour
{
    public float speed;
    public float move;
    public float jump;
    public bool isJumping;
    private Rigidbody2D rb;
    public Animator animator;
    public bool facingRight=true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(move));

        rb.velocity = new Vector2(speed * move, rb.velocity.y);
        if(facingRight==false && move>0){
            Flip();
        }
        else if(facingRight==true && move<0){
            Flip();
        }
        if (Input.GetButtonDown("Jump") && isJumping==false)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
            Debug.Log("jump");
        }
    }
    private void OnCollisionEnter2D(Collision2D item)
    {
        if (item.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            animator.SetBool("IsJumping", false);
        }
    }
    private void OnCollisionExit2D(Collision2D item)
    {
        if (item.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
            animator.SetBool("IsJumping", true);
        }
    }
    void Flip(){
        facingRight=!facingRight;
        Vector3 scaler=transform.localScale;
        scaler.x*=-1;
        transform.localScale=scaler;
    }
}

