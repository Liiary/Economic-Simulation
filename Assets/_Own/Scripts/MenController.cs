using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenController : MonoBehaviour
{
    public Buying buying;

    public Transform target;
    public Transform start;
    public Transform player;
    //private List<Transform> points;
    private Vector3 currentPoint;
    public Animator animator;

    //public float direction;
    public float speed;
    public Rigidbody rB;

	void Start ()
    {
        buying = GameObject.FindWithTag("GameManager").GetComponent<Buying>();

        currentPoint = target.position;

        animator = GetComponent<Animator>();
    }

    public void WorkerFindTarget(int buildingWorker)
    {
        if(buildingWorker == 0)
        {
            target = GameObject.FindWithTag("FarmHouse").transform;
            start = GameObject.FindWithTag("Bank").transform;
        }
        else if(buildingWorker == 1)
        {
            target = GameObject.FindWithTag("Farm").transform;
            start = GameObject.FindWithTag("Tree").transform;
        }
        else if(buildingWorker == 2)
        {
            target = GameObject.FindWithTag("House").transform;
            start = GameObject.FindWithTag("Stone").transform;
        }
        else if(buildingWorker == 3)
        {
            target = GameObject.FindWithTag("Tower").transform;
            start = GameObject.FindWithTag("Hay").transform;
        }
    }

    void Update()
    {
        if (Vector3.Distance ( player.position , target.position) <= 0.5f)
        {
            currentPoint = start.position;
            player.LookAt(start);
        }
        if(Vector3.Distance(player.position, start.position) <= 0.9f)
        {
            currentPoint = target.position;
            player.LookAt(target);
        }
        MovePlayer(currentPoint);
    }

    public void MovePlayer(Vector3 target)
    {
        float way = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, way);

        animator.SetFloat("speed", way);
    }
}
