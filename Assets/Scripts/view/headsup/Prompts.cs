using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.view.headsup
{
    public class Prompts : MonoBehaviour
    {
        public GameObject PromptPrefab;

        private Text _prompt;

        public void ShowPrompt(string promo, float duration)
        {
            var promptPrefab = Instantiate(PromptPrefab);
            promptPrefab.GetComponent<RectTransform>().SetParent(gameObject.GetComponent<RectTransform>(), false);
            _prompt = promptPrefab.GetComponent<Text>();
            _prompt.text = promo;

            var hideDuration = float.IsNaN(duration) ? 3 : duration;

            DOVirtual.DelayedCall(hideDuration, delayedHide);
        }

        private void delayedHide()
        {
            Destroy(_prompt);
        }
    }
}
