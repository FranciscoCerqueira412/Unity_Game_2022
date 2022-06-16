using UnityEngine;
using UnityEngine.AI;
public class AIMovement : MonoBehaviour
{
    //vars
    public Transform playerTransform;
    public float maxTime = 1.0f;
    public float minDistance = 1.0f;

    private NavMeshAgent agent;
    private Animator animator;
    private float timer = 0.0f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    //using a timer because we should not be settings a new AI path each frame - it's hell for performance
    void Update()
    {
        //tick time
        timer -= Time.deltaTime;
        //when timer reaches 0
        if(timer < 0.0f)
        {
            //calcules the distance between the player and the agent (using sqrMagnitude because of efficiency but it would be just fine without it)
            float distance = (playerTransform.position - agent.destination).sqrMagnitude;

            if (distance > minDistance*minDistance)
            {
                agent.destination = playerTransform.position;
            }
            timer = maxTime;
        }

        animator.SetFloat("Speed", agent.velocity.magnitude);
    }
}
