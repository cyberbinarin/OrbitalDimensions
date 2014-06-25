using UnityEngine;
using System.Collections;

public abstract class EnvironmentCollider : MonoBehaviour {

	public virtual Vector2 globalPositionToSurfacePoint(Vector3 globalPosition) {
		return localPositionToSurfacePoint(transform.InverseTransformPoint(globalPosition));
	}

	public virtual Vector3 surfacePointToGlobalPosition(Vector2 surfacePoint) {
		return transform.TransformPoint(surfacePointToLocalPosition(surfacePoint));
	}

	public virtual Vector3 surfacePointToGlobalNormal(Vector2 surfacePoint) {
		return transform.TransformDirection(surfacePointToLocalNormal(surfacePoint));
	}


	public abstract Vector2 localPositionToSurfacePoint(Vector3 localPosition);

	public abstract Vector3 surfacePointToLocalPosition(Vector2 surfacePoint);

	public abstract Vector3 surfacePointToLocalNormal(Vector2 surfacePoint);
}
