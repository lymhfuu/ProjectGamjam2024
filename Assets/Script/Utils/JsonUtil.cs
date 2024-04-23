using System;
using Game;
using Newtonsoft.Json;
using UnityEngine;

namespace Game.Util
{
    public static class JsonUtil
    {
        public static string ToJson(object dataClass)
        {
            try
            {
                if (dataClass != null)
                    return JsonConvert.SerializeObject(dataClass);
                else
                {

                    Debug.LogError($"【E】类为空,无法序列化");
                }
            }
            catch (Exception e)
            {
                // ignored
                Debug.LogError($"【E】类序列化出错：「{e.Message}」");
            }

            return "";
        }

        public static T ToObject<T>(string json)
        {
            try
            {
                if (!string.IsNullOrEmpty(json))
                {
                    return JsonConvert.DeserializeObject<T>(json);
                }
                else
                {
                    Debug.LogError($"【E】json为空反序列化啥呀");
                }
            }
            catch (Exception e)
            {
                // ignored
                Debug.LogError($"【E】json反序列化出错：「{e.Message}」");
            }

            return default;
        }
    }
}