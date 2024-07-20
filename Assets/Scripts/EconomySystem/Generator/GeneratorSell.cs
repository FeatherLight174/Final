using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorSell : MonoBehaviour
{
    public Generator generator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        generator.Sell();
    }
}
