using UnityEngine;

namespace Game.Extensions
{
    public static class TransformEx
    {
        /// <summary>
        /// 已知 父节点 parentTran；
        /// 子节点 name；
        /// 查找子节点 transform
        /// </summary>
        /// <param name="parentTran">查找范围父节点的Transform</param>
        /// <param name="name">查找元素所依附 GameObject Name</param>
        /// <returns></returns>
        public static Transform FindByName(this Transform parentTran, string name = "")
        {
            if (string.IsNullOrEmpty(name)) return null;
            var child = parentTran.Find(name);
            if (child != null) return child;
            for (int i = 0; i < parentTran.childCount; i++)
            {
                child = FindByName(parentTran.GetChild(i), name);
                if (child != null) break;
            }

            return child;
        }

        /// <summary>
        /// 已知 父节点 parentTran；
        /// 子节点 name；
        /// 查找子节点 transform
        /// <typeparam name="T">组件类型</typeparam>
        public static T FindByName<T>(this Transform parentTran, string name = "") where T : Component
        {
            if (string.IsNullOrEmpty(name))
            {
                var com = parentTran.GetComponent<T>();
                return com;
            }

            if (parentTran == null)
            {
                Debug.LogError("父物体为空");
                return null;
            }

            T child = null;
            var c = parentTran.Find(name);
            if (c != null)
            {
                child = c.FindByName<T>();
                if (child != null) return child;
            }

            for (int i = 0; i < parentTran.childCount; i++)
            {
                child = parentTran.GetChild(i).FindByName<T>(name);
                if (child != null)
                {
                    return child;
                }
            }

            return null;
        }

        /// <summary>
        /// 设置父节点的 active
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="active"></param>
        public static void SetActive(this Transform transform, bool active)
        {
            transform.gameObject.SetActive(active);
        }
    }
}