using UnityEngine;
using System.Collections;
using System;

[RequireComponent (typeof(CanvasGroup))]
public class Loader : MonoBehaviour
{
	[Tooltip ("Time in seconds to fade in/out the loader.")]
	public float fadeSpeed = 1f;

	private CanvasGroup canvasGroup;

	public void Show ()
	{
		Debug.Log ("[Loader] Show");
		StopCoroutine ("Fade");
		StartCoroutine (Fade (1, fadeSpeed));
	}

	public void Hide ()
	{
		Debug.Log ("[Loader] Hide");
		StopCoroutine ("Fade");
		StartCoroutine (Fade (0, fadeSpeed));
	}

	void Start ()
	{
		canvasGroup = GetComponent<CanvasGroup> ();
	}

	IEnumerator Fade (float alpha, float speed)
	{
		float speedForAlphaChange = (alpha - canvasGroup.alpha) / speed;

		while (!Mathf.Approximately (canvasGroup.alpha, alpha)) {
			canvasGroup.alpha += (speedForAlphaChange * Time.deltaTime);
			yield return null;
		}
	}
}
