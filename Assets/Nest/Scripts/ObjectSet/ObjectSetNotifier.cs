using UnityEngine;

public class ObjectSetNotifier : MonoBehaviour {

    [SerializeField] private ObjectSet m_objectSet;

    private void Awake()
    {
        m_objectSet.Add(gameObject);
    }

    private void OnDestroy()
    {
        m_objectSet.Remove(gameObject);
    }
}