using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class ShareOnSocialMedia : MonoBehaviour
{

	public void Start()
	{
		
	}
	public void Share()
	{
		DateTime dt = DateTime.Now; //get the current date

		StartCoroutine("TakeScreenShotAndShare");
	}

	IEnumerator TakeScreenShotAndShare()
	{
		yield return new WaitForEndOfFrame();

		Texture2D tx = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
		tx.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
		tx.Apply();

		string path = Path.Combine(Application.temporaryCachePath, "sharedImage.png");//image name
		File.WriteAllBytes(path, tx.EncodeToPNG());

		Destroy(tx);
	
		new NativeShare()
			.AddFile(path)
			.Share();

	}
}
