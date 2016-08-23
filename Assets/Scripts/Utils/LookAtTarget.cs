using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
	[SerializeField]
	private Transform target;

	private float distance;

	void Start ()
	{
		distance = Vector3.Distance (target.position, transform.position);
	}

	void Update ()
	{
		// move in front of target
		transform.position = target.position + target.forward * distance;

		// look at target
		transform.LookAt (target.position);
	}
}
