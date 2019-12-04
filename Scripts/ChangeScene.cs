using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void ChooseScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }

    public void switchToVuforia()
    {
        SceneManager.LoadScene("VuforiaScene", LoadSceneMode.Single);
    }

    public void switchToPlaceNote()
    {
        SceneManager.LoadSceneAsync("StickyNotes", LoadSceneMode.Single);
    }

    public void switchToPathfinding()
    {
        SceneManager.LoadSceneAsync("test2", LoadSceneMode.Single);
    }


    public void switchToTest()
    {
        SceneManager.LoadSceneAsync("test", LoadSceneMode.Single);
    }

    public void mergeScenes()
    {
        SceneManager.MergeScenes(SceneManager.GetSceneByName("VuforiaScene"), SceneManager.GetSceneByName("StickyNotes"));
    }

    public void onTouch()
    {
        switchToPlaceNote();
        SceneManager.UnloadSceneAsync("VuforiaScene");
    }
}
