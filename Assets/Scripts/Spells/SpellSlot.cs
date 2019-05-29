using UnityEngine;
using UnityEngine.UI;

public class SpellSlot : MonoBehaviour
{
    public Image icon;
    Spell spell;

    public void AddItem(Spell newSpell)
    {
        spell = newSpell;
        icon.sprite = spell.icon;
        icon.enabled = true;
    }

    public void UseSpell(Button spellButton)
    {
        if (spell != null)
        {
            
        }
    }
}
