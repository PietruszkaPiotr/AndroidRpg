using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    // Start is called before the first frame update
    void Start()
    {
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
    }

    void OnEquipmentChanged (Equipment newItem, Equipment oldItem)
    {
        if(newItem!=null)
        {
            
            minDamage.AddModifier(newItem.minDamageModifier);
            maxDamage.AddModifier(newItem.maxDamageModifier);
            magicDamage.AddModifier(newItem.magicDamageModifier);
            armour.AddModifier(newItem.armorModifier);
            magicResist.AddModifier(newItem.magicResistModifier);

            strenght.AddModifier(newItem.strenghtModifier);
            agility.AddModifier(newItem.agilityModifier);
            condition.AddModifier(newItem.constitutionModifier);
            intelligence.AddModifier(newItem.intelligenceModifier);
            wisdom.AddModifier(newItem.wisdomModifier);
            charisma.AddModifier(newItem.charismaModifier);

            stats[0] = strenght.baseValue;
            stats[1] = agility.baseValue;
            stats[2] = condition.baseValue;
            stats[3] = intelligence.baseValue;
            stats[4] = wisdom.baseValue;
            stats[5] = charisma.baseValue;

            UpdateUI();
        }
        if(oldItem!=null)
        {

            minDamage.RemoveModifier(oldItem.minDamageModifier);
            maxDamage.RemoveModifier(oldItem.maxDamageModifier);
            magicDamage.RemoveModifier(oldItem.magicDamageModifier);
            armour.RemoveModifier(oldItem.armorModifier);
            magicResist.RemoveModifier(oldItem.magicResistModifier);

            strenght.RemoveModifier(oldItem.strenghtModifier);
            agility.RemoveModifier(oldItem.agilityModifier);
            condition.RemoveModifier(oldItem.constitutionModifier);
            intelligence.RemoveModifier(oldItem.intelligenceModifier);
            wisdom.RemoveModifier(oldItem.wisdomModifier);
            charisma.RemoveModifier(oldItem.charismaModifier);

            stats[0] = strenght.baseValue;
            stats[1] = agility.baseValue;
            stats[2] = condition.baseValue;
            stats[3] = intelligence.baseValue;
            stats[4] = wisdom.baseValue;
            stats[5] = charisma.baseValue;

            UpdateUI();
        }
    }

    public override void Die()
    {
        base.Die();
        PlayerManager.instance.KillPlayer();

    }
}
