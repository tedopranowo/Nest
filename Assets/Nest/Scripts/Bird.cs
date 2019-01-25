//-------------------------------------------------------------------------------------------------
// Bird.cs
// - Character controllable by the player's input
//-------------------------------------------------------------------------------------------------
using UnityEngine;

public class Bird : MonoBehaviour {
    [SerializeField] private float m_speed;
    [SerializeField] private float m_rotationSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        HandleRotation();

        HandleForwardMovement();
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
}
