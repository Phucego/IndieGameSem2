using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject key, coin;
  
    public GameManager instance;
    public bool hasPickedKey;
    public int coinPicked;
    Cloud _cloudScript;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        hasPickedKey = false;
        _cloudScript = GetComponent<Cloud>();
    }

    // Update is called once per frame
    void Update()
    {
        RespawnCloud();
    }

    public void ChangeValueCoin(int CoinValue)
    {
        //Increase the coin counter by 1
        coinPicked += CoinValue;
    }
    
    private void RespawnCloud()
    {
        if(_cloudScript.isCloudDestroyed)
        {
            StartCoroutine(_cloudScript.RespawnCloud());
            Debug.Log("respawning cloud");
        }    
    }
}
