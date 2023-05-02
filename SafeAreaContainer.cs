using System;
using UnityEngine;
using UnityEngine.UIElements;
using Screen = UnityEngine.Device.Screen;

namespace YusufISIK.UI
{
    public class SafeAreaContainer : VisualElement
    {
        public new class UxmlFactory : UxmlFactory<SafeAreaContainer> {}
        
        public SafeAreaContainer()
        {
            style.flexGrow = 1;
            style.flexShrink = 1;
            RegisterCallback<GeometryChangedEvent>(LayoutChanged);
        }
        
        private void LayoutChanged(GeometryChangedEvent e)
        {
            var safeArea = Screen.safeArea;

            try
            {
                var leftTop = RuntimePanelUtils.ScreenToPanel(panel, new Vector2(safeArea.xMin, Screen.height - safeArea.yMax));
                var rightBottom = RuntimePanelUtils.ScreenToPanel(panel, new Vector2(Screen.width - safeArea.xMax, safeArea.yMin));
        
                style.paddingLeft  = leftTop.x;
                style.paddingTop = leftTop.y;
                style.paddingRight = rightBottom.x;
                style.paddingBottom = rightBottom.y;
            }
            catch (InvalidCastException) {}
        } 
    }
}