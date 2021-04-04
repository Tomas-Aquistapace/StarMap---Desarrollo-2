using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlanets : MonoBehaviour
{
    public PlanetOrbit planetPrefab;

    public List<PlanetOrbit.PlanetData> planetData;

    //public List<PlanetOrbit> planetsCreator = new List<PlanetOrbit>();
    
    void Start()
    {
        for (int i = 0; i < planetData.Count; i++)
        {
            //PlanetOrbit.PlanetData planet = planetData[i];

            GameObject go = Instantiate(planetPrefab).gameObject;

            PlanetOrbit p = go.GetComponent<PlanetOrbit>();

            p.Initialaze(planetData[i]);
        }
    }
}
