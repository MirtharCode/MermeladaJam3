using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionesHUDJuego : MonoBehaviour
{
    public Animator animatorComments;
    public Animator animatorOptions;
    public Animator animatorMenu;
    public Animator animatorCorazones;
    public Animator animatorBotonComentarios;

    public void Start()
    {
        StartCoroutine("CargarTextoLikes");
    }

    public IEnumerator CargarTextoLikes()
    {
        animatorCorazones.SetTrigger("CargarTextoCorazones");
        yield return new WaitForSeconds(3);
        StartCoroutine("CargarBotonComentarios");
    }

    public IEnumerator CargarBotonComentarios()
    {
        animatorBotonComentarios.SetTrigger("Pulsado");
        yield return new WaitForSeconds(3);
    }

    public void CargarComentarios()
    {
        StartCoroutine("SubirMenu");
        
    }

    public IEnumerator SubirMenu()
    {
        animatorMenu.SetTrigger("Subir");
        yield return new WaitForSeconds(3);
        StartCoroutine("ActivarAnimaciones");
    }

    public IEnumerator ActivarAnimaciones()
    {
        animatorComments.SetTrigger("Comments");
        yield return new WaitForSeconds(3);
        animatorOptions.SetTrigger("Options");
    }

}
