using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject go;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Esc.pause)
        {
            go.SetActive(true);
        }
        else
        {
            go.SetActive(false);
        }
    }
}
