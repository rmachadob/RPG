using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharStats : MonoBehaviour {

    public string charName;
    public int playerLevel = 1 ;
    public int currentEXP;
    public int[] expToNextLevel;
    public int maxLevel = 100;
    public int baseEXP = 1000;

    public int currentHP;
    public int maxHP = 100;
    public int currentMP;
    public int maxMP = 30;
    public int strength;
    public int defense;
    public int weaponPower;
    public int armorPower;
    public string equippedWeapon;
    public string equippedArmor;
    public Sprite charImage;

	// Use this for initialization
	void Start () {

        expToNextLevel = new int[maxLevel];
        //how much exp should happen in each level

        //posição 1 da lista pq começa no Lvl 1
        expToNextLevel[1] = baseEXP;
        //i=2 pra começar na posição 2 do Array(Level 2)
        for (int i =2; i < expToNextLevel.Length; i++) 
        {
            //esse Debug é para mim na Unity
         // Debug.Log(i);
            //Mathf.FloorToInt corta os decimais e faz do numero um int
            expToNextLevel[i] = Mathf.FloorToInt(expToNextLevel[i - 1] * 1.05f);//O proximo level pega o quanto precisava para upar do anterior e multiplica por 1.05
           
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.K))//para testar o xp, quando eu apertar K ganha XP
        {
            AddEXP(500);
        }
	}

    public void AddEXP(int expToAdd)
    {
        currentEXP += expToAdd;

        //check if i leveled up
        if(currentEXP > expToNextLevel[playerLevel])
        {
            currentEXP -= expToNextLevel[playerLevel];//tira o xp pra começar do zero no proximo nivel

            playerLevel++;
                

         }
    }
}

