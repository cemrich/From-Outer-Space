using System;
using UnityEngine;

namespace ImageLoader
{
	public abstract class AbstractImageLoader : MonoBehaviour
	{
		public Action<ImageData> onImageLoadingComplete;
		public Action onRepeatImagesNextTime;
		public Action<string> onImageLoadingError;

		public abstract void LoadNextImage ();

		public abstract void CancelLoading ();
	}
}
