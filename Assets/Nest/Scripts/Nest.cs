using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Nest : MonoBehaviour {
    [SerializeField] private Vector3Variable m_locationVariable;
    [SerializeField] private IntVariable m_healthVariable;
    [SerializeField] private IntVariable m_scoreVariable;
    [SerializeField] private IntVariable m_targetScoreVariable;
    [SerializeField] private IntReference m_startingHealth;
    [SerializeField] private int m_targetScore;
    [SerializeField] private List<GameObject> m_hatchlings;
    [SerializeField] private UnityEvent m_onReceiveDamage;
    [SerializeField] private UnityEvent m_onDeath;
    [SerializeField] private UnityEvent m_onTargetScoreFulfilled;

    private void Awake()
    {
        m_locationVariable.value = transform.position;
    }

    private void Start()
    {
        m_healthVariable.value = m_startingHealth;
        m_scoreVariable.value = 0;
        m_targetScoreVariable.value = m_targetScore;
    }

    /// <summary>
    /// Reduce the health by damage taken
    /// </summary>
    public void TakeDamage(int damage)
    {
        m_healthVariable.value = m_healthVariable.value - damage;

        //Kill one of the hatchling
        Destroy(m_hatchlings[0]);
        m_hatchlings.RemoveAt(0);

        //Trigger on receive damage event
        m_onReceiveDamage.Invoke();

        //Triger on Death event
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
        m_scoreVariable.value += score;

        if (m_scoreVariable.value >= m_targetScore)
            m_onTargetScoreFulfilled.Invoke();
    }
}
