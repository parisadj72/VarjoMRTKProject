using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Varjo.XR;

public class VarjoEnableMR : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        VarjoRendering.SetOpaque(false);
        VarjoMixedReality.StartRender();
    }

}
