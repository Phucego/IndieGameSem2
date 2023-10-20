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
    public Text dfText;
    
    [Header("Image Display")]
    public Image image;
    public Image atkImage;
    public Image defenseImage;
    public Image hpImage;
    public Image costImage;
    public Image cardBGImage;
    public Image cardBorderImage;
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
        dfText.text = card.defense.ToString();
        //image
        image.sprite = card.image;
        atkImage.sprite = card.atkImage;
        defenseImage.sprite = card.defenseImage;
        hpImage.sprite = card.hpImage;
        costImage.sprite = card.costImage;
        cardBGImage.sprite = card.cardBGImage;
        cardBorderImage.sprite = card.cardBorderImage;

    }

    
}
