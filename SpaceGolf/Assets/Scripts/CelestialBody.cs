using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelestialBody : MonoBehaviour
{

    public Rigidbody2D rb;
    public Vector3 initVelocity;
    public bool isMainBody;

    void Start()
    {
        rb.mass = transform.localScale.x * 10f;
        rb.velocity = initVelocity;
    }


    void FixedUpdate()
    {
        CelestialBody[] attractors = FindObjectsOfType<CelestialBody>();
        foreach (CelestialBody attractor in attractors)
        {
            if (attractor != this)
                Attract(attractor);
        }
    }

    void Attract(CelestialBody objToAttract)
    {
        Rigidbody2D rbToAttract = objToAttract.rb;

        Vector3 direction = rb.position - rbToAttract.position; //vector towards objToAttract
        float distance = direction.magnitude;

        float forceMagnitude = (rb.mass * rbToAttract.mass) / Mathf.Pow(distance, 2);

        Vector3 force = direction.normalized * forceMagnitude;

        rbToAttract.AddForce(force);
    }
}
