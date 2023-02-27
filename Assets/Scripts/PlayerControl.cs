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
    public float jumpLimit = 2f;

    bool jump = false;

    Animator myAnim;
    SpriteRenderer myRend;

    public GameObject winText;

    Vector3 startPos;

    public GameManager myManager;

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        myRend = GetComponent<SpriteRenderer>();

        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");

        if(Input.GetButtonDown("Jump") && grounded){
            myAnim.SetBool("jumping", true);
            jump = true;
        }
        if(horizontalMove > 0.2f){
            myAnim.SetBool("walking", true);
            myRend.flipX = false;
        } else if(horizontalMove < -0.2){
            myAnim.SetBool("walking", true);
            myRend.flipX = true;
        } else{
            myAnim.SetBool("walking", false);
        }

        if(transform.position.y < -5f){
            transform.position = startPos;
        }

        if (Input.GetButtonDown("Fire1")){
            myAnim.SetTrigger("attacking");
        }
    }

    void FixedUpdate()
    {
        float moveSpeed = horizontalMove * speed;

        if (jump)
        {
            myBody.AddForce(Vector2.up * jumpLimit, ForceMode2D.Impulse);
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
            myAnim.SetBool("jumping", false);
        }
        else
        {
            grounded = false;
        }

        myBody.velocity = new Vector3(moveSpeed, myBody.velocity.y, 0);
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.name == "Goal"){
            winText.SetActive(true);
        }
        if (other.tag == "Star")
        {
            GameObject hitStar = other.gameObject;
            myManager.starObjects.Remove(hitStar);
            Destroy(other.gameObject);
        }
    }
}
