using UnityEngine;

namespace Poogle.UI
{
    public class UIScreen : MonoBehaviour
    {
        internal UIScreenInfo ScreenInfo;

        protected CanvasGroup m_CanvasGroup;
        public bool IsOpen { get; set; }

        public virtual void UpdateScreenStatus(bool open)
        {
            m_CanvasGroup.interactable = open;
            m_CanvasGroup.blocksRaycasts = open;
            IsOpen = open;
        }
    }
}