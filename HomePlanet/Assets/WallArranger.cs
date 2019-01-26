using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallArranger : MonoBehaviour {

  public Transform backPlane;

	public Transform left;
	public Transform right;
	public Transform top;
	public Transform bottom;

	// Use this for initialization
  private new Camera camera;
  void Start () {
    camera = GetComponent<Camera>();
  }
	void Update () {
		left.position = camera.ViewportToWorldPoint(new Vector3(0, 0.5f, backPlane.position.z - transform.position.z));
		right.position = camera.ViewportToWorldPoint(new Vector3(1, 0.5f, backPlane.position.z - transform.position.z));
		bottom.position = camera.ViewportToWorldPoint(new Vector3(0.5f, 0, backPlane.position.z - transform.position.z));
		top.position = camera.ViewportToWorldPoint(new Vector3(0.5f, 1, backPlane.position.z - transform.position.z));
	}
}
