using UnityEngine;
using UnityEngine.UI;

public class SpellSlot : MonoBehaviour
{
    public Image icon;
    Spell spell;

    public void AddSpell(Spell newSpell)
    {
        Debug.Log("Weszło do Slota");
        spell = newSpell;
        icon.sprite = spell.icon;
        icon.enabled = true;
    }

    public void UseSpell(Button spellButton)
    {
        if (spell != null)
        {
            Debug.Log("Jest");
        }
    }
}
