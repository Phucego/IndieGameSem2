using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int CoinValue = 1;
    GameManager gmScript;
    // Start is called before the first frame update
    void Start()
    {
        gmScript = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            gmScript.instance.ChangeValueCoin(CoinValue);

            Destroy(this.gameObject);
        }
    }
}
