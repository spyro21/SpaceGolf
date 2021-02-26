using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    GameObject[] celestialBodies;
    Transform target;

	void Start () {
        celestialBodies = GameObject.FindGameObjectsWithTag("Planet");
        foreach(GameObject body in celestialBodies) {
            if (body.GetComponent<CelestialBody>().isMainBody) {
                target = body.GetComponent<Transform>();
            }
        }

        if (target == null) {
            target = celestialBodies[0].GetComponent<Transform>();
        }
	}
	
	void Update () {
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
	}
}
