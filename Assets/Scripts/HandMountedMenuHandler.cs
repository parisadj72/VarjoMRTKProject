using Microsoft.MixedReality.Toolkit.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMountedMenuHandler : MonoBehaviour
{

    public GameObject displayCollection;

    public GameObject flat3;
    public GameObject flat6;
    public GameObject flat15;
    public GameObject curve3;
    public GameObject curve6;
    public GameObject curve15;
    public GameObject stack3;
    public GameObject stack6;
    public GameObject stack15;

    // Start is called before the first frame update
    void Start()
    {
        Reset();
        //displayCollection.transform.GetChild(8).gameObject.SetActive(false);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    private void Reset()
    {
        flat3.SetActive(false);
        flat6.SetActive(false);
        flat15.SetActive(false);
        curve3.SetActive(false);
        curve6.SetActive(false);
        curve15.SetActive(false);
        stack3.SetActive(false);
        stack6.SetActive(false);
        stack15.SetActive(false);
    }
    public void Flat_3()
    {
        Reset();
        flat3.SetActive(true);
    }
    public void Flat_6()
    {
        Reset();
        flat6.SetActive(true);
    }
    public void Flat_15()
    {
        Reset();
        flat15.SetActive(true);
    }
    public void Curve_3()
    {
        Reset();
        curve3.SetActive(true);
    }
    public void Curve_6()
    {
        Reset();
        curve6.SetActive(true);
    }
    public void Curve_15()
    {
        Reset();
        curve15.SetActive(true);
    }
    public void Stack_3()
    {
        Reset();
        stack3.SetActive(true);
    }
    public void Stack_6()
    {
        Reset();
        stack6.SetActive(true);
    }
    public void Stack_15()
    {
        Reset();
        stack15.SetActive(true);
    }


    public void ThreeDisplaysToggle()
    {
        DisplaysToggle(3);
    }
    public void SixDisplaysToggle()
    {
        DisplaysToggle(6);
    }
    public void FiftheenDisplaysToggle()
    {
        DisplaysToggle(15);
    }
    public void DisplaysToggle(int numberOfDisplays)
    {
        for (int i = 0; i < displayCollection.transform.childCount; i++)
        {
            displayCollection.transform.GetChild(i).gameObject.SetActive(false);
        }

        int[] displayNumbers = new int[15];
        for (int i = 0; i < 15; i++)
        {
            displayNumbers[i] = -1;
        }

        if (numberOfDisplays == 3)
        {
            displayNumbers[0] = 5;
            displayNumbers[1] = 11;
        }
        else if (numberOfDisplays == 6)
        {
            displayNumbers[0] = 4;
            displayNumbers[1] = 5;
            displayNumbers[2] = 7;
            displayNumbers[3] = 10;
            displayNumbers[4] = 11;
        }
        // numberOfDisplays == 15
        else
        {
            for (int i = 0; i < 8; i++)
            {
                displayNumbers[i] = i;
            }
            for (int i = 9; i < 15; i++)
            {
                displayNumbers[i-1] = i;
            }
        }

        for (int i = 0; i < displayNumbers.Length; i++)
        {
            int x = displayNumbers[i];
            if (x != -1)
                displayCollection.transform.GetChild(x).gameObject.SetActive(true);
        }
    }

    public void SwitchLayoutsToFlat()
    {
        TileGridObjectCollection tileGridObjectCollection = displayCollection.GetComponent<TileGridObjectCollection>();
        tileGridObjectCollection.gameObject.SetActive(false);

        GridObjectCollection gridObjectCollection = displayCollection.GetComponent<GridObjectCollection>();
        gridObjectCollection.SurfaceType = ObjectOrientationSurfaceType.Plane;
        gridObjectCollection.CellHeight = 1.2f;
        gridObjectCollection.CellWidth =  1.2f;
        gridObjectCollection.OrientType = OrientationType.FaceParentFoward;
        displayCollection.transform.GetChild(8).gameObject.SetActive(true);
        gridObjectCollection.UpdateCollection();

        displayCollection.transform.GetChild(8).gameObject.SetActive(false);
    }
    public void SwitchLayoutsToCylinder()
    {
        TileGridObjectCollection tileGridObjectCollection = displayCollection.GetComponent<TileGridObjectCollection>();
        tileGridObjectCollection.gameObject.SetActive(false);

        GridObjectCollection gridObjectCollection = displayCollection.GetComponent<GridObjectCollection>();
        gridObjectCollection.SurfaceType = ObjectOrientationSurfaceType.Cylinder;
        gridObjectCollection.CellHeight = 2;
        gridObjectCollection.CellWidth = 2;
        gridObjectCollection.Radius = 3;
        gridObjectCollection.OrientType = OrientationType.FaceCenterAxis;
        displayCollection.transform.GetChild(8).gameObject.SetActive(true);
        gridObjectCollection.UpdateCollection();

        displayCollection.transform.GetChild(8).gameObject.SetActive(false);
    }
    public void SwitchLayoutsToStack()
    {
        TileGridObjectCollection tileGridObjectCollection = displayCollection.GetComponent<TileGridObjectCollection>();
        tileGridObjectCollection.gameObject.SetActive(true);
    }
    //Sets the menu panel in front of the user.
    public void SetTransformInFrontOfCamera(GameObject panel)
    {
        var camTrans = Camera.main.transform;
        panel.transform.position = camTrans.position + (new Vector3(camTrans.forward.x + 0.5f, 0, camTrans.forward.z) * 1.5f);
        panel.transform.LookAt(Camera.main.transform.position, Vector3.up);
    }
}
