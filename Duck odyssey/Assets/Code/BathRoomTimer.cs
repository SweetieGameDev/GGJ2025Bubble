using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BathRoomTimer : MonoBehaviour
{
    [SerializeField] string sceneName;

    public void Start()
    {
        StartCoroutine(DelayLongSceneChange());
    }

    private IEnumerator DelayLongSceneChange()
    {
        yield return new WaitForSeconds(15f);
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        Cursor.visible = false;
    }
}
