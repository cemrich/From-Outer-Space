﻿using UnityEngine;
using UnityEngine.UI;
using System;

public class UiManager : MonoBehaviour
{
	[SerializeField]
	private Loader loader;

	[SerializeField]
	private MeshRenderer imageMaterialLeft;

	[SerializeField]
	private MeshRenderer imageMaterialRight;

	[SerializeField]
	private Text headlineText;

	[SerializeField]
	private Text descriptionText;

	[SerializeField]
	private Text infoHeadline;

	[SerializeField]
	private Text infoText;

	public void SetLoading ()
	{
		loader.Show ();
	}

	public void ChangeImageData (ImageData imageData)
	{
		SetTexture (imageData);
		SetDescriptionText (imageData);
		SetInfoText (imageData);

		loader.Hide ();
	}

	void SetTexture (ImageData imageData)
	{
		imageMaterialLeft.material.mainTexture = imageData.Texture;
		imageMaterialRight.material.mainTexture = imageData.Texture;
	}

	void SetDescriptionText (ImageData imageData)
	{
		headlineText.text = imageData.Title;
		descriptionText.text = imageData.Description;
	}

	void SetInfoText (ImageData imageData)
	{
		infoHeadline.text = "Info";
		infoText.text = "";
		SetInfoTextLine ("Date", imageData.Date);
		SetInfoTextLine ("Category", imageData.Category);
		SetInfoTextLine ("Mission", imageData.Mission);
		SetInfoTextLine ("Views", imageData.Views.ToString ());
		SetInfoTextLine ("Credit", imageData.Credit);
	}

	void SetInfoTextLine (string label, string content)
	{
		infoText.text += String.Format ("<b>{0}:</b> {1}\n", label, content);
	}
}
