using UnityEngine;
using System.Collections;

public class RealisticGravityPoint : GravityPoint {
	public float mass = 1f;

	public override Vector3 getForce(Vector3 globalPosition) {
		Vector3 diff = transform.position - globalPosition;
		if (diff.Equals(Vector3.zero)) {
			return Vector3.zero;
		} else {
			return diff.normalized * (mass / Mathf.Pow(diff.magnitude, 2f));
		}
	}
}
