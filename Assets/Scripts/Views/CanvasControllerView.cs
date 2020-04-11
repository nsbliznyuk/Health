using DG.Tweening;
using UnityEngine;

namespace Views
{
   public class CanvasControllerView : MonoBehaviour
   {
   
      public CanvasGroup canvasGroup;
      public float duration;
   
      private void Awake()
      {
         gameObject.SetActive(false);
         canvasGroup.alpha = 0;
         canvasGroup.interactable = false;
         canvasGroup.blocksRaycasts = false;
      }
   

      public void Show()
      {
         gameObject.SetActive(true);
         canvasGroup.DOFade(1f, duration);
         canvasGroup.interactable = true;
         canvasGroup.blocksRaycasts = true;
         Debug.Log("Show "+ gameObject.name);
      }
   
      public void Hide()
      {
         canvasGroup.DOFade(0f, duration);
         canvasGroup.interactable = false;
         canvasGroup.blocksRaycasts = false;
         gameObject.SetActive(false);
         Debug.Log("Hide "+ gameObject.name);
      }
   }
}
