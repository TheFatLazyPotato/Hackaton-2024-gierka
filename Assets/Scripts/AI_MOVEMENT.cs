
using UnityEngine;
using UnityEngine.AI;

public class Chodzenie_drukarzy : MonoBehaviour{

    public GameObject objectManager;
    public GameManager gameManager;
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask co_ziemia, co_gracz;

    // Chodzonko 
    public Vector3 walkPoint;


    // biurka
    public int biurko;
    public Vector3 miejsceDruku;

    // stan
    private bool walkPointSet;
    public Vector3 distanceToWalkPoint;

    private Rigidbody rb;
    private void Awake()
    {
        objectManager = GameObject.Find("GameManager");
        gameManager = objectManager.GetComponent<GameManager>();
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        co_ziemia = LayerMask.GetMask("co_ziemia");
        co_gracz = LayerMask.GetMask("co_gracz");
        biurko = gameManager.chosenDesk;
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        //biurko = gameManager.chosenDesk;
        switch (biurko) {
            case 1:
                miejsceDruku.x = -13f;
                miejsceDruku.y = 1.7f;
                miejsceDruku.z = -6f;
                break;
            case 2:
                miejsceDruku.x = -13f;
                miejsceDruku.y = 1.7f;
                miejsceDruku.z = -1f;
                break;
            case 3:
                miejsceDruku.x = -13f;
                miejsceDruku.y = 1.7f;
                miejsceDruku.z = 4f;
                break;
            case 4:
                miejsceDruku.x = -6.5f;
                miejsceDruku.y = 1.7f;
                miejsceDruku.z = -6f;
                break;
            case 5:
                miejsceDruku.x = -6.5f;
                miejsceDruku.y = 1.7f;
                miejsceDruku.z = -1f;
                break;
            case 6:
                miejsceDruku.x = -6.5f;
                miejsceDruku.y = 1.7f;
                miejsceDruku.z = 4f;
                break;
            case 7:
                miejsceDruku.x = 0f;
                miejsceDruku.y = 1.7f;
                miejsceDruku.z = -6f;
                break;
            case 8:
                miejsceDruku.x = 0f;
                miejsceDruku.y = 1.7f;
                miejsceDruku.z = -1f;
                break;
            case 9:
                miejsceDruku.x = 0f;
                miejsceDruku.y = 1.7f;
                miejsceDruku.z = 4f;
                break;
            case 10:
                miejsceDruku.x = 6.5f;
                miejsceDruku.y = 1.7f;
                miejsceDruku.z = -6f;
                break;
            case 11:
                miejsceDruku.x = 6.5f;
                miejsceDruku.y = 1.7f;
                miejsceDruku.z = -1f;
                break;
            case 12:
                miejsceDruku.x = 6.5f;
                miejsceDruku.y = 1.7f;
                miejsceDruku.z = 4f;
                break;
            


        }
    }
    private void Update()
    {
        walkPointSet = true;
        if (gameManager.desksAvailable[biurko])
        {
            rb.isKinematic = false;
            miejsceDruku.x = 10f;
            miejsceDruku.y = 1.6f;
            miejsceDruku.z = -19f;
            agent.SetDestination(miejsceDruku);
        }
        distanceToWalkPoint = transform.position - miejsceDruku;
        if (distanceToWalkPoint.magnitude < 1f && walkPointSet)
        {
            walkPointSet = false;
            rb.isKinematic = true;
        }
        if (walkPointSet)
        {
            agent.SetDestination(miejsceDruku);
        }
    }

} 