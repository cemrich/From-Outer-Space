using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour
{
	public Vector3 rotationSpeed = Vector3.back;

	void Update ()
	{
		transform.Rotate (rotationSpeed * Time.deltaTime);
	}
}
