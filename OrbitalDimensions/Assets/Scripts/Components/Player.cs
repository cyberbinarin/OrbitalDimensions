using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	private EnvironmentCollider standingOn;

	private GravityBody gravityBody;

	public void Awake() {
		gravityBody = GetComponent<GravityBody>();
	}

	public EnvironmentCollider StandingOn {
		get {return standingOn;}
		set {
			if (value != standingOn) {
				rigidbody.isKinematic = value == null;
				if (gravityBody != null) {
					gravityBody.enabled = value == null;
				}
				standingOn = value;
			}
		}
	}
}
