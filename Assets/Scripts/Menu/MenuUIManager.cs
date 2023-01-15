using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif
[DefaultExecutionOrder(1000)]
public class MenuUIManager : MonoBehaviour
{
    [SerializeField] Text bestScoreText;
    public InputField nameInput;


    private void Start()
    {

        BetweenSceneDataManager.Instatance.LoadData();
        bestScoreText.text = BetweenSceneDataManager.Instatance.Name + " Best Score : " + BetweenSceneDataManager.Instatance.Score; ;
        nameInput.text = BetweenSceneDataManager.Instatance.Name;
       

    }



    public void startGame()
    {
        NameEntered();
        BetweenSceneDataManager.Instatance.session_Score = 0;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        BetweenSceneDataManager.Instatance.SaveData();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void NameEntered()
    {

        BetweenSceneDataManager.Instatance.session_user = nameInput.text;
    }
}
