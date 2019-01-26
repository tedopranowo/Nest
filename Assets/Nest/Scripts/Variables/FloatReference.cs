using UnityEngine;

[System.Serializable]
public class FloatReference
{
    [SerializeField] private FloatVariable m_variable;
    [SerializeField] private float m_constant;
    [SerializeField] private bool m_useConstant;

    public float value
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

    public static implicit operator float(FloatReference reference)
    {
        return reference.value;
    }
}
