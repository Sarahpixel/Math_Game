using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Problem
{
    public float numberOne;           // first number in the problem
    public float numberTwo;          // second number in the problem
    public MathsOperation operation;    // operator between the two numbers
    public float[] answers;             // array of all possible answers including the correct one
    [Range(0, 2)]
    public int correctTube;             // index of the correct tube
}

public enum MathsOperation
{
    Addition,
    Subtraction,
    Multiplication,
    Division
}