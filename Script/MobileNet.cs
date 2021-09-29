using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.Barracuda;

public class MobileNet: MonoBehaviour
{
    readonly IWorker worker;

  //  private int inputShapeX = 960;
 //   private int inputShapeY = 720;

    private int inputShapeX = 224;
    private int inputShapeY = 224;



    public MobileNet(NNModel modelAsset)
    {
        var model = ModelLoader.Load(modelAsset);

#if UNITY_WEBGL || UNITY_EDITOR
        Debug.Log("Worker:CPU");
        worker = WorkerFactory.CreateWorker(WorkerFactory.Type.CSharpBurst, model); // CPU
#else
        Debug.Log("Worker:GPU");
        worker = WorkerFactory.CreateWorker(WorkerFactory.Type.ComputePrecompiled, model); // GPU
#endif
    }

#if UNITY_WEBGL || UNITY_EDITOR
    public float[] Inference(Texture2D texture)
    {
        // テクスチャコピー
        Texture2D inputTexture = new Texture2D(texture.width, texture.height);
        var tempColor32 = texture.GetPixels32();
        inputTexture.SetPixels32(tempColor32);
        inputTexture.Apply();
        Graphics.CopyTexture(texture, inputTexture);

        // テクスチャリサイズ、およびColor32データ取得
        TextureScale.Bilinear(inputTexture, inputShapeX, inputShapeY);
        var color32 = inputTexture.GetPixels32();
        MonoBehaviour.Destroy(inputTexture);
        
        float[] floatValues = new float[inputShapeX * inputShapeY * 3];
        for (int i = 0; i < color32.Length; ++i) {
            var color = color32[i];
            floatValues[i * 3 + 0] = (color.r - 0) / 255.0f;
            floatValues[i * 3 + 1] = (color.g - 0) / 255.0f;
            floatValues[i * 3 + 2] = (color.b - 0) / 255.0f;
        }

        var inputTensor = new Tensor(1, inputShapeY, inputShapeX, 3, floatValues);

        worker.Execute(inputTensor);
        var outputTensor = worker.PeekOutput();
        var outputArray = outputTensor.ToReadOnlyArray();
        
        inputTensor.Dispose();
        outputTensor.Dispose();

        return outputArray;
    }
#else
    public float[] Inference(Texture2D texture)
    {
        var inputTensor = new Tensor(texture, 3);

        worker.Execute(inputTensor);
        var outputTensor = worker.PeekOutput();
        var outputArray = outputTensor.ToReadOnlyArray();

        inputTensor.Dispose();
        outputTensor.Dispose();

        return outputArray;
    }
#endif

    ~MobileNet()
    {
        worker?.Dispose();
    }

    public string getClassName(int classId)
    {
        if (classId < 0 || className.Length <= classId)
        {
            return "";
        }
        return className[classId];
    }
      public string getClassName2(int classId)
    {
        if (classId < 0 || className.Length <= classId)
        {
            return "";
        }
        return className2[classId];
    }
     public string getClassName3(int classId)
    {
        if (classId < 0 || className.Length <= classId)
        {
            return "";
        }
        return className3[classId];
    }

 
    string[] className = {

"hane",
"Redcup",
"AEDmark",
"Bellmark2",
"Maternitymark",
"Toiletmark",
"GreenEnergymark",
"Kuruminmark",
"JISmark",
"Helpmark",
"Evacuationsitemark",
"Recyclesymbol2",
"ecomark2",
"Ecolabelofthesea",
"FSCmark",
"Orangeribbon",
"SDGsmark",
"none",
"none2",
"Recyclesymbol2",
"Recyclesymbol2",
"Recyclesymbol2",
"Recyclesymbol2",
"Recyclesymbol2",
"Recyclesymbol2",
"Recyclesymbol2",
"none4",
"none3",
"Evacuationsitemark",
"FSCmark",
"ecomark2",
"none5" ,
"greenmark2"
    };
     string[] className2 = {
   
"yunisehu2",
"rosunon",
"foodforspecifiedhealthusesmark2",
"MUDmark",
"rainbowflag",
"drinkingwatermark",
"biomassmark",
"mitou",
"Gmark",
"wheelchairmark",
"schoolroutemark",
"JASmark",
"coolbizmark",
"greenplasticmark",
"greenmark",
"peacemark",
"olympicmark",
"none",
"none2",
"none3",
"coolbizmark",
"coolbizmark",
"olympicmark",
"JASmark",
"JASmark",
"JASmark",
"none4",
"greenmark",
"foodforspecifiedhealthusesmark2",
"none5"
     };
     string[] className3 = {
 "Bellmark",
 "Recyclesymbol",
 "ecomark",
 "none",
 "none2",
 "Recyclesymbol",
 "Recyclesymbol",
 "Recyclesymbol",
 "Recyclesymbol",
 "Recyclesymbol",
 "Recyclesymbol",
 "Recyclesymbol",
 "none4",
 "none3",
 "ecomark",
 "none5",
 "yunisehu",
 "foodforspecifiedhealthusesmark",
 "greenmark3"
 

     };
}
        

        



        

