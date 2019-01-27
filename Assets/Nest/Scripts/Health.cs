using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int m_health;
    [SerializeField] private UnityEvent m_onTakeDamage;
    [SerializeField] private UnityEvent m_onDead;

    public void TakeDamage(int damage)
    {
        m_health -= damage;
        m_onTakeDamage.Invoke();

        if (m_health <= 0)
        {
            m_onDead.Invoke();
        }
    }
}
