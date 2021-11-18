using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyEngine : MonoBehaviour
{
    public Text moneyText;
    public int currentMoney;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("CurrentMoney"))
        {
            currentMoney = PlayerPrefs.GetInt("CurrentMoney");
        } else
        {
            currentMoney = 0;
            PlayerPrefs.SetInt("CurrentMoney", 0);
        }

        moneyText.text = "Money : " + currentMoney;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddMoney(int moneyToAdd)
    {
        currentMoney += moneyToAdd;
        PlayerPrefs.SetInt("CurrentMoney", currentMoney);
        moneyText.text = moneyText.text = "Money : " + currentMoney;
    }

    public void SubstractMoney(int moneyToSubstract)
    {
        currentMoney = Mathf.Max(0, moneyToSubstract - moneyToSubstract);
        PlayerPrefs.SetInt("CurrentMoney", currentMoney);
        moneyText.text = "Money : " + currentMoney;
    }
}
