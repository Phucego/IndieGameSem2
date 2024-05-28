using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthManager : MonoBehaviour
{
    public static int health = 3;

    public Image[] hearts;


    public Sprite fullHeart;
    public Sprite emptyHeart;

    Rigidbody2D rb2d;

    private float knockbackPow = 3f;

    // Update is called once per frame

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //TODO: Use foreach loop to check the hearts, starting with empty hearts
        foreach(Image image in hearts)
        {
            image.sprite = emptyHeart;
        }
        //TODO: Fill the hearts based on the player's current health
        for (int i = 0; i < health; i++)
        {
            hearts[i].sprite = fullHeart;
        }

        if(health <= 0)
        {
            

        }
    }
 

    public void DealDamage(int amount, Vector2 sourcePos)
    {
        health -= amount;
        
        Vector2 knockbackDir = (rb2d.position - sourcePos).normalized;
        rb2d.AddForce(knockbackDir * knockbackPow, ForceMode2D.Impulse);
    }
   
}
