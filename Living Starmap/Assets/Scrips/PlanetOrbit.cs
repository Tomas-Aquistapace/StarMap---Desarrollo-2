using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetOrbit : MonoBehaviour
{
    [Serializable]
    public class PlanetData
    {
        public float translationRadius;
        public float translationSpeed;

        public Vector3 rotationAxis;
        public float rotationSpeed;

        public float size = 1;

        public Material material;
    }

    public float speed;
    public float radius;
    public Vector3 wantedScale;
    public float rotationSpeed;
    public Vector3 rotationDirection;

    float angle = 0;

    public void Initialaze(PlanetData planet)
    {
        radius = planet.translationRadius;
        speed = planet.translationSpeed;
        rotationDirection = planet.rotationAxis;
        rotationSpeed = planet.rotationSpeed;
        wantedScale = Vector3.one * planet.size;
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

        transform.position = vec;
        transform.rotation = Quaternion.Euler(0, angle, 0);
    }

    private void OnEnable()
    {
        transform.localScale = wantedScale;
    }
}