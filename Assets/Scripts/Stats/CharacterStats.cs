﻿using UnityEngine;
using UnityEngine.UI;

public class CharacterStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int maxMana = 100;
    public int nextLevelExp = 100;
    public int currentHealth { get; private set; }
    public int currentMana { get; private set; }
    public int currentExp { get; private set; }

    public Stat minDamage;
    public Stat maxDamage;
    public Stat magicDamage;
    public Stat armour;
    public Stat magicResist;

    public Stat strenght;
    public Stat agility;
    public Stat condition;
    public Stat intelligence;
    public Stat wisdom;
    public Stat charisma;

    public int level;
    public int avaiblePoints;
    public int skillPoints;

    public event System.Action<int, int> OnHealthChanged;
    public event System.Action<int, int> OnManaChanged;
    public event System.Action<int, int> OnExpChanged;

    private void Awake()
    {
        currentHealth = maxHealth;
        currentMana = maxMana;
        UpdateUI();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10);
        }
    }
    public void TakeDamage (int damage)
    {
        //damage -= armour.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);


        currentHealth -= damage;
        currentMana -= damage;
        currentExp += damage;
        Debug.Log(transform.name + " takes " + damage + " damage.");

        if(OnHealthChanged!=null)
        {
            OnHealthChanged.Invoke(maxHealth,currentHealth);
        }

        if(OnManaChanged != null)
        {
            OnManaChanged.Invoke(maxMana, currentMana);
        }

        if(OnExpChanged != null)
        {
            OnExpChanged.Invoke(nextLevelExp, currentExp);
        }

        if(currentHealth<=0)
        {
            Die();
        }
        UpdateUI();
    }

    public virtual void Die()
    {
        //Die in some way;
        Debug.Log(transform.name + " died.");
    }

    //UI-stats
    public Text lvlText;
    public Text pointsText;
    public Text strText;
    public Text dexText;
    public Text conText;
    public Text intText;
    public Text wisText;
    public Text chaText;

    public Text currHP;
    public Text currMP;
    public Text currExp;
    public Text dmgP;
    public Text[] spellDmg;
    public Text pArmor;
    public Text mArmor;

    private int maxpoints = 10;
    protected int[] stats = { 8, 8, 8, 8, 8, 8 };

    public void UpdateUI()
    {
        lvlText.text = level.ToString();
        pointsText.text = avaiblePoints.ToString();

        strText.text = strenght.baseValue.ToString();
        dexText.text = agility.baseValue.ToString();
        conText.text = condition.baseValue.ToString();
        intText.text = intelligence.baseValue.ToString();
        wisText.text = wisdom.baseValue.ToString();
        chaText.text = charisma.baseValue.ToString();

        currHP.text = currentHealth.ToString() + "/" + maxHealth.ToString();
        currMP.text = currentMana.ToString() + "/" + maxMana.ToString();
        currExp.text = currentExp + "/" + nextLevelExp.ToString();

        dmgP.text = minDamage.baseValue.ToString() + "-" + maxDamage.baseValue.ToString();

        pArmor.text = armour.baseValue.ToString();
        mArmor.text = magicResist.baseValue.ToString();
    }

    public void SetStr(int value)
    {
        if (value > 0 && avaiblePoints > 0)
        {
            strenght.baseValue += value;
            avaiblePoints -= 1;
            UpdateUI();
        }
        else if (value < 0 && strenght.baseValue > stats[0])
        {
            strenght.baseValue += value;
            avaiblePoints += 1;
            UpdateUI();
        }
    }
    public void SetDex(int value)
    {
        if (value > 0 && avaiblePoints > 0)
        {
            agility.baseValue += value;
            avaiblePoints -= 1;
            UpdateUI();
        }
        else if (value < 0 && agility.baseValue > stats[1])
        {
            agility.baseValue += value;
            avaiblePoints += 1;
            UpdateUI();
        }
    }
    public void SetCon(int value)
    {
        if (value > 0 && avaiblePoints > 0)
        {
            condition.baseValue += value;
            avaiblePoints -= 1;
            UpdateUI();
        }
        else if (value < 0 && condition.baseValue > stats[2])
        {
            condition.baseValue += value;
            avaiblePoints += 1;
            UpdateUI();
        }
    }
    public void SetInt(int value)
    {
        if (value > 0 && avaiblePoints > 0)
        {
            intelligence.baseValue += value;
            avaiblePoints -= 1;
            UpdateUI();
        }
        else if (value < 0 && intelligence.baseValue > stats[3])
        {
            intelligence.baseValue += value;
            avaiblePoints += 1;
            UpdateUI();
        }
    }
    public void SetWis(int value)
    {
        if (value > 0 && avaiblePoints > 0)
        {
            wisdom.baseValue += value;
            avaiblePoints -= 1;
            UpdateUI();
        }
        else if (value < 0 && wisdom.baseValue > stats[4])
        {
            wisdom.baseValue += value;
            avaiblePoints += 1;
            UpdateUI();
        }
    }
    public void SetCha(int value)
    {
        if (value > 0 && avaiblePoints > 0)
        {
            charisma.baseValue += value;
            avaiblePoints -= 1;
            UpdateUI();
        }
        else if (value < 0 && charisma.baseValue > stats[5])
        {
            charisma.baseValue += value;
            avaiblePoints += 1;
            UpdateUI();
        }
    }
    
    public void SaveStats()
    {
        stats[0] = strenght.baseValue;
        stats[1] = agility.baseValue;
        stats[2] = condition.baseValue;
        stats[3] = intelligence.baseValue;
        stats[4] = wisdom.baseValue;
        stats[5] = charisma.baseValue;
        maxpoints = avaiblePoints;
        UpdateUI();
    }
    public void ResetStats()
    {
        strenght.baseValue = stats[0];
        agility.baseValue = stats[1];
        condition.baseValue = stats[2];
        intelligence.baseValue = stats[3];
        wisdom.baseValue = stats[4];
        charisma.baseValue = stats[5];
        avaiblePoints = maxpoints;
        UpdateUI();
    }
}
