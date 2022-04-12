using System;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using Object = UnityEngine.Object;

namespace EventValue_Example.Scripts.Util
{
    public static class Extensions
    {
        public static T FindOrNull<T>(this MonoBehaviour monoBehaviour) where T : class =>
            Object.FindObjectsOfType<MonoBehaviour>().FirstOrDefault(b => b is T) as T;

        public static T FindOrException<T>(this MonoBehaviour monoBehaviour) where T : class =>
            Object.FindObjectsOfType<MonoBehaviour>().FirstOrDefault(b => b is T) as T
            ?? throw new NullReferenceException($"Object of type {typeof(T).Name} not found");

        public static T GetOrException<T>(this GameObject gameObject) where T : class =>
            gameObject.GetComponents<MonoBehaviour>().FirstOrDefault(b => b is T) as T
            ?? throw new NullReferenceException($"Object of type {typeof(T).Name} not found");

        public static T GetOrException<T>(this MonoBehaviour monoBehaviour) where T : class =>
            GetOrException<T>(monoBehaviour.gameObject);

        public static T[] FindMultiple<T>(this MonoBehaviour monoBehaviour) where T : class =>
            Object.FindObjectsOfType<MonoBehaviour>().OfType<T>().ToArray();

        public static T[] GetMultipleInChildren<T>(this MonoBehaviour monoBehaviour) where T : class =>
            monoBehaviour.GetComponentsInChildren<MonoBehaviour>().OfType<T>().ToArray();

        public static Task Await(this float seconds) => Task.Delay(TimeSpan.FromSeconds(seconds));

        public static Vector2 FlatVector(this Vector3 vector3) => new Vector2(vector3.x, vector3.z);

        public static Vector3 VolumeVector(this Vector2 vector3) => new Vector3(vector3.x, 0, vector3.y);
    }
}