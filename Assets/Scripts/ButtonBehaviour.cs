using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBehaviour : MonoBehaviour
{
    public GameManager gM;
    public Button yoMismo;
    public TextMeshProUGUI miTexto;

    public AudioSource asMover;
    public AudioSource asPulsar;

    private void Start()
    {
        yoMismo = GetComponent<Button>();
        gM = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        Debug.Log(miTexto);
    }

    public void LaNombrasion(string nombre)
    {
        if (nombre == "Boots")
            miTexto.text = "Botitas";

        else if (nombre == "BraceletPinchudo")
            miTexto.text = "Pulsera Pinchos";

        else if (nombre == "Cigar")
            miTexto.text = "Cigarro";

        else if (nombre == "Necklace")
            miTexto.text = "Collar";

        else if (nombre == "Malote")
            miTexto.text = "Fondo Malote";

        else if (nombre == "Abs")
            miTexto.text = "Abdominales";

        else if (nombre == "Arms")
            miTexto.text = "Brazos";

        else if (nombre == "Headband")
            miTexto.text = "Cinta";

        else if (nombre == "MuscleEars")
            miTexto.text = "Musculorejas";

        else if (nombre == "Mazado")
            miTexto.text = "Fondo GymBro";

        else if (nombre == "Bandana")
            miTexto.text = "Bandana";

        else if (nombre == "Cat")
            miTexto.text = "Gato";

        else if (nombre == "Dog")
            miTexto.text = "Perro";

        else if (nombre == "Fannybag")
            miTexto.text = "Riñonera";

        else if (nombre == "Natural")
            miTexto.text = "Fondo Natural";

        else if (nombre == "Earrings")
            miTexto.text = "Pendientes";

        else if (nombre == "Eyes")
            miTexto.text = "Ojazos";

        else if (nombre == "Flowers")
            miTexto.text = "Flores";

        else if (nombre == "Lips")
            miTexto.text = "Labios";

        else if (nombre == "Coquette")
            miTexto.text = "Fondo Coquette";

        else if (nombre == "Sunglasses")
            miTexto.text = "Gafas de Sol";
    }

    public void Activation()
    {
        gM.StickTheSticker(yoMismo);
        asPulsar.Play();
        gM.GivingHearts(yoMismo, gM.firstComment, gM.secondComment, gM.thirdComment);
    }
}
