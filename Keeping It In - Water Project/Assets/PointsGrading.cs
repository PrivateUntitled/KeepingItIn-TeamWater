using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "GradingResults/Points")]
public class PointsGrading : ChoiceOption
{
    [System.Serializable]
    public struct NumberPoints
    {
        public string dialogue;
        public int requiredPoints;
        public LetterGrade ending;
    }

    public NumberPoints[] dialogueOptions;
}
