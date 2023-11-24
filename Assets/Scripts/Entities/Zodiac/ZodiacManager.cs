using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ZodiacManager : MonoBehaviourSingleton<ZodiacManager>
{
    public ZodiacCollection prefabs;

    ZodiacEntity Spawn(ZodiacSign sign)
    {
        ZodiacEntity entity =  Instantiate(prefabs[sign].prefab).GetComponent<ZodiacEntity>();
        entity.SetData(prefabs[sign]);
        return entity;
    }
}
