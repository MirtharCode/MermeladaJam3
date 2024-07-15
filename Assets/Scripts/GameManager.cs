using Palmmedia.ReportGenerator.Core.Reporting.Builders;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int rounds;
    public AnimacionesHUDJuego aM;
    public Color originalBGColor, darkgreen;

    [Header("Likes")]
    public int heartPoints;
    public TextMeshProUGUI likesText, finalLikesCounter, finalDefinitiveLikesCounter;
    public int finalDefinitiveLikesCounterNum;

    [Header("Mazado")]
    public int muscleCounter;
    public int muscleHearts;
    public TextMeshProUGUI finalMuscleCounter, finalMuscleMultiplier;

    [Header("Malote")]
    public int badassCounter;
    public int badassHearts;
    public TextMeshProUGUI finalBadassCounter, finalBadassMultiplier;


    [Header("Coquette")]
    public int coquetteCounter;
    public int coquetteHearts;
    public TextMeshProUGUI finalCoquetteCounter, finalCoquetteMultiplier;

    [Header("Naturalista")]
    public int naturalCounter;
    public int naturalHearts;
    public TextMeshProUGUI finalNaturalCounter, finalNaturalMultiplier;

    [Header("Final Combo")]
    public TextMeshProUGUI finalComboMultiplier;

    [Header("Others")]
    public GameObject complements, backgrounds;
    public List<GameObject> complementsList, backgroundList;
    public List<string> buttonNamesList, commentsList;
    public List<Sprite> commentsSpritesList;
    public Button leftButton, centerButton, rightButton;
    public GameObject firstComment, secondComment, thirdComment;
    public GameObject fCImage, sCImage, tCImage;


    [Header("Final")]
    public GameObject finalesPanel;
    public Sprite[] finales;

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
        originalBGColor = firstComment.GetComponent<Image>().color;
        ColorUtility.TryParseHtmlString("#26B735", out darkgreen);
        aM = GameObject.FindGameObjectWithTag("AM").GetComponent<AnimacionesHUDJuego>();
        FillTheComments();
    }

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
            {
                for (int j = 0; j < backgroundList.Count; j++)

                {
                    backgroundList[j].gameObject.SetActive(false);
                }
                backgroundList[i].gameObject.SetActive(true);
            }
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
        GivingButtonTags(leftButton);
        MakingComments(firstComment, fCImage);


        rdm = Random.Range(0, buttonNamesList.Count);
        centerButton.name = buttonNamesList[rdm];
        centerButton.GetComponent<ButtonBehaviour>().LaNombrasion(centerButton.name);
        buttonNamesList.Remove(buttonNamesList[rdm]);
        GivingButtonTags(centerButton);
        MakingComments(secondComment, sCImage);

        rdm = Random.Range(0, buttonNamesList.Count);
        rightButton.name = buttonNamesList[rdm];
        rightButton.GetComponent<ButtonBehaviour>().LaNombrasion(rightButton.name);
        buttonNamesList.Remove(buttonNamesList[rdm]);
        GivingButtonTags(rightButton);
        MakingComments(thirdComment, tCImage);

        rounds++;
    }

    public void GivingButtonTags(Button button)
    {
        if ((button.name == "Boots") || button.name == "BraceletPinchudo" || button.name == "Cigar" || button.name == "Necklace" || button.name == "Sunglasses" || button.name == "Malote")
            button.gameObject.tag = "Malote";

        else if ((button.name == "Abs") || button.name == "Arms" || button.name == "Headband" || button.name == "MuscleEars" || button.name == "Mazado")
            button.gameObject.tag = "GymBro";

        else if ((button.name == "Bandana" || button.name == "Cat") || button.name == "Dog" || button.name == "Fannybag" || button.name == "Natural")
            button.gameObject.tag = "HappyFlower";

        else if ((button.name == "Earrings" || button.name == "Eyes" || button.name == "Flowers") || button.name == "Lips" || button.name == "Coquette")
            button.gameObject.tag = "Gorgeus";
    }

    public string MakingComments(GameObject comment, GameObject sprite)
    {
        int rdm1 = Random.Range(0, commentsList.Count);
        int rdm2 = Random.Range(0, commentsSpritesList.Count);

        if (commentsList[rdm1].Contains("arreglen") || commentsList[rdm1].Contains("seduzcan") || commentsList[rdm1].Contains("mono") || commentsList[rdm1].Contains("belleza") || commentsList[rdm1].Contains("fashion"))
        {
            comment.gameObject.tag = "Gorgeus";
            comment.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = commentsList[rdm1];
            commentsList.Remove(commentsList[rdm1]);
        }

        else if (commentsList[rdm1].Contains("Muscul") || commentsList[rdm1].Contains("botes") || commentsList[rdm1].Contains("fuerte") || commentsList[rdm1].Contains("Rock") || commentsList[rdm1].Contains("Gym"))
        {
            comment.gameObject.tag = "GymBro";
            comment.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = commentsList[rdm1];
            commentsList.Remove(commentsList[rdm1]);
        }

        else if (commentsList[rdm1].Contains("moto") || commentsList[rdm1].Contains("Vallecas") || commentsList[rdm1].Contains("héroe") || commentsList[rdm1].Contains("malotes") || commentsList[rdm1].Contains("intimide") || commentsList[rdm1].Contains("cosplay"))
        {
            comment.gameObject.tag = "Malote";
            comment.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = commentsList[rdm1];
            commentsList.Remove(commentsList[rdm1]);
        }

        else if (commentsList[rdm1].Contains("mascota") || commentsList[rdm1].Contains("reciclar") || commentsList[rdm1].Contains("micho") || commentsList[rdm1].Contains("Vegano") || commentsList[rdm1].Contains("naturaleza"))
        {
            comment.gameObject.tag = "HappyFlower";
            comment.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = commentsList[rdm1];
            commentsList.Remove(commentsList[rdm1]);
        }


        sprite.GetComponent<Image>().sprite = commentsSpritesList[rdm2];

        return comment.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text;
    }

    public void GivingHearts(Button button, GameObject comment1, GameObject comment2, GameObject comment3)
    {
        if (button.gameObject.tag == "Malote")
        {
            if (button.gameObject.tag == comment1.tag)
            {
                badassHearts += 10;
                firstComment.GetComponent<Image>().color = darkgreen;
            }
            else if (button.gameObject.tag == comment2.tag)
            {
                badassHearts += 10;
                secondComment.GetComponent<Image>().color = darkgreen;
            }

            else if (button.gameObject.tag == comment3.tag)
            {
                badassHearts += 10;
                thirdComment.GetComponent<Image>().color = darkgreen;
            }

            else
                badassHearts += 5;
        }

        else if (button.gameObject.tag == "GymBro")
        {
            if (button.gameObject.tag == comment1.tag)
            {
                muscleHearts += 10;
                firstComment.GetComponent<Image>().color = darkgreen;
            }
            else if (button.gameObject.tag == comment2.tag)
            {
                muscleHearts += 10;
                secondComment.GetComponent<Image>().color = darkgreen;
            }

            else if (button.gameObject.tag == comment3.tag)
            {
                muscleHearts += 10;
                thirdComment.GetComponent<Image>().color = darkgreen;
            }

            else
                muscleHearts += 5;
        }

        else if (button.gameObject.tag == "HappyFlower")
        {
            if (button.gameObject.tag == comment1.tag)
            {
                naturalHearts += 10;
                firstComment.GetComponent<Image>().color = darkgreen;
            }
            else if (button.gameObject.tag == comment2.tag)
            {
                naturalHearts += 10;
                secondComment.GetComponent<Image>().color = darkgreen;
            }

            else if (button.gameObject.tag == comment3.tag)
            {
                naturalHearts += 10;
                thirdComment.GetComponent<Image>().color = darkgreen;
            }

            else
                naturalHearts += 5;
        }

        else if (button.gameObject.tag == "Gorgeus")
        {
            if (button.gameObject.tag == comment1.tag)
            {
                coquetteHearts += 10;
                firstComment.GetComponent<Image>().color = darkgreen;
            }
            else if (button.gameObject.tag == comment2.tag)
            {
                coquetteHearts += 10;
                secondComment.GetComponent<Image>().color = darkgreen;
            }

            else if (button.gameObject.tag == comment3.tag)
            {
                coquetteHearts += 10;
                thirdComment.GetComponent<Image>().color = darkgreen;
            }

            else
                coquetteHearts += 5;
        }

        heartPoints = badassHearts + muscleHearts + naturalHearts + coquetteHearts;

        likesText.GetComponent<TextMeshProUGUI>().fontSize = 65;
        likesText.GetComponent<TextMeshProUGUI>().alignment = TextAlignmentOptions.CaplineJustified;
        likesText.text = "Has conseguido \n" + heartPoints + " likes! <3";
    }

    public void FillTheComments()
    {
        commentsList.Add("Yo quiero que se arreglen.");
        commentsList.Add("Que seduzca con su mirada.");
        commentsList.Add("Tiene que ser supermono.");
        commentsList.Add("Que compita con mi belleza.");
        commentsList.Add("Que sea fashion victim.");

        commentsList.Add("Musculoso siempre.");
        commentsList.Add("Que sepa abrir botes.");
        commentsList.Add("Que sea más fuerte que el vinagre.");
        commentsList.Add("The Rock pero en guapo");
        commentsList.Add("Mas Gym que Ñam.");

        commentsList.Add("O tiene moto o nada.");
        commentsList.Add("De Vallecas mínimo");
        commentsList.Add("A mi me van los antihéroes..");
        commentsList.Add("Me pueden los malotes.");
        commentsList.Add("Que su presencia intimide.");
        commentsList.Add("Que haga cosplay de Mario Casas.");


        commentsList.Add("Que tenga mascota.");
        commentsList.Add("Tiene que reciclar.");
        commentsList.Add("Tendrá que querer a mi micho.");
        commentsList.Add("Vegano sin duda.");
        commentsList.Add("Que ame la naturaleza.");
    }

    public void ScoreFilling()
    {
        finalLikesCounter.text = "" + heartPoints;

        finalMuscleCounter.text = "" + muscleCounter;
        finalMuscleMultiplier.text = "x" + CategoryMultiplier(muscleCounter);

        finalBadassCounter.text = "" + badassCounter;
        finalBadassMultiplier.text = "x" + CategoryMultiplier(badassCounter);

        finalCoquetteCounter.text = "" + coquetteCounter;
        finalCoquetteMultiplier.text = "x" + CategoryMultiplier(coquetteCounter);

        finalNaturalCounter.text = "" + naturalCounter;
        finalNaturalMultiplier.text = "x" + CategoryMultiplier(naturalCounter);

        finalComboMultiplier.text = "x" + ComboMultiplier(muscleCounter, badassCounter, coquetteCounter, naturalCounter);
        finalDefinitiveLikesCounter.text = "" + TotalLikes();

    }

    public float CategoryMultiplier(int categoryCounter)
    {
        float multiplier;

        if (categoryCounter == 2)
            multiplier = 2.1f;

        else if (categoryCounter == 3)
            multiplier = 2.25f;

        else if (categoryCounter == 4)
            multiplier = 2.5f;

        else
            multiplier = 1f;

        return multiplier;
    }

    public float ComboMultiplier(int categoryCounter1, int categoryCounter2, int categoryCounter3, int categoryCounter4)
    {
        float multiplier;

        if ((categoryCounter1 == 2 && categoryCounter2 == 2) || (categoryCounter1 == 2 && categoryCounter3 == 2) || (categoryCounter1 == 2 && categoryCounter4 == 2) ||
            (categoryCounter2 == 2 && categoryCounter3 == 2) || (categoryCounter2 == 2 && categoryCounter4 == 2) || (categoryCounter3 == 2 && categoryCounter4 == 2))
            multiplier = 1.6f;

        else if ((categoryCounter1 == 3 && categoryCounter2 == 3) || (categoryCounter1 == 3 && categoryCounter3 == 3) || (categoryCounter1 == 3 && categoryCounter4 == 3) ||
            (categoryCounter2 == 3 && categoryCounter3 == 3) || (categoryCounter2 == 3 && categoryCounter4 == 3) || (categoryCounter3 == 3 && categoryCounter4 == 3))
            multiplier = 1.8f;
        else
            multiplier = 1f;

        return multiplier;
    }

    public int TotalLikes()
    {
        Debug.Log("El multiplicador de GymBro es de : x" + CategoryMultiplier(muscleCounter));
        float muscleTotal = muscleHearts * CategoryMultiplier(muscleCounter);
        Debug.Log("El total de likes musculosos es de: " + muscleTotal);

        Debug.Log("El multiplicador de Malote es de : x" + CategoryMultiplier(badassCounter));
        float badassTotal = badassHearts * CategoryMultiplier(badassCounter);
        Debug.Log("El total de likes malotes es de: " + badassTotal);

        Debug.Log("El multiplicador de Coquette es de : x" + CategoryMultiplier(coquetteCounter));
        float coquetteTotal = coquetteHearts * CategoryMultiplier(coquetteCounter);
        Debug.Log("El total de likes coquettes es de: " + coquetteTotal);

        Debug.Log("El multiplicador de Naturalista es de : x" + CategoryMultiplier(naturalCounter));
        float naturalTotal = naturalHearts * CategoryMultiplier(naturalCounter);
        Debug.Log("El total de likes naturalistas es de: " + naturalTotal);

        float combusMaximus = ComboMultiplier(muscleCounter, badassCounter, coquetteCounter, naturalCounter);
        Debug.Log("El multiplicador de Combo es de : x" + combusMaximus);

        finalDefinitiveLikesCounterNum = (int)((muscleTotal + badassTotal + coquetteTotal + naturalTotal) * combusMaximus);
        Debug.Log("El final  definitivo de likes es de" + finalDefinitiveLikesCounterNum);

        return finalDefinitiveLikesCounterNum;
    }

    public void ShowFinal()
    {
        finalesPanel.transform.GetChild(0).gameObject.SetActive(false);
        finalesPanel.transform.GetChild(1).gameObject.SetActive(true);
    }

    public void ShowInsta()
    {
        finalesPanel.transform.GetChild(1).gameObject.SetActive(false);
        finalesPanel.transform.GetChild(2).gameObject.SetActive(true);
        finalesPanel.transform.GetChild(2).GetChild(2).GetComponent<TextMeshProUGUI>().text = finalDefinitiveLikesCounterNum + " likes";

        if (finalDefinitiveLikesCounterNum <= 75)
            finalesPanel.transform.GetChild(2).GetChild(0).gameObject.GetComponent<Image>().sprite = finales[0];
        else if (finalDefinitiveLikesCounterNum <= 100)
            finalesPanel.transform.GetChild(2).GetChild(0).gameObject.GetComponent<Image>().sprite = finales[1];
        else if (finalDefinitiveLikesCounterNum <= 125)
            finalesPanel.transform.GetChild(2).GetChild(0).gameObject.GetComponent<Image>().sprite = finales[2];
        else if (finalDefinitiveLikesCounterNum <= 150)
            finalesPanel.transform.GetChild(2).GetChild(0).gameObject.GetComponent<Image>().sprite = finales[3];
        else if (finalDefinitiveLikesCounterNum > 150)
            finalesPanel.transform.GetChild(2).GetChild(0).gameObject.GetComponent<Image>().sprite = finales[4];

        StartCoroutine("ShowRetryButton");
    }

    public IEnumerator ShowRetryButton()
    {
        yield return new WaitForSeconds(1f);
        finalesPanel.transform.GetChild(2).GetChild(3).gameObject.SetActive(true);
    }

    public void MenuPrincipal()
    {
        //asPulsar.Play();
        SceneManager.LoadScene(0);
    }
}
