using System;
using System.Collections.Generic;
using Game.Model;
using Game.System;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

namespace Game
{
    public class GameBody : MonoBehaviour
    {
        private static Dictionary<Type, object> _systems = new Dictionary<Type, object>();
        private static Dictionary<Type, object> _models = new Dictionary<Type, object>();

        private void Awake()
        {

            RegisterModels();
            RegisterSystems();

            InitModels();
            InitSystems();
        }

        private void RegisterSystems()
        {
            RegisterSystem(new MapSystem());
            RegisterSystem(new InventorySystem());//�ϳ����ݴ���ӿ�
        }

        private void RegisterModels()
        {
            RegisterModel(new MapModel());
            RegisterModel(new CompoundModel());//�ϳ��䷽Json(CompoundData)
        }

        private void InitSystems()
        {
            GameObject go = new GameObject("EventSystemSingle", typeof(EventSystem));
            go.transform.parent = transform;

            foreach (KeyValuePair<Type, object> item in GameBody._systems)
            {
                if (item.Value is ISystem system)
                {
                    system.InitSystem();
                }
            }
        }
        private void InitModels()
        {
            foreach (KeyValuePair<Type, object> item in GameBody._models)
            {
                if (item.Value is IModel model)
                {
                    model.InitModel();
                }
            }
        }

        private void RegisterSystem(ISystem system)
        {
            if (!_systems.ContainsKey(system.GetType()))
            {
                _systems.Add(system.GetType(), system);
            }
            else { return; }
        }

        private void RegisterModel(IModel model)
        {
            if (!_models.ContainsKey(model.GetType()))
            {
                _models.Add(model.GetType(), model);
            }
            else { return; }
        }

        public static T GetSystem<T>() where T : class, ISystem
        {
            Type t = typeof(T);
            if (_systems.ContainsKey(t))
            {
                return _systems[t] as T;
            }
            return default;
        }

        public static T GetModel<T>() where T : class, IModel
        {
            Type t = typeof(T);
            if (_models.ContainsKey(t))
            {
                return _models[t] as T;
            }
            return default;
        }

        private void Start()
        {

        }
    }
}