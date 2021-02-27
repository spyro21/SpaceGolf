using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour {

    public LineRenderer lr;
    public int lineLength;
    private Transform planetTransform;

    List<Vector3> planetPositions = new List<Vector3>();

    void Start () {
        lr = gameObject.GetComponent<LineRenderer>();
        planetTransform = transform.parent.gameObject.GetComponent<Transform>();
        Color lineColor = transform.parent.gameObject.GetComponent<SpriteRenderer>().color;
        lr.startColor = lineColor;
        lr.endColor = lineColor;
    }
	
	void Update () {
        planetPositions.Add(planetTransform.position);

        lr.positionCount = planetPositions.Count;
        int count = 0;
        foreach (Vector3 currPosition in planetPositions) {
            lr.SetPosition(count, currPosition);
            count++;
        }

        if (planetPositions.Count >= lineLength) {
            planetPositions.RemoveAt(0);
        }
	}

}
