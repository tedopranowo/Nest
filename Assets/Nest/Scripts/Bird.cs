//-------------------------------------------------------------------------------------------------
// Bird.cs
// - Character controllable by the player's input
//-------------------------------------------------------------------------------------------------
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bird : MonoBehaviour {
    enum Zone
    {
        kInDangerZone = 1,
        kInSafeZone = 2,
    }

    [SerializeField] private float m_speed;
    [SerializeField] private float m_rotationSpeed;
    [SerializeField] private UnityEvent m_onEnterDangerZone;
    [SerializeField] private UnityEvent m_onEnterDeathZone;
    [SerializeField] private UnityEvent m_onExitDangerZone;
    [SerializeField] private UnityEvent m_onExitDeathZone;
    private Zone m_currentZone;
    private Retrievable m_carriedObject;
    private List<Retrievable> m_retrievables = new List<Retrievable>();

    public bool isInDangerCircle
    {
        set
        {
            //------------------------
            // Call exit on old zone
            //------------------------
            OnExitCurrentZone();

            //------------------------
            // Update player current zone
            //------------------------
            if (value == true)
                m_currentZone |= Zone.kInDangerZone;
            if (value == false)
                m_currentZone &= ~Zone.kInDangerZone;

            //------------------------
            // Call enter on the new zone
            //------------------------
            OnEnterCurrentZone();
        }
    }

    public bool isInSafeCircle
    {
        set
        {
            //------------------------
            // Call exit on old zone
            //------------------------
            OnExitCurrentZone();

            //------------------------
            // Update player current zone
            //------------------------
            if (value == true)
                m_currentZone |= Zone.kInSafeZone;
            if (value == false)
                m_currentZone &= ~Zone.kInSafeZone;

            //------------------------
            // Call enter on the new zone
            //------------------------
            OnEnterCurrentZone();
        }
    }

    public static void Hello()
    {
        Debug.Log("Hello");
    }

	// Update is called once per frame
	private void Update () {
        HandleRotation();

        HandleForwardMovement();

        HandleRetrievingObject();
	}

    private void HandleRotation()
    {
        //Get horziontal input
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        //Rotate the character 
        transform.Rotate(horizontalInput * Vector3.back * m_rotationSpeed * Time.deltaTime);
    }

    private void HandleForwardMovement()
    {
        //Move the bird forward
        transform.position += transform.up * Time.deltaTime * m_speed;
    }

    private void HandleRetrievingObject()
    {
        //If the user press the interact button
        if (Input.GetKeyDown(KeyCode.Z))
        {
            //If the bird is not carrying anything and there is an object that can be retrieved
            if (m_carriedObject == null)
            {
                Retrievable retrievedObject = GetValidRetrievable();

                if (retrievedObject != null)
                {
                    //Carry the first object in the retrievable list
                    m_carriedObject = retrievedObject;
                    m_retrievables.Remove(retrievedObject);

                    //Set the layer of the picked object to 'flying'
                    m_carriedObject.gameObject.layer = (int)LayerConstant.kFlying;

                    //Make the object a child of bird so that it follows
                    m_carriedObject.transform.parent = transform;

                    //Center the position of the object
                    m_carriedObject.transform.localPosition = Vector3.zero;

                    //Triggers the callback on the object when retrieved
                    m_carriedObject.OnRetrieved();
                }
            }
            else
            {
                //Triggers the callback on the object when un-retrieved
                m_carriedObject.OnUnretrieved();

                //Remove the object from child
                m_carriedObject.transform.parent = null;

                //Reset the layer of the object
                m_carriedObject.ResetLayer();

                //Remove this 
                m_carriedObject = null;
            }
        }
    }

    /// <summary>
    /// Invoke exit event for current zone
    /// </summary>
    private void OnExitCurrentZone()
    {
        int zone = (int)m_currentZone;

        //Player was in danger zone
        if (zone == 1)
            m_onExitDangerZone.Invoke();
        //Player was in death zone
        else if (zone == 0)
            m_onExitDeathZone.Invoke();
    }

    /// <summary>
    /// Invoke exit event for current zone
    /// </summary>
    private void OnEnterCurrentZone()
    {
        int zone = (int)m_currentZone;

        //Player was in danger zone
        if (zone == 1)
            m_onEnterDangerZone.Invoke();
        //Player was in death zone
        else if (zone == 0)
            m_onEnterDeathZone.Invoke();
    }

    /// <summary>
    /// Notify the bird that the object is retrievable
    /// </summary>
    public void RegisterToRetrievables(Retrievable retrievable)
    {
        m_retrievables.Add(retrievable);
    }

    /// <summary>
    /// Notify the bird that the object is retrievable
    /// </summary>
    /// <param name="retrievable"></param>
    public void UnregisterFromRetrievables(Retrievable retrievable)
    {
        m_retrievables.Remove(retrievable);
    }

    /// <summary>
    /// Find a valid retrievable object from the list
    /// </summary>
    private Retrievable GetValidRetrievable()
    {
        for (int i=0; i<m_retrievables.Count; ++i)
        {
            //If we find a valid one, return it
            if (m_retrievables[i] != null)
                return m_retrievables[i];

            //If this retrievable is not valid, remove it
            m_retrievables.RemoveAt(i);
        }

        return null;
    }
}
