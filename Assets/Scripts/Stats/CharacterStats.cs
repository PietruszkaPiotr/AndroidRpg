﻿using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth { get; private set; }

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

    private void Awake()
    {
        currentHealth = maxHealth;
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
        damage -= armour.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);


        currentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage.");

        if(OnHealthChanged!=null)
        {
            OnHealthChanged.Invoke(maxHealth,currentHealth);
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
