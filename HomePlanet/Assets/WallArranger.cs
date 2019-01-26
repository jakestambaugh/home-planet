using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallArranger : MonoBehaviour {

  float wallZ = 0f;

	public Transform left;
	public Transform right;
	public Transform top;
	public Transform bottom;

	// Use this for initialization
	void Start () {
		Camera camera = GetComponent<Camera>();
		left.position = camera.ViewportToWorldPoint(new Vector3(0, 0.5f, wallZ));
		right.position = camera.ViewportToWorldPoint(new Vector3(1, 0.5f, wallZ));
		bottom.position = camera.ViewportToWorldPoint(new Vector3(0.5f, 0, wallZ));
		top.position = camera.ViewportToWorldPoint(new Vector3(0.5f, 1, wallZ));
	}
}
