using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallArranger : MonoBehaviour {

	public Transform left;
	public Transform right;
	public Transform top;
	public Transform bottom;

	// Use this for initialization
	void Start () {
		Camera camera = GetComponent<Camera>();
		left.position = camera.ViewportToWorldPoint(new Vector3(0, 0.5f, camera.nearClipPlane));
		right.position = camera.ViewportToWorldPoint(new Vector3(1, 0.5f, camera.nearClipPlane));
		bottom.position = camera.ViewportToWorldPoint(new Vector3(0.5f, 0, camera.nearClipPlane));
		top.position = camera.ViewportToWorldPoint(new Vector3(0.5f, 1, camera.nearClipPlane));
	}
}
