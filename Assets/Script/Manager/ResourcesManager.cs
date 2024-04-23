using System.Collections.Generic;
using UnityEngine;

namespace MainLogic.Manager
{
    public class ResourcesManager : MonoSingleton<ResourcesManager>
    {
        private static readonly Dictionary<string, GameObject> GameObjects = new Dictionary<string, GameObject>(30);
        private static readonly Dictionary<string, Sprite> Sprites = new Dictionary<string, Sprite>(50);
        private static readonly Dictionary<string, AudioClip> AudioClips = new Dictionary<string, AudioClip>(10);

        /// <summary>
        /// 读取文本文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="fileName">文件的相对路径</param>
        /// <returns>文本文件的内容</returns>
        public static string LoadText(string path, string fileName)
        {
            try
            {
                var textAsset = Resources.Load<TextAsset>(path + fileName);

                if (textAsset == null)
                {
                }

                return textAsset.text;
            }
            catch
            {
                Debug.LogError($"无法从路径：【{path}】加载文件：【{fileName}】");
                return null;
            }
        }

        /// <summary>
        /// 加载预制体
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="fileName">文件名</param>
        /// <returns></returns>
        public static GameObject LoadPrefab(string path, string fileName)
        {
            try
            {
                if (!GameObjects.ContainsKey(fileName))
                    GameObjects.Add(fileName, (GameObject)Resources.Load(path + fileName));
                return GameObjects[fileName];
            }
            catch
            {
                Debug.LogError($"无法从路径：【{path}】加载文件：【{fileName}】");
                throw;
            }
        }

        /// <summary>
        /// 加载图片
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="fileName">文件名</param>
        /// <returns></returns>
        public static Sprite LoadImage(string path, string fileName)
        {
            try
            {
                if (!Sprites.ContainsKey(path + fileName))
                    Sprites.Add(path + fileName, Resources.Load<Sprite>(path + fileName));
                return Sprites[path + fileName];
            }
            catch
            {
                Debug.LogError($"无法从路径：【{path}】加载文件：【{fileName}】");
                throw;
            }
        }

        /// <summary>
        /// 加载音频文件
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="fileName">文件名</param>
        /// <returns></returns>
        public static AudioClip LoadAudio(string path, string fileName)
        {
            try
            {
                if (!AudioClips.ContainsKey(fileName))
                    AudioClips.Add(fileName, Resources.Load<AudioClip>(path + fileName));
                return AudioClips[fileName];
            }
            catch
            {
                Debug.LogError($"无法从路径：【{path}】加载文件：【{fileName}】");
                throw;
            }
        }
    }
}