using UnityEngine;

[System.Serializable]
public class ImageData
{
	public string Title { get; set; }

	public string Description { get; set; }

	public string Category { get; set; }

	public string Date { get; set; }

	public string Mission { get; set; }

	public string MissionLink { get; set; }

	public string Credit { get; set; }

	public int Views { get; set; }

	public string Url { get; set; }

	public Texture2D Texture { get; set; }


	public ImageData (string url)
	{
		this.Url = url;
	}

	public void Recycle ()
	{
		if (Texture != null) {
			Object.Destroy (Texture);
		}
	}
}

