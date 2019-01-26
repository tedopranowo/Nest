using UnityEngine;

[CreateAssetMenu]
public class IntVariable : ScriptableObject{
    [SerializeField] private int m_value;

    public int value
    {
        set { m_value = value; }
        get { return m_value; }
    }
    
    /// <summary>
    /// Modify the original value by the passed value
    /// </summary>
    public void ModifyValue(int value)
    {
        m_value += value;
    }
}