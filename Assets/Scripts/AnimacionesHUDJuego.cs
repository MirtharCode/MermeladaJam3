using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AnimacionesHUDJuego : MonoBehaviour
{
    public Animator animatorComments;
    public Animator animatorOptions;
    public Animator animatorMenu;
    public Animator animatorCorazones;
    public Animator animatorBotonComentarios;
    public GameManager gM;
    public bool firstTime;

    public void Start()
    {
        firstTime = true;
        //gM = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        StartCoroutine("CargarTextoLikes");
    }

    public IEnumerator CargarTextoLikes()
    {
        Debug.Log("1");
        animatorCorazones.SetTrigger("CargarTextoCorazones");
        yield return new WaitForSeconds(1);
        StartCoroutine("CargarBotonComentarios");
    }

    public IEnumerator CargarBotonComentarios()
    {
        Debug.Log("2");
        animatorBotonComentarios.SetTrigger("Pulsado");
        yield return new WaitForSeconds(1);
    }

    public void CargarComentarios()
    {
        Debug.Log("3");
        gM.firstComment.GetComponent<Image>().color = gM.originalBGColor;
        gM.secondComment.GetComponent<Image>().color = gM.originalBGColor;
        gM.thirdComment.GetComponent<Image>().color = gM.originalBGColor;

        gM.TopicsRoulette();
        StartCoroutine("SubirMenu");
    }

    public IEnumerator SubirMenu()
    {
        Debug.Log("4");

        animatorMenu.SetBool("SubirB", false);
        animatorMenu.SetTrigger("Subir");
        yield return new WaitForSeconds(1);

        if (gM.rounds < 8)
            StartCoroutine("ActivarAnimaciones");

        else
        {
            Debug.Log("juego terminado");
        }
    }

    public IEnumerator ActivarAnimaciones()
    {
        Debug.Log("5");

        animatorComments.SetBool("CommentsB", false);
        animatorOptions.SetBool("OptionsB", false);
        yield return new WaitForSeconds(0.2f);

        animatorComments.SetTrigger("Comments");
        yield return new WaitForSeconds(1);
        animatorOptions.SetTrigger("Options");
    }

    public IEnumerator ReversaActivarAnimaciones()
    {
        Debug.Log("6");
        animatorComments.SetBool("CommentsB", true);
        animatorOptions.SetBool("OptionsB", true);
        yield return new WaitForSeconds(1);

        StartCoroutine("BajarMenu");
    }

    public IEnumerator BajarMenu()
    {
        Debug.Log("7");
        animatorMenu.SetBool("SubirB", true);
        yield return new WaitForSeconds(1);
    }
}
