using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class CharacterController : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private Transform spawn_point;
    [SerializeField] private GameObject targetPref;
    private GameObject target;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (target == null)
        {
            target = TargetSpawn();
            agent.destination = target.transform.position;
        }

        if ((Input.GetKeyDown(KeyCode.Alpha1)) ||  Vector3.Distance(transform.position, target.transform.position) < 1)   //!!!!!!!!!
        {
            Destroy(target);
        }
    }


        private GameObject TargetSpawn()
    {
        float volumeX = spawn_point.transform.localScale.x / 2;
        float volumeZ = spawn_point.transform.localScale.z / 2;

        Vector3 pos = new Vector3(Random.Range(spawn_point.position.x - volumeX, spawn_point.position.x + volumeX), spawn_point.position.y + 1, Random.Range(spawn_point.position.z - volumeZ, spawn_point.position.z + volumeZ));
        GameObject obj = Instantiate(targetPref, pos, Quaternion.identity);
        return obj;
    }


}
