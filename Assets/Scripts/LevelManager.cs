using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    public Slider progressBar;
    public GameObject transitionsContainer;
    public float fakeLoadDuration = 2f; // 2 segundos de duración

    private SceneTransition[] transitions;
    private bool isAnimatingBar;

    private void Awake()
    {
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

    private void Start()
    {
        transitions = transitionsContainer.GetComponentsInChildren<SceneTransition>();
    }

    public void LoadScene(string sceneName, string transitionName)
    {
        StartCoroutine(LoadSceneAsync(sceneName, transitionName));
    }

    private IEnumerator LoadSceneAsync(string sceneName, string transitionName)
    {
        SceneTransition transition = transitions.First(t => t.name == transitionName);

        AsyncOperation scene = SceneManager.LoadSceneAsync(sceneName);
        scene.allowSceneActivation = false;

        yield return transition.AnimateTransitionIn();

        progressBar.gameObject.SetActive(true);
        isAnimatingBar = true;

        StartCoroutine(AnimateProgressBar(scene));

        yield return new WaitForSeconds(fakeLoadDuration);

        scene.allowSceneActivation = true;
        isAnimatingBar = false;

        progressBar.gameObject.SetActive(false);

        yield return transition.AnimateTransitionOut();
    }

    private IEnumerator AnimateProgressBar(AsyncOperation scene)
    {
        float progress = 0f;

        while (isAnimatingBar)
        {
            // Simula la carga ajustada a 2 segundos
            progress += Time.deltaTime / fakeLoadDuration;
            progressBar.value = Mathf.Clamp01(progress);

            yield return null;
        }
    }
}

