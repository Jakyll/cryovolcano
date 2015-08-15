using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    [HideInInspector] public bool facingRight = true;
    [HideInInspector] public bool jump = false;

    public float moveSpeed = 1F;
    public float jumpForce = 1000F;
    public Vector2 groundCheckPos;
    public LayerMask Ground;

    private bool grounded = false;
    private Animator anim;
    private Rigidbody2D rb2d;
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
        //grounded = true;
		//Vector2 groundcheck = transform.position;
        //grounded = true;
        //grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        grounded = Physics2D.OverlapCircle(groundCheckPos, 0.2F, Ground);
        
        //Vector3 pos = transform.position;
        //pos.z = -10;
        //Camera.main.transform.position = pos;
		
        if (Input.GetButtonDown("Jump") && grounded)
        {
            jump = true;
        }
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
		
		//anim.SetFloat("Speed", Mathf.Abs(h));
		
		rb2d.velocity = new Vector2(moveSpeed * h, rb2d.velocity.y);
		
		if(jump)
		{
			rb2d.AddForce(new Vector2(0F, jumpForce));
			jump = false;
		}

        //if (h * rb2d.velocity.x < maxSpeed)
		//rb2d.AddForce(Vector2.right * h * moveForce);

        //if (Mathf.Abs (rb2d.velocity.x) > maxSpeed)
        //    rb2d.velocity = new Vector2(Mathf.Sign (rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);

        if (h > 0 && !facingRight)
		{
            Flip ();
		}
		else if (h < 0 && facingRight)
		{
            Flip ();
		}
        //if (jump)
        //{
            //anim.SetTrigger("Jump");
        //    rb2d.AddForce(new Vector2(0f, jumpForce));
        //    jump = false;
        //}
    }


    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}