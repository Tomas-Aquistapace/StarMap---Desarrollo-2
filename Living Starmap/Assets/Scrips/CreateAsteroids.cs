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
    public List<GameObject> asteroidsPref;
    public List<GameObject> newAsteroids;

    void Awake()
    {
        GameObject plane = Instantiate(planePref).gameObject;
        plane.transform.position = newPosition;
        plane.transform.localScale = transform.localScale * newScale;

        for (int i = 0; i < newAsteroids.Count; i++)
        {
            GameObject ast = Instantiate(asteroidsPref[Random.Range(0, asteroidsPref.Count)]).gameObject;

            ast.transform.position = new Vector3((Random.Range(plane.transform.localScale.x * -1, plane.transform.localScale.x)),
                                                 (Random.Range(40, 60)),
                                                 (Random.Range(plane.transform.localScale.z * -1, plane.transform.localScale.z)));

            newAsteroids[i] = ast;
        }
    }
}
