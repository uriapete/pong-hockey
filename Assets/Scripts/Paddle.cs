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


    private float moveSpeed = 0.1f;
    
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
        paddleL.transform.Translate(0f, verticalMovementL * moveSpeed, 0f);

        //RIGHT
        verticalMovementR = Input.GetAxis("VerticalR");
        paddleR.transform.Translate(0f, verticalMovementR * moveSpeed, 0f);
    }
}
