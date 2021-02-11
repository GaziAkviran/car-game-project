using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointNavigator : MonoBehaviour
{
    CarAI controller;
    public Waypoint currentWaypoint;

    private void Awake()
    {
        controller = GetComponent<CarAI>();
    }

    private void Start()
    {
        controller.SetDestination(currentWaypoint.GetPosition());
    }

    private void Update()
    {
        if (controller.reachedDestination)
        {
            currentWaypoint = currentWaypoint.nextWaypoint;
            controller.SetDestination(currentWaypoint.GetPosition());
        }
    }
}
