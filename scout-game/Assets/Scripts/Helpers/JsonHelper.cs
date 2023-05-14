using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonHelper
{
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.items;
    }

    public static string ToJson<T>(T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.items = array;
        return JsonUtility.ToJson(wrapper);
    }

    public static string ToJson<T>(List<T> list)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.items = list.ToArray();
        return JsonUtility.ToJson(wrapper);
    }

    public static List<T> FromJsonToList<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return new List<T>(wrapper.items);
    }

    [System.Serializable]
    private class Wrapper<T>
    {
        public T[] items;
    }
}
