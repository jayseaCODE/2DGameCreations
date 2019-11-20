using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

namespace Poogle.UI
{
    public class UIButton : Button
    {
        public override void OnPointerDown(UnityEngine.EventSystems.PointerEventData eventData)
        {
            if (IsActive() && IsInteractable())
            {
                //AudioManager.Singleton.PlayClickSound();
            }
            base.OnPointerDown(eventData);
        }
    }
}

