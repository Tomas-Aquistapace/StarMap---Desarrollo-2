using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetOrbit : MonoBehaviour
{
    [Serializable]
    public class PlanetData
    {
        [HideInInspector] public float translationRadius;
        [HideInInspector] public float translationSpeed;

        [HideInInspector] public Vector3 rotationAxis;
        [HideInInspector] public float rotationSpeed;

        [HideInInspector] public float size = 1;
    }

    public float radius;
    public float speed;
    public Vector3 rotationDirection;
    public float rotationSpeed;
    public Vector3 wantedScale;

    float angle = 0;

    public void Initialaze(PlanetData planet, Material material, int i, int distance)
    {
        //radius = planet.translationRadius;
        //speed = planet.translationSpeed;
        //rotationDirection = planet.rotationAxis;
        //rotationSpeed = planet.rotationSpeed;
        //wantedScale = Vector3.one * planet.size;

        radius = (i+1) * distance;
        speed = UnityEngine.Random.Range(0.5f, 2f);
        rotationDirection = new Vector3(0, 1, 0);
        rotationSpeed = UnityEngine.Random.Range(1f, 4f);
        wantedScale = Vector3.one * UnityEngine.Random.Range(1f, 8f);

        GetComponent<MeshRenderer>().material = material;
    }

    void Update()
    {
        OrbitArround();
    }

    void OrbitArround()
    {
        Vector3 vec = Vector3.zero;

        angle += speed * Time.deltaTime;
        vec.x = radius * Mathf.Cos(angle);
        vec.z = radius * Mathf.Sin(angle);

        transform.localScale = wantedScale;

        transform.position = vec;
        transform.Rotate(rotationDirection * rotationSpeed * Time.deltaTime);
    }
}
