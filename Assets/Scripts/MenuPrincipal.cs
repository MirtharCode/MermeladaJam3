using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public void EmpezarJuego()
    {
        SceneManager.LoadScene("PantallaHorizontal");
    }
}
