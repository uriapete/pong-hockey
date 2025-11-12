using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class ResolutionManager : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown resolutionDropdown; 
    [SerializeField] private Toggle fullscreenToggle;

    private Resolution[] resolutions;
    private List<Resolution> filteredResolutions;
    private int currentResolutionIndex;

    void Start()
    {
        SetupResolutions();
    }

    private void SetupResolutions()
    {
        resolutions = Screen.resolutions;
        filteredResolutions = new List<Resolution>();
        resolutionDropdown.ClearOptions();

        int currentRefreshRate = (int)Screen.currentResolution.refreshRateRatio.value;

        foreach (var res in resolutions) 
        {
            if ((int)res.refreshRateRatio.value == currentRefreshRate)
                filteredResolutions.Add(res);
        }

        if (filteredResolutions.Count == 0)
            filteredResolutions.AddRange(resolutions);

        List<string> options = new List<string>();
        for (int i = 0; i < filteredResolutions.Count; i++)
        {
            var res = filteredResolutions[i];
            options.Add(res.width + " x " + res.height);

            if (res.width == Screen.width && res.height == Screen.height)
                currentResolutionIndex = i;
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = Mathf.Clamp(currentResolutionIndex, 0, filteredResolutions.Count - 1);
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int index)
    {
        var res = filteredResolutions[index];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
        currentResolutionIndex = index;
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
}
