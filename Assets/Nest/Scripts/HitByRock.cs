using UnityEngine;
using UnityEngine.Events;

public class HitByRock : MonoBehaviour
{
    [SerializeField] private UnityEvent m_onHit;

    public void OnHitByRock()
    {
        m_onHit.Invoke();
    }
}
