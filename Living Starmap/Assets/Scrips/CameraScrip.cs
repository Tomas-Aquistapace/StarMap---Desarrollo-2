using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScrip : MonoBehaviour
{
    public List<GameObject> planets;

    private int select = 0;
    private Vector3 actualPos;

    private int CAMERA_NUM = 10;

    void Start()
    {
        foreach (GameObject planet in GameObject.FindGameObjectsWithTag("Planet"))
        {
            planets.Add(planet);
        }

        foreach (GameObject ship in GameObject.FindGameObjectsWithTag("Player"))
        {
            planets.Add(ship);
        }

        select = CAMERA_NUM; // camera position
        actualPos = transform.position;
    }
    
    void Update()
    {
        SelectPlanet();

        if(select < CAMERA_NUM && select < planets.Count)
            transform.position = planets[select].transform.position + (actualPos / 2);
        else
            transform.position = actualPos;
    }

    void SelectPlanet()
    {
        if (Input.GetKeyDown("1"))
            if (select != 0) select = 0; else select = 10;
        if (Input.GetKeyDown("2"))
            if (select != 1) select = 1; else select = 10;
        if (Input.GetKeyDown("3"))
            if (select != 2) select = 2; else select = 10;
        if (Input.GetKeyDown("4"))
            if (select != 3) select = 3; else select = 10;
        if (Input.GetKeyDown("5"))
            if (select != 4) select = 4; else select = 10;
        if (Input.GetKeyDown("6"))
            if (select != 5) select = 5; else select = 10;
        if (Input.GetKeyDown("7"))
            if (select != 6) select = 6; else select = 10;
        if (Input.GetKeyDown("8"))
            if (select != 7) select = 7; else select = 10;
        if (Input.GetKeyDown("9"))
            if (select != 8) select = 8; else select = 10;
        if (Input.GetKeyDown("0"))
            if (select != 9) select = 9; else select = 10;
    }
}
