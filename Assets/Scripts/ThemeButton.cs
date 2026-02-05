using UnityEngine;
using UnityEngine.UI;

public class ThemeButton : MonoBehaviour
{
    // What theme this button will load.
    public Theme Theme;

    // The manager that this button will pass its Theme to.
    // public to expl set in unity
    public ThemeManager ThemeManager;

    // Thumbnail component, sets thumbnail
    public Image ThumbnailRenderer;

    public ThemeButton(Theme theme, ThemeManager manager)
    {
        this.Theme = theme;
        this.ThemeManager=manager;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // loads thumbnail on load
        ThumbnailRenderer.sprite=Theme.Thumbnail;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeBtnTheme(Theme theme){
        // loads thumbnail on load
        Theme = theme;
        ThumbnailRenderer.sprite=Theme.Thumbnail;
    }

    // Tells the ThemeManager to change it's theme to this button's Theme.
    public void LoadTheme()
    {
        // if the current theme is already set to this theme, dont do anything
        if (ThemeManager.currentTheme.Equals(Theme))
        {
            return;
        }
        ThemeManager.PickTheme(Theme);
    }
}
