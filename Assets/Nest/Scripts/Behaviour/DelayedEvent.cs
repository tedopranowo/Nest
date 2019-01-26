using UnityEngine;
using UnityEngine.Events;

public class DelayedEvent : MonoBehaviour {
    [SerializeField]
    [Tooltip("How long to wait until the event is executed")]
    private float m_delayTime;

    [SerializeField]
    [Tooltip("Event to perform after the time expires")]
    private UnityEvent m_onEventTrigger;

    private void Start()
    {
        Invoke("OnEventTrigger", m_delayTime);
    }

    private void OnEventTrigger()
    {
        m_onEventTrigger.Invoke();
    }

}
