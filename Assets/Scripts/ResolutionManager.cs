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
        //
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
        if (filteredResolutions == null || filteredResolutions.Length == 0) //don't get rid of this, trust me.
        {
            //Debug.LogWarning("flipping race condition: resolutions not initialized yet.");
            return; // Exit safely if data isn't ready
        }

        if (resolutionIndex >= 0 && resolutionIndex < filteredResolutions.Length) 
        {
            Resolution selectedResolution = filteredResolutions[resolutionIndex];
            
            Screen.SetResolution(selectedResolution.width, selectedResolution.height, FullScreenMode.Windowed);
            
            Debug.Log($"Changed resolution to: {selectedResolution.width}x{selectedResolution.height}");
        
        }
    }

}
