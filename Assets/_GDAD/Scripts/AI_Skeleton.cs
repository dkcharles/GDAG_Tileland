using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Skeleton : MonoBehaviour
{
    [SerializeField] Transform _target;
    NavMeshAgent _navMeshAgent;

    AI_Sketeton_StateMC _stateMachine;

    private void Awake()
    {
        _stateMachine = GetComponentInChildren<AI_Sketeton_StateMC>();
    }


    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.updateRotation = false;
        _navMeshAgent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Can see player: " + _stateMachine.CanSeePlayer());
        if (_stateMachine.CanSeePlayer())
        {
            _navMeshAgent.isStopped = false;
            _navMeshAgent.SetDestination(_target.position);
        }
        else _navMeshAgent.isStopped = true;
    }
}
