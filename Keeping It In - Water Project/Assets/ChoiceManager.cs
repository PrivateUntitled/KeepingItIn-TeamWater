using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PointChoiceManager : MonoBehaviour
{
    [SerializeField] private GameObject UIPanel;
    [SerializeField] private GameObject choicePrefab;
    [SerializeField] private PointsGrading choiceScriptableObject;
    [SerializeField] private Transform choiceTransform;
    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private float textSpeed;
    //public int points;
    [SerializeField] private float timeTillChoiceAppears;
    public string nextRoom;

    private void Start()
    {
        UIPanel.SetActive(false);
        StartCoroutine(ShowChoiceTimer());
    }

    public void ShowChoice()
    {
        int choicesLoaded = 0;

        for (int i = 0; i < choiceScriptableObject.dialogueOptions.Length; i++)
        {
            if (choiceScriptableObject.dialogueOptions[i].requiredPoints <= GameManager.instance.points)
            {
                choicesLoaded++;
                GameObject choiceInst = Instantiate(choicePrefab, choiceTransform);
                choiceInst.GetComponent<Button>().onClick.AddListener(()=> { 
                    //GameManager.instance.grade.Add(choiceScriptableObject.dialogueOptions[i].ending); 
                    Cursor.visible = false; 
                    GameManager.instance.points = 0;
                    StartCoroutine(AdditiveSceneManager.instance.LoadAsyncScene(nextRoom));
                    StartCoroutine(AdditiveSceneManager.instance.RemoveAsyncScene());
                } );
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

        Cursor.visible = true;
        ShowChoice();
    }
}
