using System.Collections;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float Speed { get; private set; } = 5;

    // how many seconds it takes from the ball placed on the board to being served.
    private float SecondsUntilServe { get; } = 2.5F;

    // TEMPORARY VARIABLE - angle at which the ball is served
    // TODO - MAKE THIS ANGLE CHANGE THRUOUT THE GAME!
    public float TEMPServeAngle { get; private set; } = 3 * Mathf.PI / 4;

    // the RB node for the ball is here.
    Rigidbody2D ballRB;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public bool rightScored = false;
    public bool leftScored = false;


    void Start()
    {
        // get the ball's RB.
        ballRB = this.GetComponent<Rigidbody2D>();

        // serve the ball.
        StartNewRound(TEMPServeAngle);
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

    void Serve(float ang)
    {
        Serve(ballRB, Speed, ang);
    }

    // resets the ball's position and velocity to 0,0.
    void Reset()
    {
        ballRB.position = Vector2.zero;
        ballRB.linearVelocity = Vector2.zero;
    }

    // helper function for StartNewRound, allows for waiting
    // Reset the ball, wait SecondsUntilServe seconds, Serve the ball at provided angle.
    IEnumerator NewRoundCoroutine(float ang)
    {
        Reset();

        yield return new WaitForSeconds(SecondsUntilServe);

        Serve(ang);
    }

    // See NewRoundCoroutine.
    public void StartNewRound(float ang)
    {
        // https://stackoverflow.com/questions/30056471/how-to-make-the-script-wait-sleep-in-a-simple-way-in-unity
        StartCoroutine(NewRoundCoroutine(ang));
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LeftWallTag"))
        {
            rightScored = true;
        }
        else if (collision.gameObject.CompareTag("RightWallTag"))
        {
            leftScored = true;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        // if space is pressed, reset ball
        // for testing purposes
        if (Input.GetKeyDown("space"))
        {
            StartNewRound(TEMPServeAngle);
        }
    }

}
