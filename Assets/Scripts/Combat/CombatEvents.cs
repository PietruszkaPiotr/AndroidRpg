using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatEvents : MonoBehaviour
{
    public delegate void EnemyEventHandler(EnemyStats enemy);
    public static event EnemyEventHandler OnEnemyDeath;

    public static void EnemyDied(EnemyStats enemy)
    {
        if (OnEnemyDeath != null)
        {
            Debug.Log("Weszło do EnemyDied");
            OnEnemyDeath(enemy);
        }
    }
}
