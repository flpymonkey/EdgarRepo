using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyEngine : MonoBehaviour
{
    [SerializeField]
    private Text moneyText;
    [SerializeField]
    private int currentMoney;

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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool AddMoney(int moneyToAdd)
    {
        currentMoney = currentMoney + moneyToAdd;
        PlayerPrefs.SetInt("CurrentMoney", currentMoney);
        print("Added money! Now you have: " + PlayerPrefs.GetInt("CurrentMoney"));
        return true;
    }

    public bool SubstractMoney(int moneyToSubstract)
    {
        if (moneyToSubstract > currentMoney)
        {
            print("You do not have enough money!");
            return false;
        }
        currentMoney = Mathf.Max(0, currentMoney - moneyToSubstract);
        PlayerPrefs.SetInt("CurrentMoney", currentMoney);
        print("Substracted Money! Now you have: " + PlayerPrefs.GetInt("CurrentMoney"));
        return true;
    }

    public int GetCurrentMoney()
    {
        return currentMoney;
    }
}
