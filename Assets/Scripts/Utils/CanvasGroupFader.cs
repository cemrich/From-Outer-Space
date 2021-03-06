﻿using UnityEngine;
using System.Collections;

[RequireComponent (typeof(CanvasGroup))]
public class CanvasGroupFader : MonoBehaviour
{
	[Tooltip ("Time in seconds to fade in/out the loader.")]
	public float fadeSpeed = 1f;

	private CanvasGroup canvasGroup;
	private IEnumerator currentFade;
	private bool isShowing = false;

	public void Show ()
	{
		if (isShowing) {
			return;
		}

		Debug.Log ("[CanvasGroupFader] Show " + name);
		isShowing = true;
		StopCurrentFade ();
		currentFade = Fade (1, fadeSpeed);
		StartCoroutine (currentFade);
	}

	public void Hide ()
	{
		if (!isShowing) {
			return;
		}

		Debug.Log ("[CanvasGroupFader] Hide " + name);
		isShowing = false;
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
