using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CompleteProject;
public class CoinController : MonoBehaviour
{


    public Text coinText;
    public static int currentCoin;
    int startCoin = 0;
    // Use this for initialization
    void Start()
    {
        currentCoin = startCoin;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetInt("Coin", currentCoin);
        PlayerPrefs.Save();
        coinText.text = currentCoin.ToString();
    }
}

