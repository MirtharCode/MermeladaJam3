using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuOpcionesJuego : MonoBehaviour
{

    public GameObject panelOpciones;
    public AudioSource asMover;
    public AudioSource asPulsar;

    public void AbrirOpcionesJuego()
    {
        asPulsar.Play();
        panelOpciones.SetActive(true);
        
    }
    public void Reanudar()
    {
        asPulsar.Play();
        panelOpciones.SetActive(false);
    }

    public void Reiniciar()
    {
        asPulsar.Play();
        SceneManager.LoadScene(1);
    }

    public void MenuPrincipal()
    {
        asPulsar.Play();
        SceneManager.LoadScene(0);
    }

}
