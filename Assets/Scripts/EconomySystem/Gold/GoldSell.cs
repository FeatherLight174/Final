using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldSell : MonoBehaviour
{
    public Goldmine goldmine;
    private void OnMouseDown()
    {
        goldmine.Sell();
    }
}
