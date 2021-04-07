using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateAsteroids : MonoBehaviour
{
    [Header("Elements Plane")]
    public GameObject planePref;
    public Vector3 newPosition;
    public float newScale;

    [Header("Asteroids Data")]
    public List<AsteroidsController> asteroidsPref;
    public List<GameObject> newAsteroids;

    GameObject plane;

    void Awake()
    {
        plane = Instantiate(planePref).gameObject;
        plane.transform.position = newPosition;
        plane.transform.localScale = new Vector3(transform.localScale.x * newScale, 1, transform.localScale.z * newScale);
        plane.name = "AsteroidsLimit";

        for (int i = 0; i < newAsteroids.Count; i++)
        {
            GameObject ast = Instantiate(asteroidsPref[Random.Range(0, asteroidsPref.Count)]).gameObject;

            AsteroidsController p = ast.GetComponent<AsteroidsController>();

            p.Initialize(plane, i);

            newAsteroids[i] = ast;
        }
    }
}
