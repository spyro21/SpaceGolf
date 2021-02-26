using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour {

    public GameObject linePrefab;
    public GameObject currentLine;

    public GameObject targetPlanet;

    public LineRenderer lineRenderer;
    public EdgeCollider2D edgeCollider;

    public List<Vector2> planetPositions;

	// Use this for initialization
	void Start () {
        CreateLine();
    }
	
	// Update is called once per frame
	void Update () {
        Vector2 tempPlanetPos = targetPlanet.GetComponent<Transform>().position;
        if (Vector2.Distance(tempPlanetPos, planetPositions[planetPositions.Count - 1]) > 0.1f) {
            UpdateLine(tempPlanetPos);
        }

	}

    void CreateLine() {
        currentLine = Instantiate(linePrefab, Vector3.zero, Quaternion.identity);
        lineRenderer = currentLine.GetComponent<LineRenderer>();
        edgeCollider = currentLine.GetComponent<EdgeCollider2D>();
        planetPositions.Clear();
        planetPositions.Add(targetPlanet.GetComponent<Transform>().position);
        planetPositions.Add(targetPlanet.GetComponent<Transform>().position);
        lineRenderer.SetPosition(0, planetPositions[0]);
        lineRenderer.SetPosition(1, planetPositions[1]);
        edgeCollider.points = planetPositions.ToArray();
    }

    void UpdateLine(Vector2 newPlanetPos) {
        planetPositions.Add(newPlanetPos);
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, newPlanetPos);
        edgeCollider.points = planetPositions.ToArray();
    }
}
