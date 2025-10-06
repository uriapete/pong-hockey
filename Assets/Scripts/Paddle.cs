using System.Collections.Specialized;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    //LEFT
    public GameObject paddleL;
    private BoxCollider2D bcL;
    private float verticalMovementL;

    //RIGHT
    public GameObject paddleR;
    private BoxCollider2D bcR;   
    private float verticalMovementR;


    private float moveSpeed = 5f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //LEFT
        bcL = paddleL.GetComponent<BoxCollider2D>();

        //RIGHT
        bcR = paddleR.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        

        //LEFT
        
        verticalMovementL = Input.GetAxis("VerticalL");
        
        //paddleL.transform.Translate(0f, verticalMovementL * moveSpeed, 0f);
        paddleL.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0f, verticalMovementL * moveSpeed);

        //RIGHT
        verticalMovementR = Input.GetAxis("VerticalR");
        //paddleR.transform.Translate(0f, verticalMovementR * moveSpeed, 0f);
        paddleR.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0f, verticalMovementR * moveSpeed);
    }
}
