using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	public Vector2 standingPoint;

	private GravityBody gravityBody;
	private PlayerEnvironmentCollider environmentCollider;

	private EnvironmentCollider standingOn;
	public void Awake() {
		gravityBody = GetComponent<GravityBody>();
		environmentCollider = GetComponentInChildren<PlayerEnvironmentCollider>();
	}

	public EnvironmentCollider StandingOn {
		get {return standingOn;}
		set {
			if (value != standingOn) {
				rigidbody.isKinematic = value != null;
				if (gravityBody != null) {
					gravityBody.enabled = value == null;
				}
				standingOn = value;
			}
		}
	}

	public void Update() {
		if (standingOn != null) {
			transform.position = standingOn.surfacePointToGlobalPosition(standingPoint) + standingOn.surfacePointToGlobalNormal(standingPoint) * environmentCollider.radius;

		}
	}
}
