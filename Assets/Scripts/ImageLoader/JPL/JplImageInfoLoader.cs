using System;
using System.Collections;
using UnityEngine;
using System.Collections.Generic;


public class JplImageInfoLoader
{
	public List<ImageData> ImageInfo {
		get { return imageDataList; }
	}

	public String Error {
		get { return error; }
	}

	private const string JSON_BASE_URL = "http://www.jpl.nasa.gov/assets/json/getMore.php?images=true&search=anaglyph&page=";
	private const string IMAGE_BASE_URL = "http://www.jpl.nasa.gov/";

	private string error = null;
	private List<ImageData> imageDataList;
	private int currentPage = 0;

	public IEnumerator LoadNextImageInfo ()
	{
		// load from json api
		string pageUrl = JSON_BASE_URL + currentPage;
		Debug.Log ("[JplImageInfoLoader] LoadNextImageInfo: " + pageUrl);
		WWW www = new WWW (pageUrl);
		yield return www;

		if (www.error == null) {
			// parse to list
			Root jsonRoot = JsonUtility.FromJson<Root> (www.text);

			imageDataList = new List<ImageData> ();
			foreach (Item item in jsonRoot.items) {
				imageDataList.Add (ConstructImageData (item));
			}

			// start all over again if we reached the end of pages
			if (jsonRoot.more) {
				currentPage++;
			} else {
				currentPage = 0;
			}

			error = null;
		} else {
			error = www.error;
		}
	}

	ImageData ConstructImageData (Item item)
	{
		string url = IMAGE_BASE_URL + item.images.thumb.src.Replace ("640x350", "1280x1024");
		ImageData imageData = new ImageData (url);
		imageData.Title = item.title;
		imageData.Description = item.tease;
		imageData.Credit = item.credit;
		imageData.Category = item.category;
		imageData.Date = item.date;
		imageData.Mission = item.mission;
		imageData.MissionLink = item.mission_link;
		imageData.Views = item.views;
		return imageData;
	}
}
