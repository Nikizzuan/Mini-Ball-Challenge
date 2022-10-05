using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private List<Transform> waypoints;
    [SerializeField] private float moveSpeed = 5f;
    private int _currentWaypoint;
    // Start is called before the first frame update
    void Start()
    {
        if (waypoints.Count <= 0) return;
        _currentWaypoint = 0;
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }


    /// <summary>
    /// Handle Moving Platform tranform movement according to List of tranform 
    /// </summary>
    private void HandleMovement()
    {

        transform.position = Vector3.MoveTowards(transform.position, waypoints[_currentWaypoint].transform.position,
            (moveSpeed * Time.deltaTime));

        if (Vector3.Distance(waypoints[_currentWaypoint].transform.position, transform.position) < .001f)
        {
            _currentWaypoint++;

        }

        if (_currentWaypoint != waypoints.Count) return;
        waypoints.Reverse();
        _currentWaypoint = 0;
    }

   
}
