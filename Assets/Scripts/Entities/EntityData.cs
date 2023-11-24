using System;
using UnityEngine;

[Serializable]
public class EntityData<T> : GameObjectData<T>
    where T : Enum
{
    public float hpMax;
    public float damages;
    public float range;
    public float attackSpeed;
    public LayerMask layerMask;
    public bool throwsProjectile;
}
