using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class PointController : MonoBehaviour
{
    [HideInInspector]
    public float Points = 0;
    public List<Target> Target;
    public Text PointText;
    void Start()
    {
        foreach (var target in Target)
        {
            target.OnTargetDown += AddPoints;
        }
    }

    void Update()
    {
        
    }

    void AddPoints(float points)
    {
        Points += points;
        PointText.text = Points.ToString();
        Debug.Log("Current.points = " + Points);
    }
}
