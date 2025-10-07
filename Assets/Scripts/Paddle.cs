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


    private float moveSpeed = 7.5f;

    private float acceleration = 50f;

    private float linDamp = 100f;
    private float linDampDelta = 1f;

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
        if (Mathf.Abs(verticalMovementL) <= 0.01 && lPaddleRB.linearVelocity.magnitude > 0)
        {
            lPaddleRB.linearDamping+=linDampDelta;
        }else if (Mathf.Abs(verticalMovementL) > 0)
        {
            lPaddleRB.linearDamping = 0;
        }
        lPaddleRB.linearVelocity = Vector2.ClampMagnitude(lPaddleRB.linearVelocity, moveSpeed);

        //RIGHT
        verticalMovementR = Input.GetAxis("VerticalR");
        Rigidbody2D rPaddleRB = paddleR.GetComponent<Rigidbody2D>();
        rPaddleRB.AddForceY(verticalMovementR * acceleration);
        if (Mathf.Abs(verticalMovementR) <= 0.01 && rPaddleRB.linearVelocity.magnitude > 0)
        {
            rPaddleRB.linearDamping+=linDampDelta;
        }
        else if (Mathf.Abs(verticalMovementR) > 0)
        {
            rPaddleRB.linearDamping = 0;
        }
        rPaddleRB.linearVelocity = Vector2.ClampMagnitude(rPaddleRB.linearVelocity, moveSpeed);
    }
}
