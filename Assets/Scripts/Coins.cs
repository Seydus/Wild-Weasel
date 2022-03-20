using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coins : MonoBehaviour
{
    public Text coinText;

    int playerMoney;

    void Start()
    {
        playerMoney = GameManager.Instance.currency;
    }

    void Update()
    {
        coinText.text = "" + GameManager.Instance.currency;
    }
}
