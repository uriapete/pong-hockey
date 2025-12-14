using UnityEngine;

[CreateAssetMenu(fileName = "Theme", menuName = "Scriptable Objects/Theme")]
public class Theme : ScriptableObject
{
    // name of the theme.
    public string Name;

    // The Sprites that will be used for the specified objects.
    public Sprite Background;
    public Sprite Ball;
    public Sprite Paddle;

    // Background music
    public AudioClip BackgroundMusic;

    // Sound FX
    // sounds for when the ball hits the paddle.
    public AudioClip PaddleHit1SFX;
    public AudioClip PaddleHit2SFX;

    // sounds for when a player scores.
    public AudioClip Scored1SFX;
    public AudioClip Scored2SFX;

    // square preview for the theme.
    public Sprite Thumbnail;
}
