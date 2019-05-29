using UnityEngine;

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
    public Stat constitution;
    public Stat intelligence;
    public Stat wisdom;
    public Stat charisma;

    public event System.Action<int, int> OnHealthChanged;
    public event System.Action<int, int> OnManaChanged;
    public event System.Action<int, int> OnExpChanged;

    private void Awake()
    {
        currentHealth = maxHealth;
        currentMana = maxMana;
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
    }

    public virtual void Die()
    {
        //Die in some way;
        Debug.Log(transform.name + " died.");
    }
}
