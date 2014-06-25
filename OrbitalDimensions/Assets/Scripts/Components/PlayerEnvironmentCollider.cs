using UnityEngine;
using System.Collections;

public class PlayerEnvironmentCollider : MonoBehaviour {
	public float radius = 1;

	private Player player;

	public void Awake() {
		player = GetComponentInParent<Player>();
	}

	public void OnTriggerEnter(Collider other) {
		EnvironmentCollider environment = other.GetComponent<EnvironmentCollider>();
		if (environment != null) {
			Vector2 surfacePoint = environment.globalPositionToSurfacePoint(transform.position);
			Vector3 surfacePosition = environment.surfacePointToGlobalPosition(surfacePoint);
			Vector3 surfaceNormal;
			if (Vector3.Distance(transform.position, surfacePosition) < radius && canStandAt(surfacePosition, surfaceNormal = environment.surfacePointToGlobalNormal(surfacePoint))) {
				player.StandingOn = environment;
			}
		}
	}

	public bool canStandAt(Vector3 globalSurfacePosition, Vector3 globalSurfaceNormal) {
		return canStandOn(globalSurfaceNormal, GravityPoint.getForceFromAll(globalSurfacePosition, 1f));
	}

	public bool canStandOn(Vector3 globalSurfaceNormal, Vector3 gravityForce) {
		return Vector3.Dot(gravityForce, globalSurfaceNormal) < 0;
	}
}
