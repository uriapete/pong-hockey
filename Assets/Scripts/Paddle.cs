using UnityEngine;

public class Paddle : MonoBehaviour
{
    //LEFT
    public GameObject paddleL;
    private Rigidbody2D rigidbodyL;
    private float verticalMovementL;

    //RIGHT
    public GameObject paddleR;
    private Rigidbody2D rigidbodyR;   
    private float verticalMovementR;


    private float moveSpeed = 5;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //LEFT
        rigidbodyL = paddleL.GetComponent<Rigidbody2D>();

        //RIGHT
        rigidbodyR = paddleR.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //LEFT
        verticalMovementL = Input.GetAxis("VerticalL");
        rigidbodyL.linearVelocity = new Vector2(0f, verticalMovementL * moveSpeed);

        //RIGHT
        verticalMovementR = Input.GetAxis("VerticalR");
        rigidbodyR.linearVelocity = new Vector2(0f, verticalMovementR * moveSpeed);
    }
}
