using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WindowLogic : MonoBehaviour
{
    public Transform[] WindowPoints;
    private List<Transform> unsealedPoints;

    [Header("Scoring Parameters")]
    //how far the mouose is from the sealing points before it starts to lose accuracy
    public float LowErrorMargin;
     //how far the mouse is from the sealing points before it starts to lose even more accuracy
    public float LowPenaltyRate;
    public float HighErrorMargin;
    public float HighPenaltyRate;
    [Header("Speed Settings")]
    public float maxSealSpeed;
    public float maxSpeedPenaltyRate;
    private Vector3 lastMousePosition;
    private float currentMouseSpeed;
    [Header("Score")]
    public float CurrentScore = 0f;
    public float FinalScore;

    private float timer = 0f;
    void Start()
    {
        unsealedPoints = new List<Transform>(WindowPoints);
    }

    void Update()
    {
        CalculateMouseSpeed();
        if (WindowSealer.instance != null && WindowSealer.instance.isDrawing == true)
        {
            CheckAccuracy();
            CheckSpeedPenalty();
        }
        if (WindowScript.instance != null && WindowScript.instance.gameFinished == true)
        {
            FinalScore = GetFinalScore();
            Debug.Log("Final Score: " + FinalScore);
            WindowScript.instance.gameFinished = false; 
        }
        lastMousePosition = Camera.main.ScreenToWorldPoint
        (new Vector3(Input.mousePosition.x, Input.mousePosition.y, 
        Math.Abs(Camera.main.transform.position.z - WindowPoints[0].position.z)));
    }
    float distanceToPoint;
    Vector3 worldMousePos;
    public void CheckAccuracy()
    {
        //mouse stuff
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Math.Abs(Camera.main.transform.position.z - WindowPoints[0].position.z);
        worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);

        //checks the distance from the mouse to any point of th ewindow and stores it.  
        distanceToPoint = float.MaxValue;
        foreach (var point in WindowPoints)
        {
            float d = Vector3.Distance(worldMousePos, point.position);
            if (d < distanceToPoint) 
            {
                distanceToPoint = d;
            }
        }

        float minDistanceToGoal = float.MaxValue;
        Transform closestPoint = null;

        foreach (var point in unsealedPoints)
        {
            float distance = Vector3.Distance(worldMousePos, point.position);
            if (distance < minDistanceToGoal)
            {
                minDistanceToGoal = distance;
                closestPoint = point;
            }
        }

        LosePointsForAccuracy();

        //gives x points per seal and removes the point from list
        if (minDistanceToGoal < 0.2f && closestPoint != null)
        {
            unsealedPoints.Remove(closestPoint);
            CurrentScore += 2f; 
        }
    }

    public bool losingPoints = false;
    public void LosePointsForAccuracy()
    {        
        if (distanceToPoint > HighErrorMargin)
        {
            losingPoints = true;
            CurrentScore -= Time.deltaTime * HighPenaltyRate; 
            Debug.Log("<color=red>LOSING EVEN MORE POINTS!</color>");
        }
        else if (distanceToPoint > LowErrorMargin)
        {
            losingPoints = true;
            CurrentScore -= Time.deltaTime * LowPenaltyRate; 
            Debug.Log("<color=red>LOSIKNG POINTS!</color>");
        }
        else
        {
            losingPoints = false;
            timer = 0f;
        }

        if (losingPoints)
        {
            if (losingPoints)
            {
                timer += Time.deltaTime;
                if (timer >= 2f)
                {
                    Debug.Log("<color=red>LOSING POINTS FOR TOO LONG!</color>");
                    CurrentScore -= Time.deltaTime * HighPenaltyRate * 1.5f; 
                }
            }
        }
    }
    void CalculateMouseSpeed()
    {
        Vector3 currentMousePos = Camera.main.ScreenToWorldPoint
        (new Vector3(Input.mousePosition.x, Input.mousePosition.y, 
        Math.Abs(Camera.main.transform.position.z - WindowPoints[0].position.z)));
    
        currentMouseSpeed = Vector3.Distance(currentMousePos, lastMousePosition) / Time.deltaTime;
    }
    void CheckSpeedPenalty()
    {
        if (currentMouseSpeed > maxSealSpeed)
        {
            CurrentScore -= Time.deltaTime * maxSpeedPenaltyRate;
            Debug.Log("SLOW DOWN! Moving too fast: " + currentMouseSpeed);
        }
    }
    public float GetFinalScore()
    {
        return Mathf.Max(0, CurrentScore);
    }
}
