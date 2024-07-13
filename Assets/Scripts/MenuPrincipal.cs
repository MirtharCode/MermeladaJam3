using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public void EmpezarJuego()
    {
        SceneManager.LoadScene("PantallaHorizontal");
    }
    public void CargarCreditos()
    {
        //
        panelCreditos.SetActive(true);
    }

    public void CerrarCreditos()
    {
        //
        panelCreditos.SetActive(false);
    }
    public void CargarOpciones()
    {
        //
        panelOpciones.SetActive(true);
    }

    public void CerrarOpciones()
    {
        //
        panelOpciones.SetActive(false);
    }

    public void SalirEscritorio()
    {
        Application.Quit();
    }

    public void AbrirURL()
    {
        Application.OpenURL(mermeladaJamURL);
    }

    public void PasarAIntro2()
    {
        //panelIntro1.SetActive(false);
        panelIntro2.SetActive(true);
        animatorIntro.SetTrigger("Intro2");
    }

    public void PasarAIntro3()
    {
        panelIntro3.SetActive(true);
        animatorIntro.SetTrigger("Intro3");
    }

    public void PasarAMenuprincipal()
    {
        animatorIntro.SetTrigger("MenuPrincipal");
        panelMenuPrincipal.SetActive(true);
        
    }

    public void PasarAIntroSkip()
    {
        panelIntroSkip.SetActive(true);
        animatorIntro.SetTrigger("IntroSkip");
    }

    //public void MoverCorazon()
    //{
    //    animatorCorazon.SetTrigger("MoverCorazon");

    //}

    //public void MoverEngranaje()
    //{
    //    animatorCorazon.SetTrigger("MoverEngranaje");

    //}

}
