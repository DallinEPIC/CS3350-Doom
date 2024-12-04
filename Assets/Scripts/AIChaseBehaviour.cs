using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIChaseBehaviour : MonoBehaviour
{
    public enum AIState { Patrol, Chase }
    [SerializeField] AIState _state;
    [SerializeField] private float _outOfSightChaseTime;
    private GameObject _player;
    private float _chaseTimer;
    private NavMeshAgent _navMeshAgent;
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _state = AIState.Patrol;
        _chaseTimer = _outOfSightChaseTime;
        _player = PlayerBehaviour.instance.gameObject;
    }

    void Update()
    {
        _chaseTimer += Time.deltaTime;

        if(CanSeePlayer()) _chaseTimer = 0;

        if (_chaseTimer < _outOfSightChaseTime) Chase();
        else _state = AIState.Patrol;

        if (_navMeshAgent.remainingDistance > _navMeshAgent.stoppingDistance) return;
        if (_state == AIState.Patrol) Patrol();
    }

    private bool CanSeePlayer()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, _player.transform.position - transform.position, out hit))
        {
            if (hit.collider.gameObject == _player)
            {
                return true;
            }
        }
        return false;
    }
    private void Patrol()
    {
        for (int i = 0; i < 100; i++) 
        { 
            Vector3 randomDirection = new Vector3(Random.Range(-10,10), 0, Random.Range(-10,10));

            NavMeshHit navMeshHit;
            if (NavMesh.SamplePosition(transform.position + randomDirection, out navMeshHit, 100, 1))
            {
                _navMeshAgent.destination = navMeshHit.position;
                return;
            }
        }
    }
    private void Chase()
    {
        _navMeshAgent.destination = _player.transform.position;
        _state = AIState.Chase;
    }
}

