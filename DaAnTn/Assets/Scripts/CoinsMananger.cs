using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsMananger : MonoBehaviour
{
    public int Coins;
    public int famor;
    public Text textcoins;
    public Text textfamor;
    public GameObject GameWin;
    public int levelmap;

    void Update()
    {
        textfamor.text = ("" + famor);
        textcoins.text = (" " + Coins);
        if (levelmap == 1) {
            if (Coins >= 1 && famor >= 1)
            {
                AudioManager.instance.PlaySound("mantiep");
                GameWin.SetActive(true);
            }
        }
        else if (levelmap == 2) {
            if (Coins >= 2 && famor >= 1)
            {
                AudioManager.instance.PlaySound("mantiep");
                GameWin.SetActive(true);
                Time.timeScale = 1;
            }
        }
        else if (levelmap == 3)
        {
            if (Coins >= 2 && famor >= 1)
            {
                AudioManager.instance.PlaySound("mantiep");
                GameWin.SetActive(true);
            }
        }
        else if (levelmap == 4)
        {
            if (Coins >= 2 && famor >= 1)
            {
                AudioManager.instance.PlaySound("mantiep");
                GameWin.SetActive(true);
            }
        }
    }
}
