using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour {

    public Transform goal;
    private Base _base;

    // Use this for initialization
    void Start () {

        _base = FindObjectOfType<Base>();

        if (_base != null) {
            goal = _base.transform;
            NavMeshAgent agent = GetComponent<NavMeshAgent>();
            agent.destination = goal.position;
        }
	}
}
