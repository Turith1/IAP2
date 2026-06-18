using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float distCheck = 10;
    [SerializeField] private LayerMask playerMask;

    public bool DetectPlayer()
    {
        float dist = Vector3.Distance(transform.position, playerTransform.position);

        if (dist > distCheck)
            return false;

        Vector3 dir = (playerTransform.position - transform.position).normalized;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, dir, out hit, distCheck + 5))
        {
            Debug.DrawRay(transform.position, dir * (distCheck + 5), Color.red, 2);
            return hit.collider.CompareTag("Player");
        }

        return false;
    }

    public float PlayerDistance()
    {
        return Vector3.Distance(transform.position, playerTransform.position);
    }
}
