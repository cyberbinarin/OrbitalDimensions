using UnityEngine;
using System.Collections.Generic;

public abstract class GravityPoint : MonoBehaviour {

	public static LinkedList<GravityPoint> gravityPoints = new LinkedList<GravityPoint>();

	public static Vector3 getForceFromAll(Vector3 globalPosition) {
		return getForceFromAll(globalPosition, Time.deltaTime);
	}

	public static Vector3 getForceFromAll(Vector3 globalPosition, float deltaTime) {
		Vector3 result = Vector3.zero;
		foreach(GravityPoint v in gravityPoints) {
			result += v.getForce(globalPosition, deltaTime);
		}
		return result;
	}

	public void Start() {
		gravityPoints.AddLast(this);
	}

	public void OnDisable() {
		gravityPoints.Remove(this);
	}

	public virtual Vector3 getForce(Vector3 globalPosition, float deltaTime) {
		return getForce(globalPosition) * deltaTime;
	}

	public abstract Vector3 getForce(Vector3 globalPosition);
}
