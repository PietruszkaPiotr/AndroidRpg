using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    public override void Die()
    {
        base.Die();
        PlayerManager.instance.player.GetComponent<PlayerStats>().AddExp(10);
        //Add ragdoll effect/death animation
        Destroy(gameObject);
    }
}
