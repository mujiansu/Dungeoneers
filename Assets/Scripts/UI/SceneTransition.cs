using System.Collections;
using Dungeoneer.Ui.InGame;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using static Dungeoneer.Managers.SceneChangingManager;

namespace Dungeoneer.Ui
{
    public class SceneTransition : MonoBehaviour
    {

        private Image _image;
        private const float SceneTransitionTime = 1000;
        private float _fadeDeltaTime = 0f;

        private Coroutine _couroutine;

        private SignalBus _signalBus;

        [Inject]
        public void Constructor(SignalBus signalBus)
        {
            _signalBus = signalBus;
            _signalBus.Subscribe<SceneTransitionSignal>(OnSceneTransitionSignal);
        }

        private void OnSceneTransitionSignal(SceneTransitionSignal signal)
        {
            if (_couroutine != null)
            {
                StopCoroutine(_couroutine);
            }
            transform.gameObject.SetActive(true);
            StartCoroutine(nameof(FadeOut));
        }

        private void Awake()
        {
            _image = GetComponentInChildren<Image>();
        }

        private void Start()
        {
            if (_couroutine != null)
            {
                StopCoroutine(_couroutine);
            }
            StartCoroutine(nameof(FadeIn));
        }

        private IEnumerator FadeIn()
        {
            _fadeDeltaTime = 0f;
            var color = _image.color;
            var alpha = color.a;
            var startingAlpha = color.a;
            while (alpha > 0)
            {
                _fadeDeltaTime += Time.deltaTime * 1000f;
                alpha = Mathf.Lerp(startingAlpha, 0, _fadeDeltaTime / SceneTransitionTime);
                color.a = alpha;
                _image.color = color;
                yield return null;
            }
            transform.gameObject.SetActive(false);
            _signalBus.Fire<CanvasController.EnableMenuSignal>();
        }

        private IEnumerator FadeOut()
        {
            _signalBus.Fire<CanvasController.DisableMenuSignal>();
            _fadeDeltaTime = 0f;
            var color = _image.color;
            var alpha = color.a;
            var startingAlpha = color.a;
            while (alpha < 1)
            {
                _fadeDeltaTime += Time.deltaTime * 1000f;
                alpha = Mathf.Lerp(startingAlpha, 1, _fadeDeltaTime / SceneTransitionTime);
                color.a = alpha;
                _image.color = color;
                yield return null;
            }

        }
    }
}

