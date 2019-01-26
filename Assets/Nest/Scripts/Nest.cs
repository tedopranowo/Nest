using UnityEngine;
using UnityEngine.Events;

public class Nest : MonoBehaviour {
    [SerializeField] private Vector3Variable m_locationVariable;
    [SerializeField] private IntVariable m_healthVariable;
    [SerializeField] private IntVariable m_score;
    [SerializeField] private IntReference m_startingHealth;
    [SerializeField] private UnityEvent m_onReceiveDamage;
    [SerializeField] private UnityEvent m_onDeath;

    private void Awake()
    {
        m_locationVariable.value = transform.position;
    }

    private void Start()
    {
        m_healthVariable.value = m_startingHealth;
        m_score.value = 0;
    }

    /// <summary>
    /// Reduce the health by damage taken
    /// </summary>
    public void TakeDamage(int damage)
    {
        m_healthVariable.value = m_healthVariable.value - damage;
        m_onReceiveDamage.Invoke();

        if (m_healthVariable.value <= 0)
        {
            m_onDeath.Invoke();
        }
    }

    /// <summary>
    /// Increase the player score
    /// </summary>
    public void AddScore(int score)
    {
        m_score.value += score;
    }
}
