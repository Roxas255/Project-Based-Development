using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScript : MonoBehaviour
{
    public Animator SceneFadeAnimator;
    public static SceneScript Instance;
    void Start()
    {
        //Animator SceneFadeAnimator = GetComponent<Animator>();
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void ChangeScene (string sceneName)
    {
        StartCoroutine(LoadScene(sceneName));
    }
    IEnumerator LoadScene(string sceneName)
    {
        SceneFadeAnimator.SetTrigger("FadeOut");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);
    }

    internal void LoadScene(object sceneName)
    {
        throw new NotImplementedException();
    }
}
