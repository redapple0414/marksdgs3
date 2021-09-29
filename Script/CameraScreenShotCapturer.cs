using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
#if UNITY_WEBGL && !UNITY_EDITOR
using System.Runtime.InteropServices;
#endif
/// <summary>
/// 指定されたカメラの内容をキャプチャするサンプル
/// </summary>
public class CameraScreenShotCapturer : MonoBehaviour
{
    [SerializeField] private Camera _camera;


    // カメラのスクリーンショットを保存する
    public void CaptureScreenShot(string filePath)
    {



        var rt = new RenderTexture(_camera.pixelWidth, _camera.pixelHeight, 24);
        var prev = _camera.targetTexture;
        _camera.targetTexture = rt;
        _camera.Render();
        _camera.targetTexture = prev;
        RenderTexture.active = rt;

        var screenShot = new Texture2D(
            _camera.pixelWidth,
            _camera.pixelHeight,
            TextureFormat.RGB24,
            false);
        screenShot.ReadPixels(new Rect(0, 0, screenShot.width, screenShot.height), 0, 0);
        screenShot.Apply();

        var bytes = screenShot.EncodeToPNG();
        Destroy(screenShot);

#if UNITY_WEBGL && !UNITY_EDITOR

        File.WriteAllBytes(filePath, bytes);
#else 
        File.WriteAllBytes(filePath, bytes);
#endif
    }
    public static Texture2D LoadJPGorPNG(string filePath)
    {

        Texture2D tex = null;
        byte[] fileData;

        if (File.Exists(filePath))
        {
            Debug.Log(filePath);
            fileData = File.ReadAllBytes(filePath);
            tex = new Texture2D(2, 2);
            tex.LoadImage(fileData);  // 配列からテクスチャへ変換し PNG/JPG 画像を読み込みます
        }
        return tex;
    }
}