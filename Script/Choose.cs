using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choose : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.transform.localScale = new Vector3(0.35f, 0.35f, 0.35f);
    }
    
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
    }
}
