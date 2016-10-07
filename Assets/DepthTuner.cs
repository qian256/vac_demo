using UnityEngine;
using System.Collections;
using System;
using UnityStandardAssets.ImageEffects;

public class DepthTuner : MonoBehaviour {

    private CardboardReticle rectile;
    
    public float maxFocalDistance = 10.0f;
    public float minFocalDistance = 0.0f;
    private float currentFocalDistance = 0.1f;
    private float tempFocalDistance = 0.0f;

    public DepthOfField leftCamera, rightCamera;
    
    public float getCurrentDOF() {
        return currentFocalDistance;
    }
    
    
    // Use this for initialization
    void Start () {
        rectile = GetComponent<CardboardReticle>();
    }

    // Update is called once per frame
    void Update() {
        if (Cardboard.SDK.BackButtonPressed) {
            Application.Quit();
        }
        if ( rectile.onUI) {
            leftCamera.aperture = 0;
            rightCamera.aperture = 0;
        }
        else {
            leftCamera.aperture = 0.4f;
            rightCamera.aperture = 0.4f;
        }
        tempFocalDistance = rectile.currentDistance;
        currentFocalDistance = Mathf.Clamp(tempFocalDistance, minFocalDistance, maxFocalDistance);
        leftCamera.focalLength = currentFocalDistance;
        rightCamera.focalLength = currentFocalDistance;
    }

    public void Quit() {
        Application.Quit();
    }
    
}
