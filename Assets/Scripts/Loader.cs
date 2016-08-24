using UnityEngine;
using System.Collections;
using System;

[RequireComponent (typeof(CanvasGroup))]
public class Loader : MonoBehaviour
{
	[Tooltip ("Time in seconds to fade in/out the loader.")]
	public float fadeSpeed = 1f;

	private CanvasGroup canvasGroup;
	private IEnumerator currentFade;

	public void Show ()
	{
		Debug.Log ("[Loader] Show");
		StopCurrentFade ();
		currentFade = Fade (1, fadeSpeed);
		StartCoroutine (currentFade);
	}

	public void Hide ()
	{
		Debug.Log ("[Loader] Hide");
		StopCurrentFade ();
		currentFade = Fade (0, fadeSpeed);
		StartCoroutine (currentFade);
	}

	void Start ()
	{
		canvasGroup = GetComponent<CanvasGroup> ();
	}

	void StopCurrentFade ()
	{
		if (currentFade != null) {
			StopCoroutine (currentFade);
		}
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
