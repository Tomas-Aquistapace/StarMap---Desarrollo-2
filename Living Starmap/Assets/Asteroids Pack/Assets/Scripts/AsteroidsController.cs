using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsController : MonoBehaviour
{
    GameObject astLimits;

    public void Initialize(GameObject plane, int i)
    {
        astLimits = plane;

        this.transform.position = NewAstPosition(astLimits);

        this.name = "Asteroid_" + i;
    }

    Vector3 NewAstPosition(GameObject plane)
    {
        return new Vector3((Random.Range(plane.transform.localScale.x * -1, plane.transform.localScale.x)),
                                                 (Random.Range(40, 80)),
                                                 (Random.Range(plane.transform.localScale.z * -1, plane.transform.localScale.z)));
    }

    private void OnTriggerEnter(Collider other)
    {
        this.transform.position = NewAstPosition(astLimits);

        if (other.gameObject.tag == "Planet")
            Destroy(other.gameObject);
    }
}
