using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class Border : MonoBehaviour
{
    [SerializeField]
    [Tooltip("This will get called when Bird enter the trigger collider")]
    private UnityEvent m_onEnterBorder;

    [SerializeField]
    [Tooltip("This will get called when Bird leaves the trigger collider")]
    private UnityEvent m_onExitBorder;

    //private void OnCollisionExit2D(Collision2D collision)
    private void OnTriggerExit2D(Collider2D collision)
    {
        Bird birdComponent = collision.gameObject.GetComponent<Bird>();

        if (birdComponent != null)
        {
            m_onExitBorder.Invoke();
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Bird birdComponent = collision.gameObject.GetComponent<Bird>();

        if (birdComponent != null)
        {
            m_onEnterBorder.Invoke();
        }
    }
}
