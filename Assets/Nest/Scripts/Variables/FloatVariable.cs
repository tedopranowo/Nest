using UnityEngine;

[CreateAssetMenu]
public class FloatVariable : ScriptableObject {
    [SerializeField] private float m_value;

    public float value
    {
        set { m_value = value; }
        get { return m_value; }
    }

    /// <summary>
    /// Modify the original value by the passed value
    /// </summary>
    public void ModifyValue(float value)
    {
        m_value += value;
    }
}
