using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarRandomSpawner : MonoBehaviour
{
    public GameObject carPrefab;
    public int carToSpawn;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        int count = 0;
        while(count < carToSpawn)
        {
            GameObject obj = Instantiate(carPrefab);
            Transform child = transform.GetChild(Random.Range(0, transform.childCount - 1));
            obj.GetComponent<WaypointNavigator>().currentWaypoint = child.GetComponent<Waypoint>();
            obj.transform.position = child.position;

            yield return new WaitForEndOfFrame();

            count++;
        }
    }


}
