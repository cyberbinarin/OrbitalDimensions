using UnityEngine;
using System;

public class SphereEnvironment : EnvironmentCollider {
	public float radius = 1;


	public override Vector2 localPositionToSurfacePoint(Vector3 localPosition) {
		return new Vector2(Mathf.Acos(localPosition.z / localPosition.magnitude), Mathf.Atan(localPosition.y / localPosition.x));
	}

	public override Vector3 surfacePointToLocalPosition(Vector2 surfacePoint) {
		return new Vector3(Mathf.Sin(surfacePoint.x) * Mathf.Cos(surfacePoint.y), Mathf.Sin(surfacePoint.x) * Mathf.Sin(surfacePoint.y), Mathf.Cos(surfacePoint.x)) * radius;
	}

	public override Vector3 surfacePointToLocalNormal(Vector2 surfacePoint) {
		return new Vector3(Mathf.Sin(surfacePoint.x) * Mathf.Cos(surfacePoint.y), Mathf.Sin(surfacePoint.x) * Mathf.Sin(surfacePoint.y), Mathf.Cos(surfacePoint.x));
	}
}
