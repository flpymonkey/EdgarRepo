using UnityEngine;
using UnityEngine.UI;
using System;
using Ink.Runtime;
using System.Collections.Generic;
using System.Linq;


public class TagParser : MonoBehaviour
{
	// Tag Parsing
	void CheckForTag(List<string> tags)
	{
		if (tags.Count > 0)
		{
			foreach (string tag in tags)
			{
				ProcessTag(tag);
			}
		}
	}

	void ProcessTag(string tag)
	{
		List<string> tagList = tag.Split(',').ToList();

		string action = tagList[0];

		switch (action)
		{
			case "callFunction":
				string functionName = tagList[1];
				List<string> arguments = tagList.Skip(2).Take(tagList.Count).ToList();
				switch (functionName)
				{
					case "addMoney":
						moneyEngine.AddMoney(Int32.Parse(arguments[0]));
						break;
					case "substractMoney":
						moneyEngine.SubstractMoney(Int32.Parse(arguments[0]));
						break;
				}

				break;
		}
	}


	// Money Engine
	[SerializeField]
	private MoneyEngine moneyEngine = null;
}