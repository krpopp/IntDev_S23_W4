using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    float horizontalMove;
    public float speed;

    Rigidbody2D myBody;

    bool grounded = false;

    public float castDist = 0.2f;
    public float gravityScale = 5f;
    public float gravityFall = 40f;
    public float jumpPower = 2f;

    bool jump = false;

    Vector3 startPos;

    GameManager myManager;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        myBody = GetComponent<Rigidbody2D>();
        myManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");

        if(Input.GetButtonDown("Jump") && grounded){
            jump = true;
        }
        if(horizontalMove > 0.2f){
        }

        if(transform.position.y < -5f){
            transform.position = startPos;
        }

    }

    void FixedUpdate()
    {
        float moveSpeed = horizontalMove * speed;

        if (jump)
        {
            myBody.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            jump = false;
        }

        if(myBody.velocity.y > 0)
        {
            myBody.gravityScale = gravityScale;
        } else if(myBody.velocity.y < 0)
        {
            myBody.gravityScale = gravityFall;
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, castDist);
        Debug.DrawRay(transform.position, Vector2.down * castDist, Color.red);

        if(hit.collider != null && hit.transform.name == "Ground")
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }

        myBody.velocity = new Vector3(moveSpeed, myBody.velocity.y, 0);
    }

    void OnTriggerEnter2D(Collider2D other){

    }
}
