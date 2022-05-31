using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterController : MonoBehaviour
{
    private NavMeshAgent agent;
    private Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = target;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
        }
    }
}
