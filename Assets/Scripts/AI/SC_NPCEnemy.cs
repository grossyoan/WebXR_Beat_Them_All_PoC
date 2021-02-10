using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Rigidbody))]

public class SC_NPCEnemy : MonoBehaviour, IEntity
{
    public float attackDistance = 3f;
    public float movementSpeed = 4f;
    public float npcHP = 100;
    //How much damage will npc deal to the player
    public float npcDamage = 5;
    public float attackRate = 0.5f;
    public GameObject npcDeadPrefab;
    Vector3 destination;

    [HideInInspector]
    public Transform playerTransform;
    PlayerZone PlayerPosition;
    public GameObject Player;
    public SC_EnemySpawner es;
    NavMeshAgent agent;
    float nextAttackTime = 0;
    Rigidbody r;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        PlayerPosition = GameObject.FindObjectOfType<PlayerZone>();
        agent.stoppingDistance = attackDistance;
        agent.speed = movementSpeed;
        r = GetComponent<Rigidbody>();
        r.useGravity = false;
        r.isKinematic = true; 
    }

    // Update is called once per frame
    void Update()
    {
        //Move towardst he player
        //agent.destination = PlayerPosition.transform.position;
        destination = PlayerPosition.transform.position;
        agent.SetDestination(destination);
        //Always look at player
        transform.LookAt(new Vector3(0, transform.position.y, 10));
        //Gradually reduce rigidbody velocity if the force was applied by the bullet
        r.velocity *= 0.99f;
    }

    public void ApplyDamage(float points)
    {
        npcHP -= points;
        Debug.Log("Aouch");
        if(npcHP <= 0)
        {
            //Destroy the NPC
            GameObject npcDead = Instantiate(npcDeadPrefab, transform.position, transform.rotation);
            //Slightly bounce the npc dead prefab up
            npcDead.GetComponent<Rigidbody>().velocity = (-(playerTransform.position - transform.position).normalized * 8) + new Vector3(0, 5, 0);
            Destroy(npcDead, 10);
            es.EnemyEliminated();
            Destroy(this.gameObject);
        }
    }
}