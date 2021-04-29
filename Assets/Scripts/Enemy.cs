using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public ParticleSystem enemyDie;
    public int currentHealth = 3;
    public float deathTime;

    public void Damage(int damageAmount)
    {
        //güncel candan hasarım çıkıyor can 0 a gelince ölüm animasyonu ve obje yok edilmesi
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            enemyDie.Play();
            Destroy(gameObject, deathTime);
        }
    }

}
