using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Spell", menuName = "SpellBook/Spell")]
public class Spell : ScriptableObject
{
    public string Name;
    public string description;
    public Sprite icon;
    public Sprite iconButton;
    public string required;
    public int value;
}
