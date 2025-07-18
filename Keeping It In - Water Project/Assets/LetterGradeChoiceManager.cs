using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LetterGradeChoiceManager : MonoBehaviour
{
    [SerializeField] private GameObject UIPanel;
    [SerializeField] private GameObject choicePrefab;
    [SerializeField] private LetterGrades choiceScriptableObject;
    [SerializeField] private Transform choiceTransform;
    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private float textSpeed;
    public LetterCondition points;
    [SerializeField] private float timeTillChoiceAppears;

    private void Start()
    {
        UIPanel.SetActive(false);
        StartCoroutine(ShowChoiceTimer());
    }

    private bool Pass(LetterCondition[] letterAr)
    {
        foreach (LetterCondition letter in letterAr)
        {
            foreach (Condition point in letter.condition)
            {
                int amt = 0;
                foreach (Condition thing in points.condition)
                {
                    if (point.letterGrade == thing.letterGrade)
                    {
                        amt = thing.amount;
                    }
                }

                if (point.amount > amt)
                {
                    return false;
                }
            }
        }

        return true;
    }

    public void ShowChoice()
    {
        int choicesLoaded = 0;

        for (int i = 0; i < choiceScriptableObject.dialogueOptions.Length; i++)
        {
            if (Pass(choiceScriptableObject.dialogueOptions[i].conditions))
            {
                choicesLoaded++;
                GameObject choiceInst = Instantiate(choicePrefab, choiceTransform);
                //choiceInst.GetComponent<Button>().onClick.AddListener(() => { SceneManager.LoadScene("HeartRoom 2"); });
                choiceInst.GetComponentInChildren<TextMeshProUGUI>().text = choiceScriptableObject.dialogueOptions[i].dialogue;

                //SceneManager.LoadScene("HeartRoom");
            }
        }

        //code fucked
        //if(choicesLoaded == 0)
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private IEnumerator ShowChoiceTimer()
    {
        yield return new WaitForSeconds(timeTillChoiceAppears);

        questionText.text = "";

        UIPanel.SetActive(true);

        int currentDialogueIndex = 0;

        // Typewriter effect based on text speed.
        while (questionText.text != choiceScriptableObject.question)
        {
            questionText.text += choiceScriptableObject.question[currentDialogueIndex];
            currentDialogueIndex++;
            yield return new WaitForSecondsRealtime(textSpeed);
        }

        ShowChoice();
    }
}
