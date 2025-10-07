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

    private float acceleration = 20f;

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
        Rigidbody2D lPaddleRB = paddleL.GetComponent<Rigidbody2D>();
        lPaddleRB.AddForceY(verticalMovementL * acceleration);
        lPaddleRB.linearVelocity = Vector2.ClampMagnitude(lPaddleRB.linearVelocity, moveSpeed);

        //RIGHT
        verticalMovementR = Input.GetAxis("VerticalR");
        Rigidbody2D rPaddleRB = paddleR.GetComponent<Rigidbody2D>();
        rPaddleRB.AddForceY(verticalMovementR * acceleration);
        rPaddleRB.linearVelocity = Vector2.ClampMagnitude(rPaddleRB.linearVelocity, moveSpeed);
    }
}
