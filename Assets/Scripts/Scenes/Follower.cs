using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Follower : MonoBehaviour
{
    NavMeshAgent follower;

    public Transform target;

    void Start()
    {
        follower = GetComponent<NavMeshAgent>();

    }

    void Update()
    {
        follower.destination = target.position;
    }
}
