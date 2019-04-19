using UnityEngine;

namespace Poogle.UI
{
    public class UIScreen : MonoBehaviour
    {
        internal UIScreenInfo ScreenInfo;

        public bool IsOpen { get; set; }

        public virtual void UpdateScreenStatus(bool open)
        {
            IsOpen = open;
        }
    }
}