using UnityEngine;

public class Racoon : MonoBehaviour
{
    [SerializeField] private Vector3Reference m_targetLocation;
    [SerializeField] private FloatReference m_speed;

    private void Update()
    {
        //Change fox direction towards the nest
        transform.up = m_targetLocation - transform.position;

        //Move the fox toward target location
        transform.position += transform.up * Time.deltaTime * m_speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Nest nest = collision.gameObject.GetComponent<Nest>();

        //If the racooon colliding with a nest, reduce the nest health and kill the racoon
        if (nest != null)
        {
            nest.TakeDamage(1);
            Destroy(gameObject);
        }
    }
}
