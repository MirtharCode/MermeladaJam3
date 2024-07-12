using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public Animator animatorCorazon;
    public Animator animatorEngranaje;
    public GameObject panelOpciones;
    public GameObject panelCreditos;
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

    //public void MoverCorazon()
    //{
    //    animatorCorazon.SetTrigger("MoverCorazon");

    //}

    //public void MoverEngranaje()
    //{
    //    animatorCorazon.SetTrigger("MoverEngranaje");

    //}

}
