using UnityEngine;
using System.Collections;

[RequireComponent (typeof(UiManager))]
public class ApplicationManager : MonoBehaviour
{
	private UiManager uiManager;
	private AbstractImageLoader imageLoader;

	void Start ()
	{
		uiManager = GetComponent<UiManager> ();
		imageLoader = gameObject.AddComponent<JplImageLoader> ();
		imageLoader.onImageLoadingComplete += HandleImageLoadingComplete;
		imageLoader.onImageLoadingError += HandleImageLoadingError;
		GvrViewer.Instance.OnTrigger += HandleCardboardTrigger;
		GvrViewer.Instance.OnBackButton += HandleCardboardBackButton;

	}

	void Destroy ()
	{
		imageLoader.onImageLoadingComplete -= HandleImageLoadingComplete;
		imageLoader.onImageLoadingError -= HandleImageLoadingError;
		GvrViewer.Instance.OnTrigger -= HandleCardboardTrigger;
		GvrViewer.Instance.OnBackButton -= HandleCardboardBackButton;
	}

	void HandleCardboardTrigger ()
	{
		imageLoader.LoadNextImage ();
	}

	void HandleCardboardBackButton ()
	{
		Application.Quit ();
	}

	void HandleImageLoadingComplete (ImageData imageData)
	{
		Debug.Log ("[ApplicationManager] loading complete: " + imageData.Url);
		uiManager.ChangeImageData (imageData);
	}

	void HandleImageLoadingError (string error)
	{
		Debug.Log ("[ApplicationManager] loading error: " + error);
	}
}
