using System.Collections.Generic;
using UnityEngine;

public class EnemyRadarUI : MonoBehaviour {
    [SerializeField] private ObjectSet m_enemyVariables;
    [SerializeField] private Vector3Variable m_birdPosition;
    [SerializeField] private Sprite m_warningSprite;
    private List<SpriteRenderer> m_spriteUIReferences = new List<SpriteRenderer>();

    //Bad! this might be unnecessary.
    int m_spriteUIIndex = 0;

    // Update is called once per frame
    void Update() {
        //Get all enemies on the map
        List<GameObject> enemyList = m_enemyVariables.items;

        m_spriteUIIndex = 0;

        //Loop for every enemy
        for (int i = 0; i < enemyList.Count; ++i)
        {
            //If the enemy is seen on camera, don't draw anything
            if (enemyList[i].GetComponentInChildren<SpriteRenderer>().isVisible)
                continue;

            //-------------------------------------------------
            // If the enmey is not on the camera, draw their sprite on screen border
            //-------------------------------------------------
            SpriteRenderer currentWarningSprite = GetCurrentSpriteUI();

            //Calculate the direction to enemy
            Vector2 directionToEnemy = (currentWarningSprite.transform.position - m_birdPosition.value).normalized;

            //Convert direction magnitude such that x and y are <= 1 AND either of x or y is 1/-1
            //directionToEnemy.x = 

            //Convert vector to canvas point
            Vector2 canvasPosition = (directionToEnemy + Vector2.one) / 2;

            RectTransform spriteTransform = currentWarningSprite.GetComponent<RectTransform>();
            spriteTransform.pivot = canvasPosition;
            spriteTransform.offsetMin = Vector2.zero;
            spriteTransform.offsetMax = Vector2.zero;
        }
    }
    
    private SpriteRenderer GetCurrentSpriteUI()
    {
        //Increment the sprite UI index
        ++m_spriteUIIndex;

        //If the object exist in the array, return it
        if (m_spriteUIIndex < m_spriteUIReferences.Count)
        {
            return m_spriteUIReferences[m_spriteUIIndex];
        }

        //If the object doesn't exist, create a new one
        GameObject go = new GameObject("Enemy UI", typeof(RectTransform));
        go.transform.SetParent(this.transform, false);
        //go.transform.parent = this.transform;
        SpriteRenderer spriteRenderer = go.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = m_warningSprite;

        m_spriteUIReferences.Add(spriteRenderer); //Add a new object to the list

        return spriteRenderer;
    }

    
}
