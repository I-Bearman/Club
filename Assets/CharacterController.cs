using UnityEngine;
using UnityEngine.AI;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPlatform;
    [SerializeField] private GameObject targetPref;
    private NavMeshAgent agent;
    private GameObject target;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        CheckAndUseTarget();

        if (Vector3.Distance(transform.position, target.transform.position) < 3)
        {
            Destroy(target);
        }
    }

    private GameObject TargetSpawn(int spawnTransformNum)
    {
        float volumeX = spawnPlatform[spawnTransformNum].transform.localScale.x / 2;
        float volumeZ = spawnPlatform[spawnTransformNum].transform.localScale.z / 2;

        Vector3 pos = new Vector3(Random.Range(spawnPlatform[spawnTransformNum].position.x - volumeX, spawnPlatform[spawnTransformNum].position.x + volumeX), spawnPlatform[spawnTransformNum].position.y + 1, Random.Range(spawnPlatform[spawnTransformNum].position.z - volumeZ, spawnPlatform[spawnTransformNum].position.z + volumeZ));
        GameObject obj = Instantiate(targetPref, pos, Quaternion.identity);
        return obj;
    }

    private void CheckAndUseTarget()
    {
        if (target == null)
        {
        Again:
            int i = Random.Range(0, spawnPlatform.Length);
            target = TargetSpawn(i);
            NavMeshPath path = new NavMeshPath();
            NavMesh.CalculatePath(transform.position, target.transform.position, NavMesh.AllAreas, path);
            if (path.status == NavMeshPathStatus.PathComplete)
            {
                agent.destination = target.transform.position;
            }
            else
            {
                Destroy(target);
                goto Again;
            }
        }
    }
}
