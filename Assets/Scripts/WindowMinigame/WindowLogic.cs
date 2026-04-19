using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.EventSystems;

public class WindowLogic : MonoBehaviour
{
    //lists all the seal points that need to be sealed by tracking the tranform.position of the points
    public Transform[] WindowPoints;
    private List<Transform> unsealedPoints;

    [Header("Scoring Parameters")]
    //how far the mouose is from the sealing points before it starts to lose accuracy
    public float LowErrorMargin;
     //how fast you lose points at at the low end
    public float LowPenaltyRate;
    //how far the mouse is from the sealing points before it starts to lose even more accuracy
    public float HighErrorMargin;
    //how fast you lose points at the high end
    public float HighPenaltyRate;
    [Header("Speed Settings")]
    //how fast you can go before you start losing points
    public float maxSealSpeed;
    //how fast you lose points when moving too fast
    public float maxSpeedPenaltyRate;
    public float speedPointsLoss = 0;
    private Vector3 lastMousePosition;
    private float currentMouseSpeed;
    [Header("Score")]
    public float finalPercentage;
    public float finalTierPoints;
    public float pointsPerSeal;
    public float CurrentScore = 0f;
    public float maxPossibleScore = 100f;
    public float FinalScore;
    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI accuracyText;
    [Header("Score Saving")]
    public string scoreKey;
    private float timer = 0f;
    public static WindowLogic instance;
    
    public TextMeshProUGUI finalscore;
    void Start()
    {
        unsealedPoints = new List<Transform>(WindowPoints);
        instance = this;

        CurrentScore = 0f;
        maxPossibleScore = WindowPoints.Length * pointsPerSeal;

    }

    void Update()
    {
        CalculateMouseSpeed();
        if (WindowSealer.instance != null && WindowSealer.instance.isDrawing == true)
        {
            //starts the functions of the game once you click anywhere on the screen
            CheckAccuracy();
            CheckSpeedPenalty();
        }


           //final score is calculated by adding up how many seals you have sealed
           //and subtracts points for moving too far from the seals 
           //also subtracts points for moving too fast
           //and subtracts even more points for losing points for too long

        
            if (WindowScript.instance != null && WindowScript.instance.gameFinished == true)
            {
                FinalScore = GetFinalScore();

                if (maxPossibleScore > 0f)
                {
                    finalPercentage = (FinalScore / maxPossibleScore) * 100f;
                }
                else
                {
                    finalPercentage = 0f;
                }

                finalTierPoints = CalculateTierPoints(finalPercentage);

                PlayerPrefs.SetFloat(scoreKey, finalTierPoints);
                PlayerPrefs.Save();

                if (accuracyText != null)
                {
                    accuracyText.text = "Accuracy: " + finalPercentage.ToString("F0") + "%";
                }

                if (finalscore != null)
                {
                    finalscore.text = "Energy Score Gained: " + finalTierPoints.ToString("F0");
                }

                Debug.Log("Final Score: " + FinalScore);
                Debug.Log("Percentage: " + finalPercentage);
                Debug.Log("Tier Points: " + finalTierPoints);

                WindowScript.instance.gameFinished = false;
            }
        if (currentScoreText != null)
        {
            float livePercentage = 0f;

            if (maxPossibleScore > 0f)
            {
                livePercentage = (CurrentScore / maxPossibleScore) * 100f;
                livePercentage = Mathf.Clamp(livePercentage, 0f, 100f);
            }

            currentScoreText.text = "Current Score: " + livePercentage.ToString("F2") + "%";
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
        //checks the distance from the mouse to any unsealed point and stores it
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
            CurrentScore += pointsPerSeal; 
        }
        //////////////////////////////////////////////////////////////////////
        if (unsealedPoints.Count == 0)
        {
            WindowScript.instance.FinishMinigame();
        }
    }

    public bool losingPoints = false;
    public void LosePointsForAccuracy()
    {   
        //loses points if you really far from a seal
        if (distanceToPoint > HighErrorMargin)
        {
            losingPoints = true;
            CurrentScore -= Time.deltaTime * HighPenaltyRate; 
            Debug.Log("<color=red>LOSING EVEN MORE POINTS!</color>");
            WindowScript.instance.timer -= Time.deltaTime * speedPointsLoss;
        }
        //loses points if you are somewhat far from a seal
        else if (distanceToPoint > LowErrorMargin)
        {
            losingPoints = true;
            CurrentScore -= Time.deltaTime * LowPenaltyRate; 
            Debug.Log("<color=red>LOSIKNG POINTS!</color>");
            WindowScript.instance.timer -= Time.deltaTime * speedPointsLoss;

        }
        //turns off the losing points variable if you are touching a seal
        else
        {
            losingPoints = false;
            timer = 0f;
        }
        //loses even more points you are losing points for too long
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
        //tracks where the mouse is relative to the world 
        Vector3 currentMousePos = Camera.main.ScreenToWorldPoint
        (new Vector3(Input.mousePosition.x, Input.mousePosition.y, 
        Math.Abs(Camera.main.transform.position.z - WindowPoints[0].position.z)));
        //calculates the speed of the mouse by checking how far it has moved since the last frame and dividing by time
        currentMouseSpeed = Vector3.Distance(currentMousePos, lastMousePosition) / Time.deltaTime;
    }
    void CheckSpeedPenalty()
    {
        //checks the speed and it goes above a #, you lose points
        if (currentMouseSpeed > maxSealSpeed)
        {
            CurrentScore -= Time.deltaTime * maxSpeedPenaltyRate;
            Debug.Log("SLOW DOWN! Moving too fast: " + currentMouseSpeed);
        }
    }
    public float GetFinalScore()
    {
        //returns 0 if there is no score at all, otherwise returns the current score
        float roundedScore = (float)(Math.Round(CurrentScore * 100f) / 100f);
        return Mathf.Max(0, roundedScore);
    }
    float CalculateTierPoints(float percentage)
    {
        if (percentage >= 100f)
        {
            return 15f;
        }
        else if (percentage >= 90f)
        {
            return 10f;
        }
        else
        {
            return 0f;
        }
    }



}
