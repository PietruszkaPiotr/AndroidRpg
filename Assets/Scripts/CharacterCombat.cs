using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour
{
    protected const float combatCooldown = 5f;
    public bool InCombat { get; protected set; }
    protected float lastAttackTime;
    protected CharacterStats myStats;
    protected CharacterStats oponentStats;

    public float attackSpeed = 1f;
    protected float attackCooldown = 0f;
    public float attackDelay = .6f;


    public event System.Action OnAttack;
    

    protected virtual void Start()
    {
        //stats
        myStats = GetComponent<CharacterStats>();
    }

    protected virtual void Update()
    {
        attackCooldown -= Time.deltaTime;
        if(attackCooldown<0)
        {
            attackCooldown = 0;
        }
        if(Time.time - lastAttackTime > combatCooldown)
        {
            InCombat = false;
        }
    }
    
    public virtual void Attack(CharacterStats targetStats)
    {
        if(attackCooldown <= 0f)
        {
            oponentStats = targetStats;
            string name = transform.name;
            int aim = Random.Range(1, 20);
            int damage = myStats.maxDamage.GetValue();
            //targetStats.TakeDamage(damage);
            //Debug.Log(name + " dealing "+damage+" damage");
            if(transform.tag=="Player")
            {
                StartCoroutine(DoDamage(attackDelay));
            }
            if(OnAttack !=null)
            {
                OnAttack();
            }
            attackCooldown = 1f / attackSpeed;
            InCombat = true;
            lastAttackTime = Time.time;
        }
        
    }



    protected IEnumerator DoDamage(float delay, int damageBuff = 0)
    {
        yield return new WaitForSeconds(delay);
        oponentStats.TakeDamage(myStats.maxDamage.GetValue() + damageBuff);
        if (oponentStats.currentHealth <= 0)
        {
            InCombat = false;
        }
    }

    public void AttackHit_AnimationEvent()
    {
        oponentStats.TakeDamage(myStats.maxDamage.GetValue());
        if (oponentStats.currentHealth <= 0)
        {
            InCombat = false;
        }
    }
}
