using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Camerascript : MonoBehaviour
{
    public int Width;
    public int Height;
    public int FPS = 30;
    public int CamDeviceNo = 0;
    public float Alpha = 0.5f;

    void Start()
    {
        RawImage rawimage;
        rawimage = this.GetComponents<RawImage>()[0];

        WebCamDevice[] devices = WebCamTexture.devices;

        for (var i = 0; i < devices.Length; i++)
        {
            Debug.Log(i.ToString() + ": " + devices[i].name);
        }
        WebCamTexture webcamTexture = new WebCamTexture(devices[CamDeviceNo].name, Width, Height, FPS);

        rawimage.texture = webcamTexture;
        rawimage.material.mainTexture = webcamTexture;
        rawimage.color = new Color(rawimage.color.r, rawimage.color.g, rawimage.color.b, Alpha);

        webcamTexture.Play();
    }
}
