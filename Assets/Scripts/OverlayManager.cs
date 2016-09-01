using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(CanvasGroupFader))]
public class OverlayManager : MonoBehaviour
{
	[SerializeField]
	private Image busyLoader;

	[SerializeField]
	private Image progressLoader;

	[SerializeField]
	private Text headline;

	[SerializeField]
	private Text text;

	private CanvasGroupFader fader;

	public void SetupAsErrorOverlay ()
	{
		busyLoader.enabled = false;
		progressLoader.enabled = false;
		headline.enabled = true;
		text.enabled = true;
	}

	public void SetupAsLoaderOverlay ()
	{
		busyLoader.enabled = true;
		progressLoader.fillAmount = 0;
		progressLoader.enabled = true;
		headline.enabled = false;
		text.enabled = false;
	}

	public void SetProgress (float percent)
	{
		progressLoader.fillAmount = percent;
	}

	public void SetText (string headline, string text)
	{
		this.headline.text = headline;
		this.text.text = text;
	}

	public void Show ()
	{
		fader.Show ();
	}

	public void Hide ()
	{
		fader.Hide ();
	}

	void Start ()
	{
		fader = GetComponent<CanvasGroupFader> ();
	}
}
