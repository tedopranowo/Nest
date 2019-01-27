using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TargetScoreUI : MonoBehaviour
{
    [SerializeField] private IntVariable m_scoreVariable;
    [SerializeField] private IntVariable m_targetScoreVariable;
    private Text m_text;

    private void Awake()
    {
        m_text = GetComponent<Text>();
    }
    // Update is called once per frame
    void Update () {
        m_text.text = m_scoreVariable.value.ToString() + "/" + m_targetScoreVariable.value.ToString();
	}
}
