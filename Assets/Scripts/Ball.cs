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

        // serve the ball.
        Serve(ballRB,Speed,3*Mathf.PI/4);
    }

    // inits the ball with a starting velocity.
    // the angle is in radians and relative, counterclock to RIGHT
    void Serve(Rigidbody2D rb, float spd, float ang)
    {
        // the speed is the "hypotenuse". To get the x or y components, get the sine (y) or cosine (x) of the angle, then multiply by the speed.
        Vector2 serveVelo = new Vector2(Mathf.Cos(ang) * Speed, Mathf.Sin(ang) * Speed);

        // set the rb's velocity.
        rb.linearVelocity = serveVelo;
    }

    // resets the ball's position and velocity to 0,0.
    void Reset()
    {
        ballRB.position = Vector2.zero;
        ballRB.linearVelocity = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        // if space is pressed, reset ball
        // for testing purposes
        if (Input.GetKeyDown("space"))
        {
            Reset();
        }
    }
}
