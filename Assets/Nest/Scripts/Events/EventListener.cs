using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventListener : MonoBehaviour {

    [SerializeField]
    [Tooltip("Event to listen to which will trigger the action")]
    private List<Event> m_eventToListen = new List<Event>();

    [SerializeField]
    [Tooltip("Action to trigger when the event is raised")]
    private UnityEvent m_onEventRaised;

    /// <summary>
    /// Register this event listener on target event
    /// </summary>
    private void OnEnable()
    {
        for (int i = 0; i < m_eventToListen.Count; ++i)
        {
            m_eventToListen[i].Register(this);
        }
    }

    /// <summary>
    /// Unregister this event listener from target event
    /// </summary>
    private void OnDisable()
    {
        for (int i = 0; i < m_eventToListen.Count; ++i)
        {
            m_eventToListen[i].Unregister(this);
        }
    }

    /// <summary>
    /// Trigger the action on this event listener
    /// </summary>
	public void OnEventRaised()
    {
        m_onEventRaised.Invoke();
    }
}
