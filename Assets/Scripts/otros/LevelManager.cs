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
    public float fakeLoadDuration = 2f; // 2 segundos de duraci�n

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
    public void LoadScene2(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName, ""));
    }

    private IEnumerator LoadSceneAsync(string sceneName, string transitionName)
    {
        // Verifica si hay una transici�n v�lida
        SceneTransition transition = transitions.FirstOrDefault(t => t.name == transitionName);

        // Si NO hay transici�n, carga la escena directamente
        if (string.IsNullOrEmpty(transitionName) || transition == null)
        {
            Debug.Log($"Cargando '{sceneName}' directamente, sin transici�n.");

            yield return SceneManager.LoadSceneAsync(sceneName);
            yield break; // Termina la corrutina aqu�
        }

        // Si hay transici�n, seguir con el flujo normal
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

