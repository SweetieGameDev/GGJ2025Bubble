using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] string sceneName;
    public void LoadScene()
    {
        StartCoroutine(DelaySceneChange());
    }

    private IEnumerator DelaySceneChange()
    {
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        Cursor.visible = false;
    }

}
