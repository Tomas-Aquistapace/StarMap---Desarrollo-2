using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlanets : MonoBehaviour
{
    public PlanetOrbit planetPrefab;

    public List<PlanetOrbit.PlanetData> planetData;
    
    //public List<PlanetOrbit> generatedPlanets = new List<PlanetOrbit>();
    
    void Awake()
    {
        for (int i = 0; i < planetData.Count; i++)
        {
            GameObject go = Instantiate(planetPrefab).gameObject;

            PlanetOrbit p = go.GetComponent<PlanetOrbit>();

            p.Initialaze(planetData[i]);

            //generatedPlanets.Add(p);
        }
    }
}
