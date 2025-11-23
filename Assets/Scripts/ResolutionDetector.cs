using UnityEngine;
using UnityEngine.EventSystems;

public class ResolutionDetector : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler
{

    [SerializeField] public ResolutionManager gameResolutionManager; 

    private Vector2 lastKnownResolution;

    void Start()
    {
        lastKnownResolution = new Vector2(Screen.width, Screen.height);

        if (gameResolutionManager == null)
        {
            gameResolutionManager = FindObjectOfType<ResolutionManager>();
        } 
    }
 
    // This method is called automatically by the UI system when dimensions change
    public void OnRectTransformDimensionsChange()
    {
        Vector2 currentResolution = new Vector2(Screen.width, Screen.height);

        // Only update if the resolution actually changed
        if (currentResolution != lastKnownResolution)
        {
            lastKnownResolution = currentResolution;
            
            if (gameResolutionManager != null)
            {
                // Call the function that updates all your paddles and walls
                gameResolutionManager.UpdateObjectPositions();
                Debug.Log("Triggered physical object update via UI detector.");
            }
        }
    }

    // Required for the IPointerEnterHandler interface, even if empty
    public void OnPointerEnter(PointerEventData eventData) { }
}
