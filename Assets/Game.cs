using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour {

	//CLICKER
	public Text scoreText;
	public float currentScore;
	public float hitPower;
	public float scoreIncreasedPerSecond;
	public float x;

	//SHOP
	public int shop1prize;
	public Text shop1text;

	public int shop2prize;
	public Text shop2text;

	//AMOUNT
	public Text amount1Text;
	public int amount1;
	public float amount1Profit;

	public Text amount2Text;
	public int amount2;
	public float amount2Profit;

    //UPGRADE
    public int upgradePrize;
	public Text upgradeText;

    //NEW
	public int allUpgradePrize;
	public Text allUpgradeText;

	//LEVEL SYSTEM
	public int level;
	public int exp;
	public int expToNextLevel;
	public Text levelText;

	//HIGHEST SCORE
	public int bestScore;
	public Text bestScoreText;

	// Use this for initialization
	void Start () {

		//CLICKER
		currentScore =0;
		hitPower =1;
		scoreIncreasedPerSecond =1;
		x =0f;
		
		//WE MUST SET ALL DEAFAULT VARIABLES BEFORE LOAD
		shop1prize = 25;
		shop2prize = 125;
		amount1 =0;
		amount1Profit =1;
		amount2 =0;
		amount2Profit =5;

		//RESET LINE
		//PlayerPrefs.DeleteAll();

		//LOAD
		currentScore = PlayerPrefs.GetInt("currentScore", 0);
		hitPower = PlayerPrefs.GetInt("hitPower", 1);
		x = PlayerPrefs.GetInt("x", 0);

		shop1prize = PlayerPrefs.GetInt("shop1prize", 25);
		shop2prize = PlayerPrefs.GetInt("shop2prize", 125);
		amount1 = PlayerPrefs.GetInt("amount1", 0);
		amount1Profit = PlayerPrefs.GetInt("amount1Profit", 0);
		amount2 = PlayerPrefs.GetInt("amount2", 0);
		amount2Profit = PlayerPrefs.GetInt("amount2Profit", 0);
		upgradePrize = PlayerPrefs.GetInt("upgradePrize", 50);

		//LEVEL SYSTEM
        level = PlayerPrefs.GetInt("level", 1);
        exp = PlayerPrefs.GetInt("exp", 0);
        expToNextLevel = PlayerPrefs.GetInt("expToNextLevel", 5);

		//NEW
		allUpgradePrize = 500;

		//HIGHEST SCORE
		bestScore = PlayerPrefs.GetInt("bestScore", 0);

	}
	
	// Update is called once per frame
	void Update () {

		//CLICKER
		scoreText.text = (int)currentScore+" $";
		scoreIncreasedPerSecond = x * Time.deltaTime;
		currentScore = currentScore + scoreIncreasedPerSecond;
		
		//SHOP
		shop1text.text = "Tier 1: "+shop1prize+" $";
		shop2text.text = "Tier 2: "+shop2prize+" $";

		//AMOUNT
		amount1Text.text = "Tier 1: "+amount1+" arts $: "+amount1Profit+"/s";
		amount2Text.text = "Tier 2: "+amount2+" arts $: "+amount2Profit+"/s";

		//UPGRADE
		upgradeText.text = "Cost: "+upgradePrize+" $";

		//SAVE
		PlayerPrefs.SetInt("currentScore", (int)currentScore);
		PlayerPrefs.SetInt("hitPower", (int)hitPower);
		PlayerPrefs.SetInt("x", (int)x);

		PlayerPrefs.SetInt("shop1prize", (int)shop1prize);
		PlayerPrefs.SetInt("shop2prize", (int)shop2prize);
		PlayerPrefs.SetInt("amount1", (int)amount1);
		PlayerPrefs.SetInt("amount1Profit", (int)amount1Profit);
		PlayerPrefs.SetInt("amount2", (int)amount2);
		PlayerPrefs.SetInt("amount2Profit", (int)amount2Profit);
		PlayerPrefs.SetInt("upgradePrize", (int)upgradePrize);

		// SAVE LEVEL SYSTEM
        PlayerPrefs.SetInt("level", level);
        PlayerPrefs.SetInt("exp", exp);
        PlayerPrefs.SetInt("expToNextLevel", expToNextLevel);

		//NEW
		allUpgradeText.text = "Cost: " + allUpgradePrize +" $";

		//SAVE HIGHEST SCORE
		PlayerPrefs.SetInt("bestScore", bestScore);

		//LEVEL
		if(exp >= expToNextLevel)
		{
			level++;
			exp =0;
			expToNextLevel *=2;
		}

		levelText.text = level + "level";

		//HIGHEST SCORE
		if(currentScore > bestScore)
		{
			bestScore = (int)currentScore;
		}

		bestScoreText.text = bestScore + " Best Score";

	}

	//HIT
	public void Hit()
	{
		currentScore += hitPower;

		//EXP
		exp++;
	}

    //SHOP
	public void Shop1()
	{
		if(currentScore>=shop1prize)
		{
			currentScore -= shop1prize;
			amount1 +=1;
			amount1Profit +=1;
			x +=1;
			shop1prize +=25;
		}
	}

	public void Shop2()
	{
		if(currentScore>=shop2prize)
		{
			currentScore -= shop2prize;
			amount2 +=1;
			amount2Profit +=5;
			x +=5;
			shop2prize +=125;
		}
	}
	
	//UPGRADE
	public void Upgrade()
	{
		if(currentScore>=upgradePrize)
		{
			currentScore -=upgradePrize;
			hitPower *= 2;
			upgradePrize *= 3;
		}
	}
	//NEW
	public void AllProfitsUpgrade()
	{
		if(currentScore>=allUpgradePrize)
		{
			currentScore -=allUpgradePrize;
			x*=2;
			allUpgradePrize*=3;
			amount1Profit*=2;
			amount2Profit*=2;
		}
	}

}
