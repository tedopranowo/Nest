using UnityEngine;

[CreateAssetMenu]
public class Vector3Variable : ScriptableObject {
    [SerializeField] private Vector3 m_value;

    public Vector3 value
    {
        set { m_value = value; }
        get { return m_value; }
    }

    /// <summary>
    /// Modify the original value by the passed value
    /// </summary>
    public void ModifyValue(Vector3 value)
    {
        m_value += value;
    }
}
