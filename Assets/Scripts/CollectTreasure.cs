using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CollectTreasure : MonoBehaviour
{
    public void Collect()
    {
        Debug.Log("Die");
        Destroy(gameObject);
    }
}
