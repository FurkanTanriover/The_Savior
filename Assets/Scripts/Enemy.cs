using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static event WinLoseScreen.WinEnemyAction EnemyDead;

    private Animator anim;
    public int currentHealth = 1;
    public float deathTime = 5;


    public void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Civilian"))
        {
            anim.SetBool("EnemyMelee", true);
             WinLoseScreen.Instance.Lose();
        }
    }

    public void Damage(int damageAmount)
    {
        //güncel candan hasarım çıkıyor can 0 a gelince ölüm animasyonu ve obje yok edilmesi
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            EnemyDead?.Invoke();
            Death();
            Destroy(gameObject, deathTime);
        }
    }

    public void Death()
    {
        anim.SetTrigger("Death");
    }

}
