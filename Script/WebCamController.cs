using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Unity.Barracuda;
using UnityEngine.SceneManagement;
using System.Text;
using System;

public class WebCamController : MonoBehaviour
{
  
    public static string enc;
    GameObject hukidasi;

    GameObject Explanationimage;
    GameObject Getmarkimage;

    GameObject earthbutton;

    int width = 224;
    int height = 224;
    int fps = 30;
    int getok = 0;
    public string markName = "bellmark";
   
    System.DateTime now = System.DateTime.Now;
    static WebCamTexture webcamTexture;
    //   static WebCamTexture liveFeed;

    public RawImage feed;

    // MobileNetモデル関連
    public NNModel modelAsset;
    public NNModel modelAsset2;
    public NNModel modelAsset3;
    private MobileNet mobileNet;
    // private MobileNet mobileNet2;
    // private MobileNet mobileNet3;
    

    Texture2D texture1;
    Texture2D texture2;
    Color32[] color32;
  public GameObject maxScoretext;
  public GameObject maxScoremarktext;


    // 推論結果描画用テキスト
    public Text text;
    public Sprite haneimage;
    public Sprite Redcupimage;
    public Sprite AEDmarkimage;
    public Sprite Bellmarkimage;
    public Sprite Maternitymarkimage;
    public Sprite Toiletmarkimage;
    public Sprite GreenEnergymark;
    public Sprite Kuruminmarkimage;
    public Sprite JISmarkimage;
    public Sprite Helpmarkimage;
    public Sprite Evacuationsitemarkimage;
    public Sprite Recyclesymbolimage;
    public Sprite ecomarkimage;
    public Sprite Ecolabeloftheseaimage;
    public Sprite FSCmarkimage;
    public Sprite Orangeribbonimage;
    public Sprite SDGsmarkimage;
 

    public Sprite yunisehuimage;
    public Sprite rosunonimage;
    public Sprite foodforspecifiedhealthusesmarkimage;
    public Sprite MUDmarkimage;
    public Sprite rainbowflagimage;
    public Sprite drinkingwatermarkimage;
    public Sprite biomassmarkimage;
    public Sprite mitouimage;
    public Sprite Gmarkimage;
    public Sprite wheelchairmark;
    public Sprite schoolroutemarkimage;
    public Sprite JASmarkimage;
    public Sprite coolbizmarkimage;
    public Sprite greenplasticmarkimage;
    public Sprite greenmarkimage;
    public Sprite peacemarkimage;
    public Sprite olympicmarkimage;

    public Sprite Noon;
    string sp;
    

    [Multiline]
    public string speakhane;
    [Multiline]
    public string speakRedcup;
    [Multiline]
    public string speakAEDmark;
    [Multiline]
    public string speakBellmark;
    [Multiline]
    public string speakMaternitymark;
    [Multiline]
    public string speakToiletmark;
    [Multiline]
    public string speakGreenEnergymark;
    [Multiline]
    public string speakKuruminmark;
    [Multiline]
    public string speakJISmark;
    [Multiline]
    public string speakHelpmark;
    [Multiline]
    public string speakEvacuationsitemark;
    [Multiline]
    public string speakRecyclesymbol;
    [Multiline]
    public string speakecomark;
    [Multiline]
    public string speakEcolabelofthesea;
    [Multiline]
    public string speakFSCmark;
    [Multiline]
    public string speakOrangeribbon;
    [Multiline]
    public string speakSDGsmark;

    private AudioSource audioSource;
    public AudioClip GetAudio;
    string resultText = "";
    //  private readonly FPSCounter fpsCounter = new FPSCounter();

    public void Start()
    {
    
        //   Text score_text = maxScoretext.GetComponent<Text> ();
        //    Text score_text2 = maxScoremarktext.GetComponent<Text> ();


        
        earthbutton = GameObject.Find("SceneButton");
        earthbutton.GetComponent<SceneButton>().pushreturn2();

 
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = GetAudio;

      markName = Chatterscript.selectmarkname;

  
      {
        if(markName == "hane" || markName == "Redcup" || markName == "AEDmark" || markName == "Maternitymark" || markName == "Toiletmark" || markName == "GreenEnergymark" || markName == "Kuruminmark" || markName == "JISmark" || markName == "Helpmark" || markName == "Evacuationsitemark" || markName == "Ecolabelofthesea" || markName == "FSCmark" || markName == "Orangeribbon" || markName == "SDGsmark")
        {
            mobileNet = new MobileNet(modelAsset);
        }
        else if(markName == "yunisehu" ||markName == "Bellmark" ||markName == "foodforspecifiedhealthusesmark" ||markName == "ecomark" ||markName == "Recyclesymbol")
        {
            mobileNet = new MobileNet(modelAsset3);
        }
       else
        {
            mobileNet = new MobileNet(modelAsset2);
        }

      }


        // mobileNet = new MobileNet(modelAsset);
        // mobileNet2 = new MobileNet(modelAsset2);
        // mobileNet3 = new MobileNet(modelAsset3);
  
        this.Explanationimage = GameObject.Find("Explanation");

        this.Explanationimage.GetComponent<Image>().sprite = null;

        this.Getmarkimage = GameObject.Find("Getmark");

        this.Getmarkimage.GetComponent<Image>().sprite = null;


        //   Webカメラ準備
        WebCamDevice[] devices = WebCamTexture.devices;
        webcamTexture = new WebCamTexture(devices[setteiscene.uraomote].name, this.width, this.height, this.fps);

        this.feed = GetComponent<RawImage>();
        this.feed.texture = webcamTexture;
        //feed.texture.Compress(false);
        //    feed.texture = webcamTexture;
      //  GetComponent<RawImage>().material.mainTexture = webcamTexture;
        webcamTexture.Play();
        getok = 0;



        StartCoroutine(WebCamTextureInitialize());  

        // MobileNetV2推論用クラス


        markName = Chatterscript.selectmarkname;
      Debug.Log(markName);
        //      Debug.Log(WebCamTexture.devices[0].name);

        //   if (webcamTexture.isPlaying == false) webcamTexture.Play();
        //         DontDestroyOnLoad(gameObject);

        DontDestroyOnLoad(gameObject);

    }

    IEnumerator WebCamTextureInitialize()
    {

        //     yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);

        //     if (Application.HasUserAuthorization(UserAuthorization.WebCam))
        //    {
        //        if (!webcamTexture)
        //            webcamTexture = new WebCamTexture();
        //        webcamTexture.Play();

        //       feed.texture = new Texture2D(webcamTexture.width, webcamTexture.height, TextureFormat.RGBA32, false);
        //      GetComponent<RawImage>().material.mainTexture = feed.texture;
        //   }
        //   else
        //      Debug.LogWarning("Camera access not obtained!");
        //  }


        while (true)
        {
            if (webcamTexture.width > 16 && webcamTexture.height > 16)
            {

                color32 = new Color32[webcamTexture.width * webcamTexture.height];
              //  texture1 = new Texture2D(webcamTexture.width, webcamTexture.height,TextureFormat.DXT5Crunched,false);
                 texture1 = new Texture2D(webcamTexture.width, webcamTexture.height);
                GetComponent<RawImage>().material.mainTexture = texture1;


                //               GetComponent<RawImage>().material.mainTexture = texture;



                break;
            }

          //  yield return null;
              yield return Resources.UnloadUnusedAssets();
        }

        
    }





    void Update()
    {
        if(gettext.textonoff == 0)
        {
            resultText = "";
        }
         this.Getmarkimage = GameObject.Find("Getmark");
         markName = Chatterscript.selectmarkname;
           Debug.Log(markName);
   if(earthbutton.GetComponent<SceneButton>().pushreturn() == 1)
   {
      earthbutton.GetComponent<SceneButton>().pushreturn2();
      webcamTexture.Stop();
      Destroy(texture1);
      Destroy(texture2);  
   }

    //  score_text.text = resultText2.ToString();
    //   score_text2.text = resultText.ToString();


        text.text =  resultText;
    

        markName = Chatterscript.selectmarkname;
      
        if (webcamTexture.width <= 16 || webcamTexture.height <= 16)
        {
            return;

        }


        //     fpsCounter.Update();

        // 入力用テクスチャ準備

        //       webcamTexture = new WebCamTexture(devices[0].name, this.width, this.height, this.fps);
        webcamTexture.GetPixels32(color32);
        texture1.SetPixels32(color32);
        texture1.Apply();




       // Destroy(texture);


        //       webcamTexture.GetPixels32(color32);
        //      (feed.texture as Texture2D).SetPixels32(color32);
        //      (feed.texture as Texture2D).Apply();

        // 推論
        float[] scores;

 
            scores = mobileNet.Inference(texture1);
    //     }
    //     else if(markName == "yunisehu" ||markName == "Bellmark" ||markName == "foodforspecifiedhealthusesmark" ||markName == "ecomark")
    //     {
    //         scores = mobileNet3.Inference(texture1);
    //     }
    //    else
    //     {
    //         scores = mobileNet2.Inference(texture1);
    //     }


        // 推論結果
        var maxScore = float.MinValue;
        int classId = -1;
        for (int i = 0; i < scores.Length; i++)
        {
            float score = scores[i];
            if (maxScore < score)
            {
                maxScore = score;
                classId = i;
            }
        }

               if(markName == "hane" || markName == "Redcup" || markName == "AEDmark" || markName == "Maternitymark" || markName == "Toiletmark" || markName == "GreenEnergymark" || markName == "Kuruminmark" || markName == "JISmark" || markName == "Helpmark" || markName == "Evacuationsitemark" || markName == "Ecolabelofthesea" || markName == "FSCmark" || markName == "Orangeribbon" || markName == "SDGsmark")
        {
                 //      Debug.Log(mobileNet.getClassName(classId));
　　　　　　  　resultText = "mark:" + mobileNet.getClassName(classId) + "\n";
　　　　　　  　resultText = resultText + "Score:" + maxScore.ToString("F3") + "\n";
           
    
        }
       else if(markName == "yunisehu" ||markName == "Bellmark" ||markName == "foodforspecifiedhealthusesmark" ||markName == "Recyclesymbol" ||markName == "ecomark")
        {
             
　　　　　　 　resultText = "mark:" + mobileNet.getClassName3(classId) + "\n";
　　　　　 　　resultText = resultText + "Score:" + maxScore.ToString("F3") + "\n";

        }
        else
        {
            　resultText = "mark:" + mobileNet.getClassName2(classId) + "\n";
　　　　　 　　resultText = resultText + "Score:" + maxScore.ToString("F3") + "\n";
        }
        
             //    Debug.Log(maxScore);
        
            
        // MonoBehaviour.Destroy(webcamTexture);



        // 描画用テキスト構築
        
        //      resultText = "FPS:" + fpsCounter.FPS.ToString("F2") + "\n" + "\n";        
        //      resultText = resultText + "Class ID:" + classId.ToString() + "\n";
        
        //if (classId < 17 || classId > 19)
        //{

           // resultText = resultText + "Name:" + mobileNet.getClassName(classId) + "\n";
            //if (mobileNet.getClassName(classId) == markName)

                
            if (mobileNet.getClassName(classId) == markName || mobileNet.getClassName2(classId) == markName || mobileNet.getClassName3(classId) == markName)
            {
                getok = 3;
                resultText = resultText + "ok:" + getok.ToString("F3") + "\n";

                 if (markName == "Recyclesymbol"  && maxScore > 0.9f*sri.ninsiki)
                {
                    
                      sp = speakRecyclesymbol;
                      this.Getmarkimage.GetComponent<Image>().sprite = Recyclesymbolimage;
                      getok = 1;
                     }

                    // if (mobileNet.getClassName(classId) ==  "aluminummark" && maxScore > 0.7f*sri.ninsiki)
                    // {
                       
                    //     sp = speakRecyclesymbol;
                    //         this.Getmarkimage.GetComponent<Image>().sprite = Recyclesymbolimage;
                    //         getok = 1;
                    // }
                    // if (mobileNet.getClassName(classId) ==  "petmark" && maxScore > 0.7f*sri.ninsiki)
                    // {
                      
                    //     sp = speakRecyclesymbol;
                    //         this.Getmarkimage.GetComponent<Image>().sprite = Recyclesymbolimage;
                    //         getok = 1;
                    // }
                    // if (mobileNet.getClassName(classId) ==  "plasticmark" && maxScore > 0.7f*sri.ninsiki)
                    // {
                     
                    //     sp = speakRecyclesymbol;
                    //         this.Getmarkimage.GetComponent<Image>().sprite = Recyclesymbolimage;
                    //         getok = 1;
                    // }
                    // if (mobileNet.getClassName(classId) ==  "cardboardmark" && maxScore > 0.7f*sri.ninsiki)
                    // {
                    //     audioSource.Play ();
                    //     sp = speakRecyclesymbol;
                    //         this.Getmarkimage.GetComponent<Image>().sprite = Recyclesymbolimage;
                    //         getok = 1;
                    // }
                    // if (mobileNet.getClassName(classId) ==  "papermark" && maxScore > 0.7f*sri.ninsiki)
                    // {
                    //     audioSource.Play ();
                    //     sp = speakRecyclesymbol;
                    //         this.Getmarkimage.GetComponent<Image>().sprite = Recyclesymbolimage;
                    //         getok = 1;
                    // }
                    // if (mobileNet.getClassName(classId) ==  "papercartonmark" && maxScore > 0.7f*sri.ninsiki)
                    // {
                    //     audioSource.Play ();
                    //     sp = speakRecyclesymbol;
                    //         this.Getmarkimage.GetComponent<Image>().sprite = Recyclesymbolimage;
                    //         getok = 1;
                    // }
                


                 if (markName == "coolbizmark" && maxScore > 0.9f*sri.ninsiki)
                // {
                //  if (
                //     (  mobileNet.getClassName(classId) ==  "coolbizmark" 
                //     || mobileNet.getClassName(classId) ==  "coolchoicemark" 
                //     || mobileNet.getClassName(classId) ==  "WARMBIZmark"
                //     )
                //        && 
                       
                //        maxScore > 0.9f*sri.ninsiki
                //      )
                     {
                     sp = speakecomark;
                    this.Getmarkimage.GetComponent<Image>().sprite = coolbizmarkimage;
                    getok = 1;
                     }
                
                     if (markName == "JASmark" && maxScore > 0.6f*sri.ninsiki )
                // {
                //      if (
                //     (  mobileNet.getClassName(classId) ==  "JASmark"
                //     || mobileNet.getClassName(classId) ==  "JASmark2"
                //     || mobileNet.getClassName(classId) ==  "JASmark3" 
                //     || mobileNet.getClassName(classId) ==  "JASmark4"
   
                //     )
                //     && 
                //     maxScore > 0.9f*sri.ninsiki
                //      )
                     {
                     sp = speakRecyclesymbol;
                            this.Getmarkimage.GetComponent<Image>().sprite = JASmarkimage;
                            getok = 1;
                     }

                    // if (mobileNet.getClassName2(classId) ==  "coolchoicemark" && maxScore > 0.7f*sri.ninsiki)
                    // {
                    //     audioSource.Play ();
                    //     sp = speakecomark;
                    //         this.Getmarkimage.GetComponent<Image>().sprite = coolbizmarkimage;
                    //         getok = 1;
                    // }
                    // if (mobileNet.getClassName2(classId) ==  "WARMBIZmark" && maxScore > 0.7f*sri.ninsiki)
                    // {
                    //     audioSource.Play ();
                    //     sp = speakecomark;
                    //         this.Getmarkimage.GetComponent<Image>().sprite = coolbizmarkimage;
                    //         getok = 1;
                    // }
                
                if (markName == "olympicmark" && maxScore > 0.7f*sri.ninsiki)
                {
                //  if (
                //     (  mobileNet.getClassName(classId) ==  "olympicmark" 
                //     || mobileNet.getClassName(classId) ==  "paralympicmark" 
                //     )
                //        && 
                //        maxScore > 0.7f*sri.ninsiki
                //     )
                    
                        sp = speakSDGsmark;
                        this.Getmarkimage.GetComponent<Image>().sprite = olympicmarkimage;
                        getok = 1;
                    
                    // if (mobileNet.getClassName2(classId) ==  "paralympicmark" && maxScore > 0.7f*sri.ninsiki)
                    // {
                    //         sp = speakSDGsmark;
                    //         this.Getmarkimage.GetComponent<Image>().sprite = olympicmarkimage;
                    //         getok = 1;
                    // }
                }
                //   if (markName == "JASmark")
                // {
                //     if (mobileNet.getClassName2(classId) ==  "JASmark2" && maxScore > 0.7f*sri.ninsiki)
                //     {
                //         audioSource.Play ();
                //         sp = speakRecyclesymbol;
                //             this.Getmarkimage.GetComponent<Image>().sprite = JASmarkimage;
                //             getok = 1;
                //     }
            
                //  if (mobileNet.getClassName2(classId) ==  "JASmark3" && maxScore > 0.7f*sri.ninsiki)
                //     {
                //     audioSource.Play ();
                //     sp = speakRecyclesymbol;
                //         this.Getmarkimage.GetComponent<Image>().sprite = JASmarkimage;
                //         getok = 1;
                //     }
                
                //  if (mobileNet.getClassName2(classId) ==  "JASmark4" && maxScore > 0.7f*sri.ninsiki)
                //     {
                //     audioSource.Play ();
                //      sp = speakRecyclesymbol;
                //      this.Getmarkimage.GetComponent<Image>().sprite = JASmarkimage;
                //      getok = 1;
                //      }
                // }

                // webcamTexture.Stop();


                //  string nowtext = now.ToString("yyyy年MM月dd日 HH時mm分");
               

　　　　　　　　  //string CameraShot = PlayerPrefs.SetInt("CameraShot",encodedText);

                    //#if UNITY_EDITOR
                 //               GameObject.Find("Shot Main Camera").GetComponent<CameraScreenShotCapturer>().CaptureScreenShot(markName + ".png");
                    //#elif UNITY_WEBGL
                    //       GameObject.Find("Shot Main Camera").GetComponent<CameraScreenShotCapturer>().CaptureScreenShot("C:/ProgramData" + markName + ".png");
                    //#else
                    //         GameObject.Find("Shot Main Camera").GetComponent<CameraScreenShotCapturer>().CaptureScreenShot(markName + ".png");
                    //#endif
                //#if UNITY_WEBGL
                //    GameObject.Find("Shot Main Camera").GetComponent<CameraScreenShotCapturer>().CaptureScreenShot("C:/" + markName + ".png");
                //#else
                //      GameObject.Find("Shot Main Camera").GetComponent<CameraScreenShotCapturer>().CaptureScreenShot(markName + ".png");
                //#endif
                 
                int foundMarkCount = PlayerPrefs.GetInt(markName);
              
                foundMarkCount += 2;
                

                PlayerPrefs.SetInt(markName, foundMarkCount);
              
             //   Debug.Log(markName);
                //      Debug.Log(markName + "が見つかりました！見つけた数：" + foundMarkCount);
                //      Debug.Log(markName2 + "が見つかりました！見つけた数：" + foundMarkCount2);
                //      this.Explanationimage.GetComponent<Image>().enabled = true;
                string nowtext = now.ToString("MM月dd日");

                PlayerPrefs.SetString(markName + "Date", nowtext);

             //   Debug.Log(nowtext);
                if (markName == "hane")
                {
                    
                    if(maxScore > 0.9f*sri.ninsiki)
                    {
                  
                 sp = speakhane;
                 this.Getmarkimage.GetComponent<Image>().sprite = haneimage;
                 getok = 1;
     
                    }
                }
                if (markName == "Redcup")
                {
                   
                    if(maxScore > 0.7f*sri.ninsiki)
                    {
                     
                   sp = speakRedcup;
                    this.Getmarkimage.GetComponent<Image>().sprite = Redcupimage;
                    getok = 1;
     
              
                    }
                }
                if (markName == "AEDmark")
                {
                
                    if(maxScore > 0.7f*sri.ninsiki)
                    {
                    
                    sp = speakAEDmark;
                    this.Getmarkimage.GetComponent<Image>().sprite = AEDmarkimage;
                    getok = 1;
     
                  
                    }
                }
                if (markName == "Bellmark")
                {
                  
                    if(maxScore > 0.9f*sri.ninsiki)
                    {
                     
                   sp = speakBellmark;
                    this.Getmarkimage.GetComponent<Image>().sprite = Bellmarkimage;
                    getok = 1;
     

                    }
                }
                if (markName == "Maternitymark")
                { 
                    getok = 4;
                    resultText = resultText + "ok:" + getok.ToString("F3") + "\n";
                 
               //     if(maxScore > 0.8f*sri.ninsiki)
               if(maxScore > 0.8f)
                    {
            //        getok =5 ;
            //        resultText = resultText + "ok:" + getok.ToString("F3") + "\n";

                    sp = speakMaternitymark;
            //        getok =6 ;
            //        resultText = resultText + "ok:" + getok.ToString("F3") + "\n";

                    this.Getmarkimage.GetComponent<Image>().sprite = Maternitymarkimage;
                    getok = 1;
            //       resultText = resultText + "ok:" + getok.ToString("F3") + "\n";
        
                    }
                }
                if (markName == "Toiletmark")
                {
               
                    if(maxScore > 0.8f*sri.ninsiki)
                    {
                     
                   sp = speakToiletmark;
                    this.Getmarkimage.GetComponent<Image>().sprite = Toiletmarkimage;
                    getok = 1;
     
            
                    }
                }
                if (markName == "GreenEnergymark")
                {
                   
                    if(maxScore > 0.85f*sri.ninsiki)
                    {
                    
                    sp = speakGreenEnergymark;
                    this.Getmarkimage.GetComponent<Image>().sprite = GreenEnergymark;
                    getok = 1;
     
            
                    }
                }
                if (markName == "Kuruminmark")
                {
                    
                    if(maxScore > 0.7f*sri.ninsiki)
                    {
                    
                    sp = speakKuruminmark;
                    this.Getmarkimage.GetComponent<Image>().sprite = Kuruminmarkimage;
                    getok = 1;
     
                
                    }
                }
                if (markName == "JISmark")
                {
                   
                    if(maxScore > 0.7f*sri.ninsiki)
                    {
                    
                    sp = speakJISmark;
                    this.Getmarkimage.GetComponent<Image>().sprite = JISmarkimage;
                    getok = 1;
     
                
                    }
                }
                if (markName == "Helpmark")
                {
                    
                    if(maxScore > 0.8f*sri.ninsiki)
                    {
                      
                    sp = speakHelpmark;
                    this.Getmarkimage.GetComponent<Image>().sprite = Helpmarkimage;
                    getok = 1;
     
                
                    }
                }
                if (markName == "Evacuationsitemark")
                {
                   
                    if(maxScore > 0.5f*sri.ninsiki)
                    {
                      
                   sp = speakEvacuationsitemark;
                    this.Getmarkimage.GetComponent<Image>().sprite = Evacuationsitemarkimage;
                    getok = 1;
     
           
                    }
                }
                // if (markName == "Recyclesymbol")
                // {
               
                //     if(maxScore > 0.85f*sri.ninsiki)
                //     {
                      
                //    sp = speakRecyclesymbol;
                //     this.Getmarkimage.GetComponent<Image>().sprite = Recyclesymbolimage;
                //     getok = 1;
     
               
                //     }
                // }
                if (markName == "ecomark")
                {
                   
                    if(maxScore > 0.75f*sri.ninsiki)
                    {
                    
                    sp = speakecomark;
                    this.Getmarkimage.GetComponent<Image>().sprite = ecomarkimage;
                    getok = 1;
     
           
                    }
                }
                if (markName == "Ecolabelofthesea")
                {
                    
                    if(maxScore > 0.7f*sri.ninsiki)
                    {
                    
                 sp = speakEcolabelofthesea;
                    this.Getmarkimage.GetComponent<Image>().sprite = Ecolabeloftheseaimage;
                    getok = 1;
     
         
                    }
                }
                if (markName == "FSCmark")
                {
                
                    if(maxScore > 0.6f*sri.ninsiki)
                    {
                
                    sp = speakFSCmark;
                    this.Getmarkimage.GetComponent<Image>().sprite = FSCmarkimage;
                    getok = 1;
     
                  
                    }
                }
                if (markName == "Orangeribbon")
                { 
                    if(maxScore > 0.8f*sri.ninsiki)
                    {
                    
                    sp = speakOrangeribbon;
                    this.Getmarkimage.GetComponent<Image>().sprite = Orangeribbonimage;
                    getok = 1;
     
                    
                    }
                }
                if (markName == "SDGsmark")
                {
                      
                    if(maxScore > 0.9f*sri.ninsiki)
                    {
                      
                    sp = speakSDGsmark;
                    this.Getmarkimage.GetComponent<Image>().sprite = SDGsmarkimage;
                    getok = 1;
     
                    
               

                // Clipはメンバ変数としてAudioClipを別の場所で値を代入済みとする
                
                    }
                }
                if (markName == "yunisehu")
                {
                    
                    if(maxScore > 0.5f*sri.ninsiki)
                    {
                      
                 sp = speakhane;
                 this.Getmarkimage.GetComponent<Image>().sprite = yunisehuimage;
                 getok = 1;
     
                    }
                }
                if (markName == "rosunon")
                {
                   
                    if(maxScore > 0.7f*sri.ninsiki)
                    {
                          
                   sp = speakRedcup;
                    this.Getmarkimage.GetComponent<Image>().sprite = rosunonimage;
                    getok = 1;
     
              
                    }
                }
                if (markName == "foodforspecifiedhealthusesmark")
                {
                
                    if(maxScore > 0.5f*sri.ninsiki)
                    {
                     
                    sp = speakAEDmark;
                    this.Getmarkimage.GetComponent<Image>().sprite = foodforspecifiedhealthusesmarkimage;
                    getok = 1;
     
                  
                    }
                }
                if (markName == "MUDmark")
                {
                  
                    if(maxScore > 0.7f*sri.ninsiki)
                    {
                    
                   sp = speakBellmark;
                    this.Getmarkimage.GetComponent<Image>().sprite = MUDmarkimage;
                    getok = 1;
     

                    }
                }
                if (markName == "rainbowflag")
                {
                 
                    if(maxScore > 0.7f*sri.ninsiki)
                    {
                       
                   sp = speakMaternitymark;
                    this.Getmarkimage.GetComponent<Image>().sprite = rainbowflagimage;
                    getok = 1;
     
        
                    }
                }
                if (markName == "drinkingwatermark")
                {
               
                    if(maxScore > 0.7f*sri.ninsiki)
                    {
                      
                   sp = speakToiletmark;
                    this.Getmarkimage.GetComponent<Image>().sprite = drinkingwatermarkimage;
                    getok = 1;
     
            
                    }
                }
                if (markName == "biomassmark")
                {
                   
                    if(maxScore > 0.7f*sri.ninsiki)
                    {
                         
                    sp = speakGreenEnergymark;
                    this.Getmarkimage.GetComponent<Image>().sprite = biomassmarkimage;
                    getok = 1;
     
            
                    }
                }
                if (markName == "mitou")
                {
                    
                    if(maxScore > 0.7f*sri.ninsiki)
                    {
                         
                    sp = speakKuruminmark;
                    this.Getmarkimage.GetComponent<Image>().sprite = mitouimage;
                    getok = 1;
     
                
                    }
                }
                if (markName == "Gmark")
                {
                   
                    if(maxScore > 0.7f*sri.ninsiki)
                    {
                       
                    sp = speakJISmark;
                    this.Getmarkimage.GetComponent<Image>().sprite = Gmarkimage;
                    getok = 1;
     
                
                    }
                }
                if (markName == "wheelchairmark")
                {
                    
                    if(maxScore > 0.7f*sri.ninsiki)
                    {
                 
                    sp = speakHelpmark;
                    this.Getmarkimage.GetComponent<Image>().sprite = wheelchairmark;
                    getok = 1;
     
                
                    }
                }
                if (markName == "schoolroutemark")
                {
                   
                    if(maxScore > 0.7f*sri.ninsiki)
                    {
                      
                   sp = speakEvacuationsitemark;
                    this.Getmarkimage.GetComponent<Image>().sprite = schoolroutemarkimage;
                    getok = 1;
     
           
                    }
                }
                // if (markName == "JASmark")
                // {
               
                //     if(maxScore > 0.7f*sri.ninsiki)
                //     {
                   
                //    sp = speakRecyclesymbol;
                //     this.Getmarkimage.GetComponent<Image>().sprite = JASmarkimage;
                //     getok = 1;
     
               
                //     }
                // }
                // if (markName == "coolbizmark")
                // {
                   
                //     if(maxScore > 0.7f*sri.ninsiki)
                //     {
              
                //     sp = speakecomark;
                //     this.Getmarkimage.GetComponent<Image>().sprite = coolbizmarkimage;
                //     getok = 1;
     
           
                //     }
                // }
                if (markName == "greenplasticmark")
                {
                    
                    if(maxScore > 0.7f*sri.ninsiki)
                    {
                   
                 sp = speakEcolabelofthesea;
                    this.Getmarkimage.GetComponent<Image>().sprite = greenplasticmarkimage;
                    getok = 1;
     
         
                    }
                }
                if (markName == "greenmark")
                {
                
                    if(maxScore > 0.3f*sri.ninsiki)
                    {
                 
                    sp = speakFSCmark;
                    this.Getmarkimage.GetComponent<Image>().sprite = greenmarkimage;
                    getok = 1;
     
                  
                    }
                }
                if (markName == "peacemark")
                { 
                    if(maxScore > 0.8f*sri.ninsiki)
                    {
                      
                    sp = speakOrangeribbon;
                    this.Getmarkimage.GetComponent<Image>().sprite = peacemarkimage;
                    getok = 1;
     
                    
                    }
                }
                // if (markName == "olympicmark")
                // {
                      
                //     if(maxScore > 0.9f*sri.ninsiki)
                //     {
                        
                //     sp = speakSDGsmark;
                //     this.Getmarkimage.GetComponent<Image>().sprite = olympicmarkimage;
                //     getok = 1;
     
                    
               

                // // Clipはメンバ変数としてAudioClipを別の場所で値を代入済みとする
                
                //     }
                // }

              //     resultText = resultText + "ok:" + getok.ToString("F3") + "\n";

                         if(getok == 1)
                         {
               //          getok = 2;
                            GameObject.Find("Shot Main Camera").GetComponent<CameraScreenShotCapturer>().CaptureScreenShot(markName + ".png");
             //   Texture2D texture2 = new Texture2D((Screen.width/3+Screen.width/9)*7/10, (Screen.height/2+Screen.height/8)*7/10);
                Texture2D texture2 = new Texture2D(Screen.width*30/100, Screen.height*45/100);
                texture2.ReadPixels(new Rect(Screen.width*7/20, Screen.height*6/20, Screen.width*12/20, Screen.height*11/20), 0, 0);
                texture2.Apply();
                enc = System.Convert.ToBase64String(texture2.EncodeToJPG());
                PlayerPrefs.SetString("textShot" + markName,enc);
                PlayerPrefs.SetInt(markName,1);
                

                audioSource.Play ();
                Invoke("Getmark",0.1f);
                Invoke("Resettalking",7);
                                  if (Chatterscript.selectmarkname == "hane" || Chatterscript.selectmarkname == "Redcup" || Chatterscript.selectmarkname == "AEDmark" ||Chatterscript.selectmarkname == "Bellmark" || Chatterscript.selectmarkname == "Maternitymark" || Chatterscript.selectmarkname == "Toiletmark" || Chatterscript.selectmarkname == "GreenEnergymark" || Chatterscript.selectmarkname == "Kuruminmark" || Chatterscript.selectmarkname == "JISmark" || Chatterscript.selectmarkname == "Helpmark" || Chatterscript.selectmarkname == "Evacuationsitemark" || Chatterscript.selectmarkname == "Recyclesymbol" || Chatterscript.selectmarkname == "ecomark" || Chatterscript.selectmarkname == "Ecolabelofthesea" || Chatterscript.selectmarkname == "FSCmark" || Chatterscript.selectmarkname == "Orangeribbon" ||Chatterscript.selectmarkname == "SDGsmark" ||Chatterscript.selectmarkname == "MUDmark")
                                 {  
        
                                      Getmarkimage.transform.localScale= new Vector3(0.75f,0.75f,1);
                                       Getmarkimage.transform.DOLocalMove(new Vector3(-200, -100, 0), 0);
                                  }
                        else
                          {
                                     Getmarkimage.transform.localScale= new Vector3(0.4f,0.4f,1);
                                     Getmarkimage.transform.DOLocalMove(new Vector3(-250, -100, 0), 0);
                          }
                
                
             

                webcamTexture.Stop();
                         }
            }
        
    } 
        
//#if UNITY_IOS || UNITY_ANDROID
       
//#endif

        // テキスト画面反映
        //text.text = resultText;
        
    
    private void Resettalking()
    {
        
        this.Getmarkimage.GetComponent<Image>().enabled = false;
    //    this.Getmarkimage.GetComponent<Image>().sprite = Noon;
        //Getmarkimage.SetActive(false);

    }
    private void Getmark()
    {
                Destroy(texture1);
                Destroy(texture2);
    this.Getmarkimage.GetComponent<Image>().enabled = true;
    }
   
}