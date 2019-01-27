using UnityEngine;

public class BirdHealthUI : MonoBehaviour {
    [Tooltip("The object that will be disabled when life decrease")]
    [SerializeField]
    private GameObject[] m_healthUIs;

    [SerializeField]
    private IntVariable m_healthVariable;

	
	// Update is called once per frame
	void Update () {
        int index = 0;
        //Set the health UI to active according to current amount of health
		for(; index < m_healthVariable.value; ++index)
        {
            m_healthUIs[index].SetActive(true);
        }

        //Set the health UI to inactive according to health missing
        for(;index < m_healthUIs.Length; ++index)
        {
            m_healthUIs[index].SetActive(false);
        }
	}
}
