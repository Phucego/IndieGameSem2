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

    [Header("Words")]
    public string cardName;
    public string description;

    [Header("Image")]
    public Sprite image;

}
