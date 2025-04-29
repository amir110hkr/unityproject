using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Movement : MonoBehaviour
{
    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        print("hello gamers!");
        
    }
    private void Awake()
    {
        anim=GetComponent<Animator>();
    }
    
    public LayerMask mask;
    public float speed;
    public bool isGrounded;
    public Vector3 groundOffset;
    public float groundRadius;
    public int jumpCount;
    public int maxJump;
    public TextMeshProUGUI jumpText;
    public Animator anim;

   // public Animator graphicsAnimator;

    // Update is called once per frame
    void Update()
    {
        
        if (
       Physics2D.OverlapCircle(transform.position + groundOffset, groundRadius, mask) != null
        )
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
            
        }
        //graphicsAnimator.SetBool("Grounded", isGrounded);


        transform.GetComponent<Rigidbody2D>().velocity =
            new Vector3(Input.GetAxis("Horizontal") * speed,
            transform.GetComponent<Rigidbody2D>().velocity.y,
            0);

        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            //when player is walking
       
            transform.localScale = new Vector2((Input.GetAxisRaw("Horizontal")*-1)*2f, 2f);
        }
        else
        {
        }

        if ((isGrounded || jumpCount > 0) && Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2
                (GetComponent<Rigidbody2D>().velocity.x
                ,9);
            
            jumpCount--;
        }
        if (isGrounded)
        {
            jumpCount = maxJump;
        }
    anim.SetBool("isWalk",Input.GetAxisRaw("Horizontal") !=0);

    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position + groundOffset, groundRadius);
    }
#endif

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print(collision.gameObject.tag + "I have collided");
    }
}


