﻿using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CreatePlanets : MonoBehaviour
{
    public PlanetOrbit planetPrefab;

    public List<Material> material;

    public List<PlanetOrbit.PlanetData> planetData;

    [Header ("General Data")]
    public int distance;
    public GameObject orbitArround;
    public Material trailMat;

    void Awake()
    {
        for (int i = 0; i < planetData.Count; i++)
        {
            GameObject go = Instantiate(planetPrefab).gameObject;

            go.AddComponent<TrailRenderer>();
            go.GetComponent<TrailRenderer>().material = trailMat;

            PlanetOrbit p = go.GetComponent<PlanetOrbit>();

            p.Initialaze(planetData[i], material[Random.Range(0, material.Count)], ((i + 1) * distance), orbitArround);
        }
    }
}
