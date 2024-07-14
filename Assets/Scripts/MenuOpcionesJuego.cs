using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuOpcionesJuego : MonoBehaviour
{

    public GameObject panelOpciones;

    public void AbrirOpcionesJuego()
    {
        panelOpciones.SetActive(true);
        
    }
    public void Reanudar()
    {
        panelOpciones.SetActive(false);
    }

    public void Reiniciar()
    {
        SceneManager.LoadScene(1);
    }

    public void MenuPrincipal()
    {
        SceneManager.LoadScene(0);
    }

}
