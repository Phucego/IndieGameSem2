using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]

public class GenerateCard : ScriptableObject
{
    //use ToString() to display because this is an integer
    [Header("Numbers")]
    public int hp;
    public int cost;
    public int attack;
    public int defense;

    [Header("Words")]
    public string cardName;
    public string description;

    [Header("Image")]
    public Sprite image;
    public Sprite atkImage;
    public Sprite defenseImage;
    public Sprite hpImage;
    public Sprite costImage;
    public Sprite cardBGImage;
    public Sprite cardBorderImage;

}
