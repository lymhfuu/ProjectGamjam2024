using System.Collections;
using UnityEngine;

namespace Assets.Script.UI
{
    public abstract class BasePanel : MonoBehaviour, IPanel
    {
        public abstract void InitPanel();
        public abstract void Show(IUiData uiData);
        public abstract void Refresh();
        public abstract void Close();
    }
}