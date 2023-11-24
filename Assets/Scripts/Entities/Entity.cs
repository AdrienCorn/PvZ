using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(SpriteRenderer))]
public abstract class Entity<T, U> : MonoBehaviour
    where T : Enum
    where U : EntityData<T>
{
    private U data;
    private float hp;
    public bool IsDead { get; private set; }

    public void SetData(U data)
    {
        this.data = data;
        this.hp = data.hpMax;
        this.IsDead = false;
    }

    public void Update()
    {
        if (!this.IsDead)
        {

        }
    }

    public void OnAttack()
    {
        // Apply damages
    }

    public void TakeDamage(float damage)
    {
        this.hp -= damage;
        if(hp < 0) {
            this.OnDie();
        }
    }

    private void OnDie()
    {
        this.IsDead = true;
        // Animation ?
    }
}
