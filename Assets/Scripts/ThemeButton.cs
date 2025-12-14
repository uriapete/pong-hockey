using UnityEngine;

public class ThemeButton : MonoBehaviour
{
    // What theme this button will load.
    public Theme Theme;

    // The manager that this button will pass its Theme to.
    // private as we won't set this in unity, will be passed to script constructor
    private ThemeManager ThemeManager;

    public ThemeButton(Theme theme)
    {
        this.Theme = theme;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
