using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneCamera : MonoBehaviour {

    public WebCamTexture webCamCamera = null;

    public RawImage image;


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
        
        webCamCamera = new WebCamTexture(Screen.width, Screen.height);

        image.texture = webCamCamera;
        

        webCamCamera.Play();

        Camera cam = Camera.main;
        float height = 2f * cam.orthographicSize;
        float width = height * cam.aspect;
        Debug.Log(Screen.width + " " + Screen.height);
    }
    

    public void TakeScreenshot()
    {
        RenderTexture renderTexture = new RenderTexture(Screen.width, Screen.height, 24);
        Camera.main.targetTexture = renderTexture;
        Camera.main.Render();
        Camera.main.targetTexture = null;

        Texture2D screenshot = new Texture2D(Screen.width, Screen.height);
        //screenshot.SetPixels(webCamCamera.GetPixels());
        //screenshot.Apply();

        screenshot.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        screenshot.Apply();
        System.IO.File.WriteAllBytes(Application.persistentDataPath + "/Snapshots/test.png", screenshot.EncodeToPNG());
        
    }
}
