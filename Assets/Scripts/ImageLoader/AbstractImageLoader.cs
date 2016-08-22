using System;
using System.Collections;
using UnityEngine;

public abstract class AbstractImageLoader : MonoBehaviour
{
	public Action<ImageData> onImageLoadingComplete;
	public Action onRepeatImagesNextTime;
	public Action<string> onImageLoadingError;

	public abstract void LoadNextImage ();

	public abstract void CancelLoading ();
}
