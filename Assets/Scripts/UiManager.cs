using UnityEngine;
using UnityEngine.UI;

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
	private Text infoText;

	public void ChangeImageData (ImageData imageData)
	{
		imageMaterialLeft.mainTexture = imageData.Texture;
		imageMaterialRight.mainTexture = imageData.Texture;
		headlineText.text = imageData.Title;
		descriptionText.text = imageData.Description;
		infoText.text = imageData.Credit;
	}
}
