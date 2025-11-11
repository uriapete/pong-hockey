using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class SettingsManager : MonoBehaviour
{
    public Dropdown resolutionDropdown;
    Resolution[] resolutions; //array for resolution options

    public void SetFullScreen(bool isFullScreen) //checks if the game is fullscreen for the toggle 
    {
        Screen.fullScreen = isFullScreen;
    }
    
    void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions(); //clears out all options in the dropdown initially

        List<string> options = new List<string>(); // creates a list of strings (the options)

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)// loop through each element in the resolutions array
        {
            string option = resolutions[i].width + " x " + resolutions[i].height; //create a nicely formatted string that displays resolution
            options.Add(option); //add to options list

            if (resolutions[i] == Screen.currentResolution.width && 
            resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(); //add the options list to the dropdown)
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }
}