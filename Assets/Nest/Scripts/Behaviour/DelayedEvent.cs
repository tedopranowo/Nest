using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class DelayedEvent : MonoBehaviour {
    [SerializeField]
    [Tooltip("How long to wait until the event is executed")]
    private float m_delayTime;

    [SerializeField]
    [Tooltip("Event to perform after the time expires")]
    private UnityEvent m_onEventTrigger;

    private Coroutine m_coroutine;

    private void Start()
    {
        m_coroutine = StartCoroutine(TriggerEventAfterDelay(m_delayTime));
    }

    private IEnumerator TriggerEventAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        m_onEventTrigger.Invoke();
    }

    /// <summary>
    /// Stop triggering the event from triggering
    /// </summary>
    public void StopEvent()
    {
        StopCoroutine(m_coroutine);
    }
}
