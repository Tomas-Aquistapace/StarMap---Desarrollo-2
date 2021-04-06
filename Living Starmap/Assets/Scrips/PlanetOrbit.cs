using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlanetOrbit : MonoBehaviour
{
    [Serializable]
    public class PlanetData
    {
        public string planetName;

        [HideInInspector] public float translationRadius;
        [HideInInspector] public float translationSpeed;

        [HideInInspector] public Vector3 rotationAxis;
        [HideInInspector] public float rotationSpeed;

        [HideInInspector] public float size = 1;
    }

    //public string name;
    public float radius;
    public float speed;
    public Vector3 rotationDirection;
    public float rotationSpeed;
    //public Vector3 wantedScale;

    public GameObject orbitArround;
    
    private Color planetColor;

    public void Initialaze(PlanetData planet, Material material, int distance, GameObject center)
    {
        radius = distance;
        speed = Random.Range(15f, 25f);
        rotationDirection = new Vector3(0, 1, 0);
        rotationSpeed = Random.Range(2f, 4f);
        transform.localScale = Vector3.one * Random.Range(1f, 8f);

        GetComponent<MeshRenderer>().material = material;
        GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
        planetColor = GetComponent<MeshRenderer>().material.color;

        gameObject.name = planet.planetName;
        gameObject.transform.position = new Vector3(center.transform.position.x + radius, center.transform.position.y, center.transform.position.z);

        orbitArround = center;
    }

    void Update()
    {
        OrbitArround();
    }

    void OrbitArround()
    {
        Vector3 vec = orbitArround.transform.position;
        
        transform.RotateAround(vec, Vector3.down, speed * Time.deltaTime);
        transform.Rotate(rotationDirection * rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            planetColor.a = 0.4f;
            GetComponent<MeshRenderer>().material.color = planetColor;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (planetColor.a < 1)
        {
            planetColor.a = 1f;
            GetComponent<MeshRenderer>().material.color = planetColor;
        }
    }
}
