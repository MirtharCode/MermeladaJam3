using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPrincipal : MonoBehaviour
{
    public Animator animatorCorazon;
    public Animator animatorEngranaje;
    public Animator animatorIntro;
    public GameObject panelOpciones;
    public GameObject panelCreditos;
    public GameObject panelIntro1;
    public GameObject panelIntro2;
    public GameObject panelIntro3;
    public GameObject panelIntroSkip;
    public GameObject panelMenuPrincipal;
    public string mermeladaJamURL;

    public AudioSource asMover;
    public AudioSource asPulsar;

    [SerializeField]
    public Slider sliderMusica;
    [SerializeField]
    public Slider sliderFVX;

    public void Start()
    {
        if (PlayerPrefs.HasKey("Musica") || PlayerPrefs.HasKey("FVX"))
        {
            sliderMusica.value = PlayerPrefs.GetFloat("Musica");
            sliderFVX.value = PlayerPrefs.GetFloat("FVX");
        }
    }
    public void EmpezarJuego()
    {
        asPulsar.Play();
        SceneManager.LoadScene("PantallaHorizontal");
    }
    public void CargarCreditos()
    {
        asPulsar.Play();
        panelCreditos.SetActive(true);
    }

    public void CerrarCreditos()
    {
        asPulsar.Play();
        panelCreditos.SetActive(false);
    }
    public void CargarOpciones()
    {
        asPulsar.Play();
        panelOpciones.SetActive(true);
    }

    public void CerrarOpciones()
    {
        asPulsar.Play();
        panelOpciones.SetActive(false);
    }

    public void SalirEscritorio()
    {
        Application.Quit();
    }

    public void AbrirURL()
    {
        asPulsar.Play();
        Application.OpenURL(mermeladaJamURL);
    }

    public void PasarAIntro2()
    {
        asPulsar.Play();
        panelIntro2.SetActive(true);
        animatorIntro.SetTrigger("Intro2");
    }

    public void PasarAIntro3()
    {
        asPulsar.Play();
        panelIntro3.SetActive(true);
        animatorIntro.SetTrigger("Intro3");
    }

    public void PasarAMenuprincipal()
    {
        asPulsar.Play();
        animatorIntro.SetTrigger("MenuPrincipal");
        panelMenuPrincipal.SetActive(true);
        
    }

    public void PasarAIntroSkip()
    {
        asPulsar.Play();
        panelIntroSkip.SetActive(true);
        animatorIntro.SetTrigger("IntroSkip");
    }

}
