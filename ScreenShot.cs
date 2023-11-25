using System.Collections;
using System.IO;
using UnityEngine;

public class ScreenShot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator Screenshot()
    {
        yield return new WaitForEndOfFrame();
        Texture2D texture = new Texture2D(Screen.width / 2, Screen.height, TextureFormat.RGB24, false);

        texture.ReadPixels(new Rect(Screen.width / 4, 0, Screen.width / 2, Screen.height), 0, 0);
        texture.Apply();

        string name = "Screenshot" + System.DateTime.Now.ToString("dd-MM-yyyyy-HH-mm-ss") + ".png";

        NativeGallery.SaveImageToGallery(texture, "pictures", name);

        Destroy(texture);
    }

    public void TakeScreenshot()
    {
        StartCoroutine("Screenshot");
    }
}
