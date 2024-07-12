using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public Animator animatorCorazon;
    public Animator animatorEngranaje;
    public void EmpezarJuego()
    {
        SceneManager.LoadScene("PantallaHorizontal");
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
