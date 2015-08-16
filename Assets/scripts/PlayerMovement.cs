using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    [HideInInspector] public bool facingRight = true;
    [HideInInspector] public bool jump = false;

    public float moveSpeed = 1F;
    public float jumpForce = 1000F;    
    public LayerMask Ground;

    private Animator anim;
    private Rigidbody2D rb2d;
	
	private bool grounded = false;
	private Vector2 groundCheckPos;
    private float gcY;

    void Awake () 
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }
    
    void Update () 
    {
        gcY = (transform.position.y - 0.2F);
        groundCheckPos = new Vector2(transform.position.x, gcY);

        grounded = Physics2D.OverlapCircle(groundCheckPos, 0.125F, Ground);

        if (Input.GetButtonDown("Jump") && grounded)
        {
            jump = true;
        }
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
		
		if(grounded)
		{
			rb2d.velocity = new Vector2(moveSpeed * h, rb2d.velocity.y);
		}
		else
		{
			rb2d.velocity = new Vector2(moveSpeed * h / 2, rb2d.velocity.y);
		}
		
		
		if(jump)
		{
			rb2d.AddForce(new Vector2(0F, jumpForce));
			jump = false;
		}

		//================================
		
		if(grounded)
		{
			if(h != 0)
			{
				anim.SetTrigger("Walk");
			}
			else
			{
				anim.SetTrigger("Idle");
			}
		}
		else
		{
			anim.SetTrigger("Fall");
		}

		
		
        if (h > 0 && !facingRight)
		{
            Flip ();
		}
		else if (h < 0 && facingRight)
		{
            Flip ();
		}
    }


    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}