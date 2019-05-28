using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : CharacterCombat
{
    public CharacterStats playerStats;
    public float fireballCooldown = 0f;
    public float fireballDelay = 10f;
    public float fireballRange = 10f;
    public PlayerController controller;
    public event System.Action OnFireball;
    new public event System.Action OnAttack;
    protected override void Start()
    {
        base.Start();
    }
    protected override void Update()
    {
        base.Update();
        fireballCooldown -= Time.deltaTime;
        if (fireballCooldown < 0)
        {
            fireballCooldown = 0;
        }
    }
    public override void Attack(CharacterStats targetStats)
    {
        if (controller != null)
        {
            if (controller.focus == null)
            {
                return;
            }
        }
        base.Attack(targetStats);
        if (OnAttack != null)
        {
            OnAttack();
        }

    }
    public void PlayerAttack()
    {
        Interactable focus = controller.focus;
        if (focus != null && focus.tag == "Enemy")
        {
            float distance = Vector3.Distance(focus.transform.position, PlayerManager.instance.player.transform.position);
            if (distance > 3)
            {
                Debug.Log("Out of range");
            }
            else
            {
                CharacterStats focusStats = focus.GetComponent<CharacterStats>();
                Attack(focusStats);
            }

        }
        else
        {
            Debug.Log("Noone to attack");
        }
    }
    public void PlayerFireball()
    {
        Interactable focus = controller.focus;
        if (focus != null && focus.tag == "Enemy")
        {
            CharacterStats focusStats = focus.GetComponent<CharacterStats>();
            CastFireball(focusStats);

        }
        else
        {
            Debug.Log("Noone to attack");
        }
    }
    public void CastFireball(CharacterStats targetStats)
    {


        if (fireballCooldown <= 0)
        {
            if (controller != null)
            {
                if (controller.focus == null)
                {
                    Debug.Log("No target to cast fireball");
                    return;
                }
                Vector3 position = transform.position;
                Vector3 enemyPosition = controller.focus.transform.position;
                float distance = Vector3.Distance(position, enemyPosition);
                if (distance > fireballRange)
                {
                    Debug.Log("Target too far away");
                    controller.Follow(fireballRange - 3f);
                    return;
                }
            }
            oponentStats = targetStats;
            string name = transform.name;
            int damage = Random.Range(1, 20);
            damage += myStats.maxDamage.GetValue();
            //targetStats.TakeDamage(damage);
            //Debug.Log(name + " Casting fireball, doing " + damage + " damage");
            StartCoroutine(DoDamage(1f, damage));
            if (OnFireball != null)
            {
                OnFireball();
            }
            fireballCooldown = fireballDelay;
            InCombat = true;
            lastAttackTime = Time.time;
        }
    }
}
