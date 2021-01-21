using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    public GameObject breakable;
    public float breakEnergy;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "ColliderBottom")
        {
            if (KineticEnergy(collision.rigidbody) >= breakEnergy)
            {
                Instantiate(breakable, transform.position, transform.rotation);
                Destroy(gameObject);
            }
            else
            {
                rb.constraints = RigidbodyConstraints.FreezeAll;
            }
        }

    }

    public static float KineticEnergy(Rigidbody rb)
    {
        //mass = kg
        //velocity = meter per second
        //result = joules
        return 0.5f * rb.mass * Mathf.Pow(rb.velocity.magnitude, 2);
    }

}
