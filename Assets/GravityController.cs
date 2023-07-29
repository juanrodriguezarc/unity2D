using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{

    private float gravity = -20.0f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Attract(Rigidbody2D body)
    {
        var targetDir = (body.transform.position - transform.position).normalized;
        var bodyUp = body.transform.up;
        body.transform.rotation = Quaternion.FromToRotation(bodyUp, targetDir) * body.transform.rotation;
        body.AddForce(targetDir * gravity);
    }

}
