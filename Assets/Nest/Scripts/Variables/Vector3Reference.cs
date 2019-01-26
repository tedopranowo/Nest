using UnityEngine;

[System.Serializable]
public class Vector3Reference
{
    [SerializeField] private bool m_useConstant;
    [SerializeField] private Vector3 m_constant;
    [SerializeField] private Vector3Variable m_variable;

    public Vector3 value
    {
        get
        {
            return (m_useConstant ? m_constant : m_variable.value);
        }
        set
        {
            if (m_useConstant)
                m_constant = value;
            else
                m_variable.value = value;
        }
    }

    public static implicit operator Vector3(Vector3Reference reference)
    {
        return reference.value;
    }
}
