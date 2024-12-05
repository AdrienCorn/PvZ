using UnityEngine;
using System;
using System.Collections.Generic;

public class GameObjectCollection<T, U> : ScriptableObject
    where T : Enum
    where U : GameObjectData<T>
{
    private Dictionary<T, U> dict;
    public U[] AllObject;
    public U this[T type]
    {
        get
        {
            Init();
            return dict[type];
        }
    }

    private void Init()
    {
        if (dict != null)
            return;
        dict = new Dictionary<T, U>();
        foreach (var objectData in AllObject)
        {
            dict[objectData.enumType] = objectData;
        }
    }
}