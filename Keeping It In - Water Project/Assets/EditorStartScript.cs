using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

public class Example : MonoBehaviour
{
    // Create a new drop-down menu in Editor named "Examples" and a new option called "Open Scene"
    [MenuItem("Examples/Open Scene")]
    static void OpenScene()
    {
        //Open the Scene in the Editor (do not enter Play Mode)
        //UnityEngine.SceneManagement.LoadSceneParameters(UnityEngine.SceneManagement.LoadSceneMode.Additive);
        //EditorSceneManager.LoadSceneAsyncInPlayMode("Assets/HeartRoom/HeartRoom.unity", );
    }
}