using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using System.Linq;

public class ResolutionManager : MonoBehaviour
{
    [Header("Drop down UI Elements to be messed with >:)")]
    [SerializeField] private TMP_Dropdown resolutionDropdown; 
    [SerializeField] private Toggle fullscreenToggle;
    
    private Resolution[] filteredResolutions; // array that stores filtered resolutions
    private List<string> resolutionOptions = new List<string>(); // list of strings for the dropdown UI


    void Start()
    {
        UpdateObjectPositions();

        bool isCurrentlyFullscreen = Screen.fullScreen;

        if (fullscreenToggle != null)
        {
            fullscreenToggle.isOn = isCurrentlyFullscreen;
        }
    }

    public void UpdateObjectPositions()
    {
        CalculateScreenBounds();
        PositionWalls();
        PositionPaddles();
        //Debug.Log("Screen boundaries updated for new resolution.");

    }
    void Awake()
    {
        SetupAvailableResolutions();
        //
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        Debug.Log("Fullscreen is " + isFullscreen);
    }


    void SetupAvailableResolutions()
    {
        Resolution[] allResolutions = Screen.resolutions; // populate array w/ all available resolutions (width, height, refreshRate)
    

        filteredResolutions = allResolutions.GroupBy(res => new {res.width, res.height,}).Select(g => g.First()).ToArray(); 
        //^^LINQ can filter out duplicate widths/heights by keeping only distinct values.^^

        resolutionDropdown.ClearOptions();
        resolutionOptions.Clear();
        
        int currentResolutionIndex = 0;

        //iterate through every filtered array and format them
        for (int i = 0; i < filteredResolutions.Length; i++)
        {
            string option = filteredResolutions[i].width + "x" + filteredResolutions[i].height;
            resolutionOptions.Add(option); // Add the list of strings
            
            // also determine which resolution the game is currently using
            if (filteredResolutions[i].width == Screen.currentResolution.width && 
                filteredResolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(resolutionOptions);
        
        resolutionDropdown.onValueChanged.RemoveListener(ApplyResolution); // fix for nulling race condiiton issue

        resolutionDropdown.value = currentResolutionIndex; // need to sneak this bad boy in so Unity doesn't bark at it

        resolutionDropdown.onValueChanged.AddListener(ApplyResolution); // end of fix
        
        resolutionDropdown.RefreshShownValue();

    }
    public void ApplyResolution(int resolutionIndex)
    {
        if (filteredResolutions == null || filteredResolutions.Length == 0) //don't get rid of this
        {
            //Debug.LogWarning("resolutions not initialized yet, race condition");
            return;
        }

        if (resolutionIndex >= 0 && resolutionIndex < filteredResolutions.Length) 
        {
            Resolution selectedResolution = filteredResolutions[resolutionIndex];
            
            Screen.SetResolution(selectedResolution.width, selectedResolution.height, Screen.fullScreen);
            
            Debug.Log($"Changed resolution to: {selectedResolution.width}x{selectedResolution.height}");

            Invoke("CallUpdatePositions", 0.1f);
            
        
        }
    }

    /// 
    /// Updating and transforming positions with new screen resolutions.
    /// 
    
    [Header("Everything that needs position updates")]

    public Transform leftWall;
    public Transform rightWall;
    public Transform topWall;
    public Transform bottomWall;
    public Transform leftPaddle;
    public Transform rightPaddle;
    
    public float wallThickness = 1.0f; 
    public float paddlePadding = 1.0f;

    private float screenLeft;
    private float screenRight;
    private float screenTop;
    private float screenBottom;

    private void CalculateScreenBounds()
    {
        Camera mainCamera = Camera.main;
        Vector3 bottomLeftCorner = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, mainCamera.nearClipPlane));
        Vector3 topRightCorner = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, mainCamera.nearClipPlane));

        screenLeft = bottomLeftCorner.x;
        screenRight = topRightCorner.x;
        screenBottom = bottomLeftCorner.y;
        screenTop = topRightCorner.y;
    }

    private void PositionWalls()
    {
        // Define half of the wall thickness for positioning offset
        float halfWall = wallThickness / 2f;
        float screenHeight = screenTop - screenBottom;
        float screenWidth = screenRight - screenLeft;

        // Left and Right Walls
        if (leftWall != null)
        {
            leftWall.position = new Vector3(screenLeft - halfWall, 0, 0);
            leftWall.localScale = new Vector3(wallThickness, screenHeight, 1);
        }
        if (rightWall != null)
        {
            rightWall.position = new Vector3(screenRight + halfWall, 0, 0);
            rightWall.localScale = new Vector3(wallThickness, screenHeight, 1);
        }

        // Top and Bottom Walls
        if (topWall != null)
        {
            topWall.position = new Vector3(0, screenTop + halfWall, 0);
            topWall.localScale = new Vector3(screenWidth, wallThickness, 1);
        }
        if (bottomWall != null)
        {
            bottomWall.position = new Vector3(0, screenBottom - halfWall, 0);
            bottomWall.localScale = new Vector3(screenWidth, wallThickness, 1);
        }
    }

    private void PositionPaddles()
    {
        // Paddles
        if (leftPaddle != null)
        {
            leftPaddle.position = new Vector3(screenLeft + paddlePadding, 0, 0);
        }
        if (rightPaddle != null)
        {
            rightPaddle.position = new Vector3(screenRight - paddlePadding, 0, 0);
        }
    }

}
