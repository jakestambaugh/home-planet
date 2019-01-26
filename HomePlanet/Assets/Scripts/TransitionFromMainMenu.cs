using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionFromMainMenu : MonoBehaviour
{
    public Animator anim;
    private AsyncOperation asyncLoader;
    private bool doneWithFade; // Need this because I am terrible at Unity and am too lazy to trigger


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadSceneInBackgroundThingy());
        doneWithFade = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKey)
            anim.Play("FadeRingAnim");

        // Animation done, let's go to the game level
        if(doneWithFade)
            asyncLoader.allowSceneActivation = true;
    }

    // Load stuff behind the scenes
    private IEnumerator LoadSceneInBackgroundThingy()
    {
        asyncLoader = SceneManager.LoadSceneAsync(1);
        asyncLoader.allowSceneActivation = false;
        yield return asyncLoader;
    }

    public void DoneWithFade()
    {
        doneWithFade = true;
    }
}
