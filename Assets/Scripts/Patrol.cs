using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    /*public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = false;

        GotoNextPoint();
    }


    private void OntriggerEnter(Collider coll)
    {
        if (coll.CompareTag("EndArea"))
        {
            Debug.Log("AMMAR");
            agent.enabled = false;
        }
    }

    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;
    }


    void Update()
    {
        // Choose the next destination point when the agent gets
        // close to the current one.
        if (!agent.pathPending && agent.remainingDistance < 1.5f)
            GotoNextPoint();

    }*/

    [SerializeField]
    private Transform endAreaTR;


    private bool isCivilianGo = true;

    private Animator anim;

    private Vector3 endAreaVec3;

    private void Start()
    {
        anim = GetComponent<Animator>();
        endAreaVec3 = new Vector3(endAreaTR.position.x, transform.position.y, endAreaTR.position.z);
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("EndArea"))
        {
            anim.SetBool("FinishTarget", true);
            isCivilianGo = false;
        }
    }

    private void Update()
    {
        if (isCivilianGo)
            transform.position = Vector3.MoveTowards(transform.position, endAreaVec3, 3f * Time.deltaTime);
    }
}


