using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class ResolutionManager : MonoBehaviour
{
    public TMP_Dropdown ResolutionDropdown;
    public Toggle FullScreenToggle;

    Resolution[] AllResolutions;
    bool IsFullScreen;
    int SelectedResolution;

    void Start()
    {
        IsFullScreen = true;
        AllResolutions = Screen.resolutions;

        List<string> resolutionStringList = new List<string>();
        foreach (ResolutionManager res in AllResolutions)
        {
            resolutionStringList.Add(res.ToString());
        }

        ResolutionDropdown.AddOptions(resolutionStringList);
    }

}
