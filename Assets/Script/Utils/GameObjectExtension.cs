using Game.Extensions;
using UnityEngine;

namespace Game.Extensions
{
    public static class GameObjectExtension
    {
        /// <summary>
        /// 已知 父节点 gameObject； 子节点 name；
        /// 查找 子节点 的 某一组件
        /// </summary>
        /// <param name="parent"> 父节点 gameObject</param>
        /// <param name="name">子节点名称</param>
        /// <typeparam name="T">组件类型</typeparam>
        /// <returns>返回组件</returns>
        public static T FindByNameInParent<T>(this GameObject parent, string name = "") where T : Component
        {
            return parent.transform.FindByName<T>(name);
        }

        /// <summary>
        /// 已知 父节点 gameObject； 子节点 name；
        /// 查找子节点 transform
        /// </summary>
        /// <param name="parent">父节点 gameObject</param>
        /// <param name="name"></param>
        /// <returns>子节点 transform</returns>
        public static Transform FindByNameInParent(this GameObject parent, string name = "")
        {
            return parent.transform.FindByName(name);
        }
    }
}