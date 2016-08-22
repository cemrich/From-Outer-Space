using System.Collections;
using UnityEngine;

public class JplImageLoader : AbstractImageLoader
{
	private JplImageInfoLoader infoLoader = new JplImageInfoLoader ();
	private int currentImageInfo = 0;

	override public void LoadNextImage ()
	{
		CancelLoading ();
		StartCoroutine (DownloadNextImage ());
	}

	override public void CancelLoading ()
	{
		StopAllCoroutines ();
	}

	IEnumerator DownloadNextImage ()
	{
		if (infoLoader.ImageInfo == null || currentImageInfo >= infoLoader.ImageInfo.Count) {
			// we need to fetch a new image info list
			// bacause we have consumed the old (or never had one)
			yield return infoLoader.LoadNextImageInfo ();
			currentImageInfo = 0;
		}

		if (infoLoader.Error == null) {
			ImageData nextImage = infoLoader.ImageInfo [currentImageInfo];
			currentImageInfo++;
			yield return DownloadAsTexture (nextImage);
		} else {
			if (onImageLoadingError != null) {
				onImageLoadingError (infoLoader.Error);
			}
		}
	}

	IEnumerator DownloadAsTexture (ImageData imageData)
	{
		Debug.Log ("[JplImageLoader] download next image: " + imageData.Url);

		WWW www = new WWW (imageData.Url);
		yield return www;

		if (www.error == null) {
			imageData.Texture = www.texture;

			if (onImageLoadingComplete != null) {
				onImageLoadingComplete (imageData);
			}
		} else {
			if (onImageLoadingError != null) {
				onImageLoadingError (www.error);
			}
		}
	}
}
