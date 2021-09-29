using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class cloud : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = new Vector3(Random.Range(-10, 10f), Random.Range(-5f, 5f), 0);
        this.transform.localScale = new Vector3(Random.Range(0.3f, 0.7f), Random.Range(0.3f, 0.7f),0);
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 pos = this.transform.position;
        pos.x += 0.005f;
        this.transform.position = pos;
        if (this.transform.position.x > 10)
        {
            this.transform.position = new Vector3(-10, Random.Range(-5f, 5f), 0);
        }
    }
}
