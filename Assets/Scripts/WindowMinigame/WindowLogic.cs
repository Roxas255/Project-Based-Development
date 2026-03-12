using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowLogic : MonoBehaviour
{
    public Transform[] WindowPoints;
    private List<Transform> unsealedPoints;
    //how far the mouose is from the sealing points before it starts to lose accuracy
    public float LowErrorMargin;
     //how far the mouse is from the sealing points before it starts to lose even more accuracy
    public float LowPenaltyRate;
    public float HighErrorMargin;
    public float HighPenaltyRate;
    public float CurrentScore = 0f;
    public float FinalScore;

    private float timer = 0f;
    void Start()
    {
        unsealedPoints = new List<Transform>(WindowPoints);
    }

    void Update()
    {
        if (WindowSealer.instance != null && WindowSealer.instance.isDrawing == true)
        {
            CheckAccuracy();
        }
        if (WindowScript.instance != null && WindowScript.instance.gameFinished == true)
        {
            FinalScore = GetFinalScore();
            Debug.Log("Final Score: " + FinalScore);
            WindowScript.instance.gameFinished = false; 
        }

    }
    float distanceToPoint;
    public void CheckAccuracy()
    {
        //mouse stuff
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Math.Abs(Camera.main.transform.position.z - WindowPoints[0].position.z);
        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);

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
            Debug.Log("LOSING EVEN MORE POINTS!");
        }
        else if (distanceToPoint > LowErrorMargin)
        {
            losingPoints = true;
            CurrentScore -= Time.deltaTime * LowPenaltyRate; 
            Debug.Log("LOSIKNG POINTS!");
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
                    Debug.Log("LOSING POINTS FOR TOO LONG!");
                    CurrentScore -= Time.deltaTime * HighPenaltyRate * 1.5f; 
                }
            }
        }
    }
    public float GetFinalScore()
    {
        return Mathf.Max(0, CurrentScore);
    }
}
