using UnityEngine;
using Game.System;
using Game.UI;
using System.Collections.Generic;
using System;

namespace Managers
{
    class UIElement
    {
        public GameObject instance;
        public string ResourcePath;
    }
    static class UIManager
    {
        const string UIPath = "Prefab/UI/";
        static Dictionary<Type, UIElement> UIResources = new Dictionary<Type, UIElement>();

        //////////////////////////·������ӵ�������prefab�����Ʊ���һ��/////////////////////
        static UIManager()
        {
            UIResources[typeof(DemoUI)] = new UIElement { ResourcePath = UIPath + "DemoUI" };
        }

        public static T Show<T>() where T : BasePanel
        {
            Type type = typeof(T);
            if (!UIResources.ContainsKey(type))
            {
                Debug.LogError("Show:" + type + "û����UIManager��ע��");
                return default;
            }
            UIElement element = UIResources[type];

            if (element.instance == null)//��һ�μ���
            {
                GameObject prefab = Resources.Load(element.ResourcePath) as GameObject;
                if (prefab == null)
                {
                    Debug.LogError(element.ResourcePath + " û���ҵ���ӦԤ����");
                    return default;
                }
                element.instance = GameObject.Instantiate(prefab);
                (element.instance.GetComponent<T>() as BasePanel).InitPanel();
                (element.instance.GetComponent<T>() as BasePanel).Refresh();
                return element.instance.GetComponent<T>();
            }
            else //OnEnable
            {
                element.instance.SetActive(true);
                (element.instance.GetComponent<T>() as BasePanel).Refresh();
                return element.instance.GetComponent<T>();
            }
        }

        public static void Close<T>() where T : BasePanel
        {
            if (!UIResources.ContainsKey(typeof(T)))
            {
                Debug.Log("Close:" + typeof(T) + " û����UIManagerע��");
                return;
            }
            UIResources[typeof(T)].instance.SetActive(false);
        }

        public static T Get<T>() where T : BasePanel
        {
            if (!UIResources.ContainsKey(typeof(T)))
            {
                Debug.LogError("Close:" + typeof(T) + " û����UIManagerע��");
                return default;
            }
            if (UIResources[typeof(T)].instance == null)
            {
                Debug.LogError("Close:" + typeof(T) + " û�г�ʼ��");
                return default;
            }
            return UIResources[typeof(T)].instance.GetComponent<T>();
        }
    }
}