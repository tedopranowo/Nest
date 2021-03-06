﻿using UnityEngine;

public class CameraFollow : MonoBehaviour {

    [SerializeField] private GameObject m_targetToFollow;
	
	// Update is called once per frame
	void Update () {
        UpdatePosition();
	}

    /// <summary>
    /// Update the camera position
    /// </summary>
    private void UpdatePosition()
    {
        //Don't do anything if we don't have target to follow
        if (m_targetToFollow == null)
            return;

        Vector3 targetPosition = m_targetToFollow.transform.position;
        Vector3 cameraPosition = transform.position;
        cameraPosition.x = targetPosition.x;
        cameraPosition.y = targetPosition.y;
        transform.position = cameraPosition;
    }
}
