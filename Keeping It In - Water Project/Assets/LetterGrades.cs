using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LetterGrade
{
    A,
    B,
    C,
    NONE
}

[System.Serializable]
public struct LetterPoints
{
    public string dialogue;
    public LetterCondition[] conditions;
}

[System.Serializable]
public struct LetterCondition
{
    public Condition[] condition;
}

[System.Serializable]
public struct Condition
{
    public int amount;
    public LetterGrade letterGrade;
}

[CreateAssetMenu(fileName = "Data", menuName = "GradingResults/LetterGrades")]
public class LetterGrades : ChoiceOption
{
    public LetterPoints[] dialogueOptions;
}
