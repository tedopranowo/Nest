using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Event : ScriptableObject {
    private List<EventListener> m_eventListeners = new List<EventListener>();
	
    /// <summary>
    /// Trigger the action on all event listeners
    /// </summary>
    public void Raise()
    {
        for (int i=0; i<m_eventListeners.Count; ++i)
        {
            if (m_eventListeners[i] == null)
            {
                m_eventListeners.RemoveAt(i);
                continue;
            }

            m_eventListeners[i].OnEventRaised();
        }
    }

    /// <summary>
    /// Add the event listener to the list of listeners
    /// </summary>
    public void Register(EventListener eventListener)
    {
        m_eventListeners.Add(eventListener);
    }

    /// <summary>
    /// Remove the event listener from the list of listeners
    /// </summary>
    /// <param name="eventListener"></param>
    public void Unregister(EventListener eventListener)
    {
        m_eventListeners.Remove(eventListener);
    }
}
