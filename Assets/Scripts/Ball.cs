using UnityEngine;

public class Ball : MonoBehaviour
{
    public float Speed { get; private set; } = 5;

    // the RB node for the ball is here.
    Rigidbody2D ballRB;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // get the ball's RB.
        ballRB = this.GetComponent<Rigidbody2D>();
    }

    void Serve()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
