using UnityEngine;

[CreateAssetMenu]
public class GameEngine : ScriptableObject
{
    public void DestroyObject(GameObject target)
    {
        Destroy(target);
    }
}
