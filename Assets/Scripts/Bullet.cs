using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 15f;


    void Update() // Move the bullet forward every frame
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) // Check for collision with an enemy
    {
        ColoredEnemy enemy = other.GetComponent<ColoredEnemy>();

        if (enemy != null)
        {
            Renderer bulletRenderer = GetComponent<Renderer>();
            Renderer enemyRenderer = enemy.GetComponent<Renderer>();

            if (bulletRenderer != null && enemyRenderer != null)
            {
                if (bulletRenderer.material.name == enemyRenderer.material.name) // Compare material names
                {
                    enemy.Damage();
                    Destroy(gameObject); 
                }
                else
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
