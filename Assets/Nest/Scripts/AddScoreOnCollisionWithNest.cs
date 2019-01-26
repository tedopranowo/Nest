using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class AddScoreOnCollisionWithNest : MonoBehaviour {
    [SerializeField]
    [Tooltip("Score to be added when this object collides with nest")]
    private int m_score;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Nest nest = collision.gameObject.GetComponent<Nest>();

        if (nest != null)
        {
            nest.AddScore(m_score);
            Destroy(gameObject);
        }
    }
}
