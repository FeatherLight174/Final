using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldUpgrade : MonoBehaviour
{
    public Goldmine goldmine;
    private void OnMouseDown()
    {
        goldmine.Upgrade();
    }
}
