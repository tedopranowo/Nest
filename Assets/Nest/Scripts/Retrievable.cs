//-------------------------------------------------------------------------------------------------
// Retrievable.cs
// - GameObject which has this component can be carried by the Bird
//-------------------------------------------------------------------------------------------------
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class Retrievable : MonoBehaviour
{
    [SerializeField] private UnityEvent m_onRetrieved;
    [SerializeField] private UnityEvent m_onUnretrieved;
    private int m_originalLayer;

#if UNITY_EDITOR
    private void OnValidate()
    {
        //Make sure that this object has a 2D trigger
        Collider2D[] colliders = GetComponents<Collider2D>();

        //Iterate through all colliders
        for (int i = 0; i < colliders.Length; ++i)
        {
            //If the collider is a trigger, the test is successfull
            if (colliders[i].isTrigger)
                return;
        }

        //If no trigger is found, shows an error
        Debug.LogError(gameObject.name + " doesn't have a trigger");
    }
#endif

    private void Awake()
    {
        m_originalLayer = gameObject.layer;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Bird bird = collision.gameObject.GetComponent<Bird>();

        if (bird != null)
        {
            bird.RegisterToRetrievables(this);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Bird bird = collision.gameObject.GetComponent<Bird>();

        if (bird != null)
        {
            bird.UnregisterFromRetrievables(this);
        }
    }

    /// <summary>
    /// This method gets called when this object is retrieved
    /// </summary>
    public void OnRetrieved()
    {
        m_onRetrieved.Invoke();
    }

    /// <summary>
    /// This method gets called when this object is un-retrieved
    /// </summary>
    public void OnUnretrieved()
    {
        m_onUnretrieved.Invoke();
    }

    /// <summary>
    /// Reset the layer of this object to it's starting value
    /// </summary>
    public void ResetLayer()
    {
        gameObject.layer = m_originalLayer;
    }
}
