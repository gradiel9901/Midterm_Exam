using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    public float rotationSpeed = 2.0f;
    public float wanderRadius = 10.0f;
    public float minWanderTime = 1.0f;
    public float maxWanderTime = 3.0f;

    private Vector3 targetPosition;
    private float wanderTime;

    void Start()
    {
        SetNewTargetPosition();
    }

    void Update()
    {
        MoveTowardsTarget();
        wanderTime -= Time.deltaTime;

        if (wanderTime <= 0)
        {
            SetNewTargetPosition();
        }
    }

    void MoveTowardsTarget()
    {
        Vector3 direction = (targetPosition - transform.position).normalized;
        direction.y = 0;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        if (direction != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }

    void SetNewTargetPosition()
    {
        Vector3 randomDirection = Random.insideUnitSphere * wanderRadius;
        randomDirection += transform.position;
        randomDirection.y = transform.position.y;

        targetPosition = randomDirection;
        wanderTime = Random.Range(minWanderTime, maxWanderTime);
    }
}
