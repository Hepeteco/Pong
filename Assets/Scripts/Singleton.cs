using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton <T> : MonoBehaviour where T: MonoBehaviour
{
    private static bool removed = false;
    private static object objLock = new object ();
    private static T _instance;
    public static T Instance
    {
        get
        {
            if(removed)
            {
                Debug.LogWarning("[Singleton] Instance '" + typeof(T) + "' already destroyed. Returning null.");
                return null;
            }
            lock(objLock)
            {
                if(_instance == null)
                {
                    _instance = (T)FindObjectOfType(typeof(T));

                    if(_instance == null)
                    {
                        var singletonObject = new GameObject();
                        _instance = singletonObject.AddComponent<T>();
                        singletonObject.name = typeof(T).ToString() + "(Singleton)";

                        DontDestroyOnLoad(singletonObject);
                    }
                }
                return _instance;
            }
        }
    }

    private void OnApplicationQuit()
    {
        removed = true;
    }

    private void OnDestroy()
    {
        removed = true;
    }
}
