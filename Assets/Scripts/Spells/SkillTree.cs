using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTree : MonoBehaviour
{
    #region Singleton
    public static SkillTree instance;

    public void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of SkillTree found!");
            return;
        }
        instance = this;
    }
    #endregion

    public void DisplayDesc()
    {
        Debug.Log("");
    }
}