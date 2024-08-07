using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointParent : MonoBehaviour
{
    public GameObject homePanel;
    public int numPoints = 0;

    private void Update()
    {
        if (numPoints <= 0)
        {
            homePanel.SetActive(true);
        }
    }
}
