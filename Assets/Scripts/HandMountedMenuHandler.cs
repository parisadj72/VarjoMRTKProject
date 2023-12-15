using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMountedMenuHandler : MonoBehaviour
{

    public GameObject displayCollection;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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


    //Sets the menu panel in front of the user.
    public void SetTransformInFrontOfCamera(GameObject panel)
    {
        var camTrans = Camera.main.transform;
        panel.transform.position = camTrans.position + (new Vector3(camTrans.forward.x + 0.5f, 0, camTrans.forward.z) * 1.5f);
        panel.transform.LookAt(Camera.main.transform.position, Vector3.up);
    }
}
