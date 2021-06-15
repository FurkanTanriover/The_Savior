using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Follower : MonoBehaviour
{
    NavMeshAgent follower;

    public Transform civilTR;

    private bool zombieFollower;

    private float randSpeed;

    private Vector3 targetOffset;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        randSpeed = Random.Range(6, 10);
        targetOffset = new Vector3(Random.Range(-4, 4), transform.localPosition.y, Random.Range(-10, -5));
        zombieFollower = true;
    }

    private void Update()
    {
        if (zombieFollower)
        {
            Vector3 civilPos = civilTR.position;
            Vector3 target = new Vector3(civilPos.x + targetOffset.x, transform.position.y, civilPos.z + targetOffset.z);
            transform.position = Vector3.MoveTowards(transform.position, target, randSpeed * Time.deltaTime);

            if (transform.position == target)
            {
                zombieFollower = false;
                anim.SetBool("EnemyMelee", true);
            }

        }
    }
}
