using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ObjectSet : ScriptableObject {
    public List<GameObject> items = new List<GameObject>();

    public void Add(GameObject thing)
    {
        if (!items.Contains(thing))
            items.Add(thing);
    }

    public void Remove(GameObject thing)
    {
        if (items.Contains(thing))
            items.Remove(thing);
    }
}