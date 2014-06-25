using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class GravityBody : MonoBehaviour {

	private Rigidbody rigid;

	public void FixedUpdate() {
		if (rigid == null) {
			rigid = rigidbody;
		}
		rigid.AddForce(GravityPoint.getForceFromAll(transform.position), ForceMode.Acceleration);
	}
}
