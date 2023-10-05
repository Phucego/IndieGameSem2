using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CardDisplay : MonoBehaviour
{
    public GenerateCard card;

    [Header("Text Display")]
    public Text nameText;
    public Text desText;

    [Header("Number Display")]
    public Text costText;
    public Text hpText;
    public Text atkText;

    [Header("Image Display")]
    public Image image;

    // Start is called before the first frame update
    void Start()
    {
        //words
        nameText.text = card.cardName;
        desText.text = card.description;

        //numbers
        costText.text = card.cost.ToString();
        hpText.text = card.hp.ToString();
        atkText.text = card.attack.ToString();

        //image
        image.sprite = card.image;

    }

    
}
