using Microsoft.MixedReality.Toolkit.UI;
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

    public int score { get; private set; } = 0;
    public bool task1 { get; private set; } = false;
    public bool task2 { get; private set; } = false;
    public bool task3 { get; private set; } = false;

    // Start is called before the first frame update
    void Start()
    {
        DeactiveAllLayouts();
        //displayCollection.transform.GetChild(8).gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (task1)
        {
            if (flat3.activeSelf && AllBlack(flat3) && score <= 5)
            {
                RunNTimes(flat3);
            }
            else if (flat6.activeSelf && AllBlack(flat6) && score <= 5)
            {
                RunNTimes(flat6);
            }
            else if (flat15.activeSelf && AllBlack(flat15) && score <= 5)
            {
                RunNTimes(flat15);
            }
            else if (curve3.activeSelf && AllBlack(curve3) && score <= 5)
            {
                RunNTimes(curve3);
            }
            else if (curve6.activeSelf && AllBlack(curve6) && score <= 5)
            {
                RunNTimes(curve6);
            }
            else if (curve15.activeSelf && AllBlack(curve15) && score <= 5)
            {
                RunNTimes(curve15);
            }
            else if (stack3.activeSelf && AllBlack(stack3) && score <= 5)
            {
                RunNTimes(stack3);
            }
            else if (stack6.activeSelf && AllBlack(stack6) && score <= 5)
            {
                RunNTimes(stack6);
            }
            else if (stack15.activeSelf && AllBlack(stack15) && score <= 5)
            {
                RunNTimes(stack15);
            }
        }
    }
    private void DeactiveLayout(GameObject layout)
    {
        layout.SetActive(false);
    }
    private void DeactiveAllLayouts()
    {
        DeactiveLayout(flat3);
        DeactiveLayout(flat6);
        DeactiveLayout(flat15);
        DeactiveLayout(curve3);
        DeactiveLayout(curve6);
        DeactiveLayout(curve15);
        DeactiveLayout(stack3);
        DeactiveLayout(stack6);
        DeactiveLayout(stack15);
    }

    public void ScreenClickDetected(GameObject cube)
    {
        if(cube.GetComponent<Renderer>().material.color == Color.white) // new Color(242, 243, 244))
        {
            cube.GetComponent<Renderer>().material.color = Color.black; // new Color(0, 0, 0);
            score += 1;
        }
    }
    public void ActivateLayout(GameObject layout)
    {
        DeactiveAllLayouts();
        layout.SetActive(true);
        score = 0;
    }
    public void ActivateTask1()
    {
        task2 = false;
        task3 = false;
        task1 = true;
    }
    public void ActivateTask2()
    {
        task1 = false;
        task3 = false;
        task2 = true;
    }
    public void ActivateTask3()
    {
        task1 = false;
        task2 = false;
        task3 = true;
    }
    public void startTask1() //select random white screen
    {
        if (flat3.activeSelf)
        {
            ColorScreensBlack(flat3);
            // find a random cube screen
            int randomNumber = UnityEngine.Random.Range(1, 4);
            // change the color of that screen to white
            flat3.transform.GetChild(randomNumber).GetComponent<Renderer>().material.color = Color.white; // new Color(242, 243, 244);
            // wait for user to click on it
            // flat3.transform.GetChild(randomNumber).GetComponent<Interactable>().OnClick.AddListener();
        }
    }
    private void ColorScreensBlack(GameObject layout)
    {
        // set the color of all screen to black
        foreach (Transform t in layout.transform)
        {
            t.GetComponent<Renderer>().material.color = Color.black; // new Color(0, 0, 0);
        }
    }

    private void RunNTimes(GameObject layout)
    {
        if (AllBlack(layout))
        {
            // find a random cube screen
            int randomNumber = UnityEngine.Random.Range(0, layout.transform.childCount);
            // change the color of that screen to white
            layout.transform.GetChild(randomNumber).GetComponent<Renderer>().material.color = Color.white; // new Color(242, 243, 244);
        }
    }
    private bool AllBlack(GameObject layout)
    {
        foreach (Transform t in layout.transform)
        {
            if (t.GetComponent<Renderer>().material.color != Color.black) //new Color(0, 0, 0))
            {
                return false;
            }
        }
        return true;
    }

    /*private void screenColorFunc()
{
   if ()
   {
       // find a random cube screen
       int randomNumber = UnityEngine.Random.Range(1, 4);
       // change the color of that screen to white
       foreach (Transform t in flat3.transform)
       {
           t.GetComponent<Renderer>().material.color = new Color(0, 0, 0);
       }
       flat3.transform.GetChild(randomNumber).GetComponent<Renderer>().material.color = new Color(242, 243, 244);
   }
}
*/
    public void startTask2() // select the ball in each screen
    {
        if (flat3.activeSelf)
        {
            {
                // find a random cube screen
                int randomNumber = UnityEngine.Random.Range(1, 4); //1 2 3
                // find a radom position in the front side of the cube screen
                Vector3 minPosition = flat3.transform.GetChild(randomNumber).GetComponent<Collider2D>().bounds.min;
                Vector3 maxPosition = flat3.transform.GetChild(randomNumber).GetComponent<Collider2D>().bounds.max;
                Vector3 randomPosition = new Vector3(
                    UnityEngine.Random.Range(minPosition.x, maxPosition.x),
                    UnityEngine.Random.Range(minPosition.y, maxPosition.y),
                    minPosition.z
                );
                //position the ball

            } //repeat five times
        }
        else if (flat6.activeSelf)
        {

        }
        else if (flat15.activeSelf)
        {

        }
        else if (curve3.activeSelf)
        {

        }
        else if (curve6.activeSelf)
        {

        }
        else if (curve15.activeSelf)
        {

        }
        else if (stack3.activeSelf)
        {

        }
        else if (stack6.activeSelf)
        {

        }
        else if (stack15.activeSelf)
        {

        }
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
