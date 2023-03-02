using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvControls : MonoBehaviour
{

    Rigidbody2D myBody;
    SpriteRenderer myRenderer;

    int walkCounterH = 0;

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            myBody.velocity = new Vector2(1, 0);
            //if we're just now moving, so
            //if(walkCounterH == 0){
            //then change the animation
            //myAnim.SetBool("walking", true);
            myRenderer.flipX = true;
            walkCounterH++;
        }
        else if (Input.GetKey(KeyCode.A))
        {

        }
        else
        {

        }

        if (Input.GetKey(KeyCode.S))
        {

        }
        else if (Input.GetKey(KeyCode.W))
        {

        }
        else
        {

        }
    }
}
