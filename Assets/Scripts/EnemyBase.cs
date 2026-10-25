using UnityEngine;

public abstract class EnemyBase : MonoBehaviour, IDamageable // Abstract base class for enemies, implementing IDamageable interface
{
    protected Transform target;
    public float speed = 2f;
    public float rotationSpeed = 5f;
    public Color enemyColor;

    protected virtual void Start()
    {
        GameObject playerObj = GameObject.FindWithTag("Player");
        if (playerObj != null)
        {
            target = playerObj.transform;
        }
    }

    protected virtual void Update() // Update method to move and rotate the enemy towards the target
    {
        if (target == null) return;

        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        Vector3 directionToTarget = (target.position - transform.position).normalized;
        if (directionToTarget != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
            targetRotation *= Quaternion.Euler(0, -90, 0);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    public abstract void Damage();
}
