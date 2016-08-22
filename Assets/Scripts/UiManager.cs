using UnityEngine;
using UnityEngine.UI;
using System;

public class UiManager : MonoBehaviour
{
	[SerializeField]
	private Material imageMaterialLeft;

	[SerializeField]
	private Material imageMaterialRight;

	[SerializeField]
	private Text headlineText;

	[SerializeField]
	private Text descriptionText;

	[SerializeField]
	private Text infoHeadline;

	[SerializeField]
	private Text infoText;

	public void ChangeImageData (ImageData imageData)
	{
		SetTexture (imageData);
		SetDescriptionText (imageData);
		SetInfoText (imageData);
	}

	void SetTexture (ImageData imageData)
	{
		imageMaterialLeft.mainTexture = imageData.Texture;
		imageMaterialRight.mainTexture = imageData.Texture;
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
