using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject key, coin;

    public GameManager instance;
    public bool hasPickedKey;
    public int coinPicked;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        hasPickedKey = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void ChangeValueCoin(int CoinValue)
    {
        //Increase the coin counter by 1
        coinPicked += CoinValue;
    }
    
}
