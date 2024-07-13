using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int rounds, badassCounter, coquetteCounter, muscleCounter, naturalCounter;

    public GameObject complements, backgrounds;
    public List<GameObject> complementsList, backgroundList;
    public List<string> buttonNamesList;
    public Button leftButton, centerButton, rightButton;
    public TextMeshProUGUI firstComment, secondComment, thirdComment;
    public AnimacionesHUDJuego aM;

    void Awake()
    {
        for (int i = 0; i < complements.transform.childCount; i++)
        {
            complementsList.Add(complements.transform.GetChild(i).gameObject);
            buttonNamesList.Add(complements.transform.GetChild(i).gameObject.name);
        }

        for (int i = 1; i < backgrounds.transform.childCount; i++)
        {
            backgroundList.Add(backgrounds.transform.GetChild(i).gameObject);
            buttonNamesList.Add(backgrounds.transform.GetChild(i).gameObject.name);
        }
    }

    private void Start()
    {
        aM = GameObject.FindGameObjectWithTag("AM").GetComponent<AnimacionesHUDJuego>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StickTheSticker(Button button)
    {
        for (int i = 0; i < complementsList.Count; i++)
        {
            if (complementsList[i].name == button.name)
                complementsList[i].gameObject.SetActive(true);
        }

        for (int i = 0; i < backgroundList.Count; i++)
        {
            if (backgroundList[i].name == button.name)
                backgroundList[i].gameObject.SetActive(true);
        }

        if ((button.name == "Boots") || button.name == "BraceletPinchudo" || button.name == "Cigar" || button.name == "Necklace" || button.name == "Sunglasses" || button.name == "Malote")
            badassCounter++;

        else if ((button.name == "Abs") || button.name == "Arms" || button.name == "Headband" || button.name == "MuscleEars" || button.name == "Mazado")
            muscleCounter++;

        else if ((button.name == "Bandana" || button.name == "Cat") || button.name == "Dog" || button.name == "FannyBag" || button.name == "Natural")
            naturalCounter++;

        else if ((button.name == "Earrings" || button.name == "Eyes" || button.name == "Flowers") || button.name == "Lips" || button.name == "Coquette")
            coquetteCounter++;

        aM.StartCoroutine(nameof(aM.ReversaActivarAnimaciones));
    }

    public void TopicsRoulette()
    {
        int rdm = Random.Range(0, buttonNamesList.Count);
        leftButton.name = buttonNamesList[rdm];
        leftButton.GetComponent<ButtonBehaviour>().LaNombrasion(leftButton.name);
        buttonNamesList.Remove(buttonNamesList[rdm]);
        ChangingTheCommments(leftButton, firstComment);


        rdm = Random.Range(0, buttonNamesList.Count);
        centerButton.name = buttonNamesList[rdm];
        centerButton.GetComponent<ButtonBehaviour>().LaNombrasion(centerButton.name);
        buttonNamesList.Remove(buttonNamesList[rdm]);
        ChangingTheCommments(centerButton, secondComment);

        rdm = Random.Range(0, buttonNamesList.Count);
        rightButton.name = buttonNamesList[rdm];
        rightButton.GetComponent<ButtonBehaviour>().LaNombrasion(rightButton.name);
        buttonNamesList.Remove(buttonNamesList[rdm]);
        ChangingTheCommments(rightButton, thirdComment);

        rounds++;
    }

    public string ChangingTheCommments(Button button, TextMeshProUGUI comment)
    {
        if ((button.name == "Boots") || button.name == "BraceletPinchudo" || button.name == "Cigar" || button.name == "Necklace" || button.name == "Malote")
            comment.text = "Necesito un malote";

        else if ((button.name == "Abs") || button.name == "Arms" || button.name == "Headband" || button.name == "MuscleEars" || button.name == "Mazado")
            comment.text = "Necesito un mazas";

        else if ((button.name == "Bandana" || button.name == "Cat") || button.name == "Dog" || button.name == "Fannybag" || button.name == "Natural")
            comment.text = "Necesito un happyflower";

        else if ((button.name == "Earrings" || button.name == "Eyes" || button.name == "Flowers") || button.name == "Lips" || button.name == "Sunglasses" || button.name == "Coquette")
            comment.text = "Necesito un pibonazo";

        return comment.text;
    }

}
