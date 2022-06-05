using UnityEngine;
using UnityEngine.AI;

public class SecurityController : MonoBehaviour
{
    private GameObject[] Customer;
    private NavMeshAgent agent;
    private int i;
    void Start()
    {
        Customer = GameObject.FindGameObjectsWithTag("Customer");
        agent = GetComponent<NavMeshAgent>();
        if (Customer.Length > 0)
        {
            i = Random.Range(0, Customer.Length);
        }
    }

    void Update()
    {
        if (Customer.Length > 0)
        {
            agent.SetDestination(Customer[i].transform.position);

            if (Vector3.Distance(transform.position, Customer[i].transform.position) < 3)
            {
                i = Random.Range(0, Customer.Length);
            }
        }
    }
}
