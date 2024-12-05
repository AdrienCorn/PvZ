using System;
using UnityEngine;

[Serializable]
public class GameObjectData<T>
    where T : Enum
{
    public GameObject prefab;
    public T enumType;
}