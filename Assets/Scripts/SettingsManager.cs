using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class SettingsManager : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown; //references UnityEngine.UI element 
    Resolution[] resolutions; //list of resolution options

    public void SetFullScreen(bool isFullScreen) //checks if the game is fullscreen for the toggle 
    {
        Screen.fullScreen = isFullScreen;
    }
    
    void Start()
    {
        resolutions = Screen.resolutions; // Screen.resolutions accesses unity's list of available screen resolutions

        resolutionDropdown.ClearOptions(); //clears out all options in the dropdown initially

        List<string> options = new List<string>(); // creates a list of strings (the options)

        //int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)// loop through each element in the resolutions array
        {
            string option = resolutions[i].width + " x " + resolutions[i].height; //create a nicely formatted string that displays resolution
            options.Add(option); //add to options list

            //if (resolutions[i] == Screen.currentResolution.width && 
            //resolutions[i].height == Screen.currentResolution.height)
            {
                //currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options); //add the options list to the dropdown (note: takes in strings not arrays)
        //resolutionDropdown.value = currentResolutionIndex;
        //resolutionDropdown.RefreshShownValue();
    }
}