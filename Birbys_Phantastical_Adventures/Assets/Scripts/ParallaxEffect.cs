using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParallaxEffect : MonoBehaviour
{
    public Camera cam;
    public Transform followTarget;
    // Start is called before the first frame update
    Vector2 startingPosittion;
    float startingz;
    Vector2 camMoveSinceStart => (Vector2) cam.transform.position - startingPosittion;
    float distanceFromTarget => transform.position.z-followTarget.transform.position.z;
    float clippingPlane => (cam.transform.position.z +(distanceFromTarget>0?cam.farClipPlane:cam.nearClipPlane));
    float parallaxFactor => Mathf.Abs(distanceFromTarget) / clippingPlane;
    void Start()
    {
        startingPosittion = transform.position;
        startingz= transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPosition = startingPosittion + camMoveSinceStart*parallaxFactor;
        transform.position = new Vector3(newPosition.x, newPosition.y, startingz);
    }
}
