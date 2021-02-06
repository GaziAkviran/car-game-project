using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapShadows : MonoBehaviour
{
    private float previousShadowDistance;
    void OnPreRender()
    {
        previousShadowDistance = QualitySettings.shadowDistance;
        QualitySettings.shadowDistance = 0;
    }
    void OnPostRender()
    {
        QualitySettings.shadowDistance = previousShadowDistance;
    }
}
