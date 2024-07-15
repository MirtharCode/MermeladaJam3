using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MenuOpciones : MonoBehaviour
{
    Resolution[] resolutions;
    public TMP_Dropdown resolutionDropdown;
    List<Resolution> filteredResolutionList;

    private float currentRefreshRate;
    private int currentResolutionIndex = 0;
    [SerializeField]
    AudioMixer audioMixer;

    
    public GameObject panelOpciones;

    public Slider sliderMusica;
    public Slider sliderFVX;

    public AudioSource asMover;
    public AudioSource asPulsar;


    // Start is called before the first frame update
    void Start()
    {
        resolutions = Screen.resolutions;
        filteredResolutionList = new List<Resolution>();

        resolutionDropdown.ClearOptions();
        currentRefreshRate = Screen.currentResolution.refreshRate;

        for (int i = 0; i < resolutions.Length; i++)
        {
            if (resolutions[i].refreshRate == currentRefreshRate)
            {
                filteredResolutionList.Add(resolutions[i]);
            }
        }

        List<string> options = new List<string>();

        for (int i = 0; i < filteredResolutionList.Count; i++)
        {
            string resolutionOption = filteredResolutionList[i].width + "x" + filteredResolutionList[i].height + " " + filteredResolutionList[i].refreshRate + "Hz";
            options.Add(resolutionOption);
            if (filteredResolutionList[i].width == Screen.width && filteredResolutionList[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);

        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void FullScreen(bool fullscreen)
    {

        Debug.Log("Fullscreen es: " + fullscreen);
        Screen.fullScreen = fullscreen;
    }

    public void ChangeResolution(int resolutionIndex)
    {
        Resolution resolution = filteredResolutionList[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, true);

        Debug.Log("resolution es: " + filteredResolutionList[resolutionIndex]);
    }

    public void changeVolumenMusica(float slidervalue)
    {
        audioMixer.SetFloat("Musica", Mathf.Log10(slidervalue) * 20);
    }

    public void changeVolumenFX(float slidervalue)
    {
        audioMixer.SetFloat("FVX", Mathf.Log10(slidervalue) * 20);
    }

    public void ocultarMenuOpciones()
    {
        GuardarOpciones();

        asPulsar.Play();
        panelOpciones.SetActive(false);
    }

    public void GuardarOpciones()
    {
        PlayerPrefs.SetFloat("Musica", sliderMusica.value);
        PlayerPrefs.SetFloat("FVX", sliderFVX.value);
        PlayerPrefs.Save();
    }

}