using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneCamera : MonoBehaviour {

    public WebCamTexture mCamera = null;

    public RawImage image;
    public AspectRatioFitter fit;


    // Use this for initialization
    void Start()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            image.transform.rotation = Quaternion.Euler(0, 0, 90);
            image.transform.localScale = new Vector3(-1,-1,-1);
        }
        else if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            image.transform.rotation = Quaternion.Euler(0, 0, 0);
            image.transform.localScale = new Vector3(-1, 1, 1);
        }

        Debug.Log("Script has been started");
        
        mCamera = new WebCamTexture(Screen.width, Screen.height);

        image.texture = mCamera;
        

        mCamera.Play();
    }
    

    public void Screenshoz()
    {
        /*Texture2D screenshot = new Texture2D(mCamera.width, mCamera.height);
        screenshot.SetPixels(mCamera.GetPixels());
        screenshot.Apply();
        System.IO.File.WriteAllBytes("Path", screenshot.EncodeToPNG());*/
    }
}
