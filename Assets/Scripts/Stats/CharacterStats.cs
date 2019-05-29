using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    public List<Spell> spellList = new List<Spell>();

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

    public void Warrior(Button button)
    {
        if (skillPoints > 0)
        {
            strenght.baseValue += 3;
            condition.baseValue += 1;
            intelligence.baseValue -= 1;
            agility.baseValue -= 1;
            skillPoints -= 1;
            button.interactable = false;
            UpdateUI();
        }
        else
        {
            button.interactable = true;
        }
    }
    public void Archer(Button button)
    {
        if (skillPoints > 0)
        {
            agility.baseValue += 3;
            strenght.baseValue += 1;
            intelligence.baseValue -= 1;
            condition.baseValue -= 1;
            skillPoints -= 1;
            button.interactable = false;
            UpdateUI();
        }
        else
        {
            button.interactable = true;
        }
    }
    public void Mage(Button button)
    {
        if (skillPoints > 0)
        {
            intelligence.baseValue += 3;
            wisdom.baseValue += 1;
            strenght.baseValue -= 1;
            agility.baseValue -= 1;
            skillPoints -= 1;
            button.interactable = false;
            UpdateUI();
        }
        else
        {
            button.interactable = true;
        }
    }
    private Button lastButton;
    public void Last(Button button)
    {
        lastButton = button;
    }

    public void checkIfPossible(Button button)
    {
        if (!lastButton.interactable)
            button.interactable = true;
        else
            button.interactable = false;
    }
    private Spell newSpell;
    public void Spellnew (Spell spelly)
    {
        newSpell = spelly;
    }

    public void AddToSpellBook(Button button)
    {
        if (skillPoints > 0)
        {
            SpellBook.instance.Add(newSpell);
            button.interactable = false;
            skillPoints -= 1;
            UpdateUI();
        }
        else
        {
            button.interactable = true;
        }
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
    public Text skillPoint;

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

        skillPoint.text = skillPoints.ToString();
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
