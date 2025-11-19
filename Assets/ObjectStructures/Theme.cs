using UnityEngine;

[CreateAssetMenu(fileName = "Theme", menuName = "Scriptable Objects/Theme")]
public class Theme : ScriptableObject
{
    // The Sprites that will be used for the specified objects.
    public SpriteRenderer Background;
    public SpriteRenderer Ball;
    public SpriteRenderer PaddleR;
    public SpriteRenderer PaddleL;
}
