using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int rounds, badassCounter, coquetteCounter, muscleCounter, naturalCounter, heartPoints;

    public GameObject complements, backgrounds;
    public List<GameObject> complementsList, backgroundList;
    public List<string> buttonNamesList, commentsList;
    public Button leftButton, centerButton, rightButton;
    public GameObject firstComment, secondComment, thirdComment;
    public TextMeshProUGUI textoLikes;
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
        MakingComments(firstComment);


        rdm = Random.Range(0, buttonNamesList.Count);
        centerButton.name = buttonNamesList[rdm];
        centerButton.GetComponent<ButtonBehaviour>().LaNombrasion(centerButton.name);
        buttonNamesList.Remove(buttonNamesList[rdm]);
        GivingButtonTags(centerButton);
        MakingComments(secondComment);

        rdm = Random.Range(0, buttonNamesList.Count);
        rightButton.name = buttonNamesList[rdm];
        rightButton.GetComponent<ButtonBehaviour>().LaNombrasion(rightButton.name);
        buttonNamesList.Remove(buttonNamesList[rdm]);
        GivingButtonTags(rightButton);
        MakingComments(thirdComment);

        rounds++;
    }

    public void GivingButtonTags(Button button)
    {
        if ((button.name == "Boots") || button.name == "BraceletPinchudo" || button.name == "Cigar" || button.name == "Necklace" || button.name == "Malote")
            button.gameObject.tag = "Malote";

        else if ((button.name == "Abs") || button.name == "Arms" || button.name == "Headband" || button.name == "MuscleEars" || button.name == "Mazado")
            button.gameObject.tag = "GymBro";

        else if ((button.name == "Bandana" || button.name == "Cat") || button.name == "Dog" || button.name == "Fannybag" || button.name == "Natural")
            button.gameObject.tag = "HappyFlower";

        else if ((button.name == "Earrings" || button.name == "Eyes" || button.name == "Flowers") || button.name == "Lips" || button.name == "Sunglasses" || button.name == "Coquette")
            button.gameObject.tag = "Gorgeus";
    }

    public string MakingComments(GameObject comment)
    {
        int rdm = Random.Range(0, commentsList.Count);

        if (commentsList[rdm].Contains("arreglen") || commentsList[rdm].Contains("seduzcan") || commentsList[rdm].Contains("mono") || commentsList[rdm].Contains("belleza") || commentsList[rdm].Contains("fashion"))
        {
            comment.gameObject.tag = "Gorgeus";
            comment.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = commentsList[rdm];
            commentsList.Remove(commentsList[rdm]);
        }

        else if (commentsList[rdm].Contains("Muscul") || commentsList[rdm].Contains("botes") || commentsList[rdm].Contains("fuerte") || commentsList[rdm].Contains("Rock") || commentsList[rdm].Contains("Gym"))
        {
            comment.gameObject.tag = "GymBro";
            comment.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = commentsList[rdm];
            commentsList.Remove(commentsList[rdm]);
        }

        else if (commentsList[rdm].Contains("moto") || commentsList[rdm].Contains("Vallecas") || commentsList[rdm].Contains("héroe") || commentsList[rdm].Contains("malotes") || commentsList[rdm].Contains("intimide") || commentsList[rdm].Contains("cosplay"))
        {
            comment.gameObject.tag = "Malote";
            comment.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = commentsList[rdm];
            commentsList.Remove(commentsList[rdm]);
        }

        else if (commentsList[rdm].Contains("mascota") || commentsList[rdm].Contains("reciclar") || commentsList[rdm].Contains("micho") || commentsList[rdm].Contains("Vegano") || commentsList[rdm].Contains("naturaleza"))
        {
            comment.gameObject.tag = "HappyFlower";
            comment.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = commentsList[rdm];
            commentsList.Remove(commentsList[rdm]);
        }

        return comment.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text;
    }

    public void GivingHearts(Button button, GameObject comment1, GameObject comment2, GameObject comment3)
    {
        if (button.gameObject.tag == comment1.tag || button.gameObject.tag == comment2.tag || button.gameObject.tag == comment3.tag)
            heartPoints += 10;

        else
            heartPoints += 5;

        textoLikes.text = "Has conseguido " + heartPoints + " likes! <3";
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
}
