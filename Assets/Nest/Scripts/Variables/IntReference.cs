using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class IntReference {
    [SerializeField] private IntVariable m_intVariable;
    [SerializeField] private int m_intConstant;
    [SerializeField] private bool m_isConstant;

    public int value
    {
        get
        {
            return (m_isConstant ? m_intConstant : m_intVariable.value);
        }
        set
        {
            if (m_isConstant)
                m_intConstant = value;
            else
                m_intVariable.value = value;
        }
    }

    public static implicit operator int(IntReference reference)
    {
        return reference.value;
    }
}
