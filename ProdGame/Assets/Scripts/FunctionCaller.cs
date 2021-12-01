using UnityEngine;
using UnityEngine.UI;
using System;
using Ink.Runtime;
using System.Collections.Generic;
using System.Linq;


public class FunctionCaller : MonoBehaviour
{
    public void setStory(Story s)
    {
        this.story = s;
    }

    public void BindFunctions()
    {
        story.BindExternalFunction("addMoney", (int money) => {
            moneyEngine.AddMoney(money);
        }, false);

        story.BindExternalFunction("substractMoney", (int money) => {
            moneyEngine.SubstractMoney(money);
        }, false);

        story.BindExternalFunction("getCurrentMoney", () => {
            return moneyEngine.GetCurrentMoney();
        }, true);
    }



    private Story story;
    [SerializeField]
    MoneyEngine moneyEngine = null;
}