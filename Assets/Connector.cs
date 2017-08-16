using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connector : MonoBehaviour {

	GameObject square1;
	GameObject square2;
	Vector3[] bezierPoints;
	LineRenderer lineRenderer;
	//public Shader shader;

	// Use this for initialization
	void Start () {
		this.square1 = GameObject.Find ("Square1");	
		this.square2 = GameObject.Find ("Square2");	
		GameObject lineObj = new GameObject("DragLine", typeof(LineRenderer));
		lineRenderer = lineObj.GetComponent<LineRenderer> ();
		lineRenderer.startWidth = 0.1f;
		lineRenderer.endWidth = 0.1f;
		lineRenderer.material.color = Color.blue;
//		lineRenderer.SetWidth(0.1f, 0.1f);

		bezierPoints = new Vector3[4];
	}
	
	// Update is called once per frame
	void Update () {
		DrawNodeCurve (this.square1, this.square2);
	}

	void DrawNodeCurve(GameObject start, GameObject end) {

		Vector3 startPos = new Vector3(start.transform.position.x + start.transform.localScale.x, start.transform.position.y, 0);
		Vector3 endPos = new Vector3(end.transform.position.x - end.transform.localScale.x, end.transform.position.y, 0);
		Vector3 startTan = startPos + Vector3.right * 3;
		Vector3 endTan = endPos + Vector3.left * 3;
		Debug.Log (startPos + " " + endPos + " " + startTan + " " + endTan);

		bezierPoints [0] = startPos;
		bezierPoints [1] = endPos;
		bezierPoints [2] = startTan;
		bezierPoints [3] = endTan;
		lineRenderer.positionCount = 2;
		lineRenderer.SetPositions (bezierPoints);
	
//		Color shadowCol = new Color(0, 0, 0, 0.06f);
//		for (int i = 0; i < 3; i++) // Draw a shadow
//			Handles.DrawBezier(startPos, endPos, startTan, endTan, shadowCol, null, (i + 1) * 5);
//		Handles.DrawBezier(startPos, endPos, startTan, endTan, Color.black, null, 1);
	}
}
