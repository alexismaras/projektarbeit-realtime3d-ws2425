using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] AudioSource uiClickSound;

    [SerializeField] AudioSource menuTheme;

    [SerializeField] float fadeDuration = 2f;
    public int next_scene;
    // Start is called before the first frame update
    void Start()
    {
        if (tag != "MainLevelSwitcher")
        {
            menuTheme.loop = true;
            menuTheme.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            uiClickSound.Play();
            if (tag != "MainLevelSwitcher")
            {
                StartCoroutine(FadeOutCoroutine());
            }
            ChangeScene();
        }
    }

    public void ChangeScene()
    {  
        animator.SetTrigger("FadeOut");
    }

    IEnumerator FadeOutCoroutine()
    {
        float startVolume = menuTheme.volume;
        float timer = 0f;

        // Gradually reduce the volume over fadeDuration seconds.
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            menuTheme.volume = Mathf.Lerp(startVolume, 0, timer / fadeDuration);
            yield return null;
        }

        menuTheme.volume = 0;
        menuTheme.Stop();

    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(next_scene);
    }
}
