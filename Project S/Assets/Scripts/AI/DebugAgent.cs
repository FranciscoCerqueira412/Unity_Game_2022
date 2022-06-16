using UnityEngine;
using UnityEngine.AI;

public class DebugAgent : MonoBehaviour
{
    private NavMeshAgent agent;

    public bool velocity;
    public bool desiredVelocity;
    public bool path;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void OnDrawGizmos()
    {
        if (velocity)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, transform.position + agent.velocity);
        }        
        if (desiredVelocity)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, transform.position + agent.desiredVelocity);
        }        
        if (path)
        {
            Gizmos.color = Color.black;
            Vector3 prevCorner = transform.position;
            foreach(Vector3 corner in agent.path.corners)
            {
                Gizmos.DrawLine(prevCorner, corner);
                Gizmos.DrawSphere(corner, 0.01f);

                prevCorner = corner;
            }
        }
    }
}
