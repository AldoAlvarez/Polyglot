using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SingletonObject<T> : MonoBehaviour where T: Behaviour
{
    private void Start()
    {
        
    }

    protected static T instance;
    public static T Instance { get { SetInstance(); return instance; } }

    private static void SetInstance() 
    {
        if (instance != null) return;
        instance = GetInstance<T>("");       
    }

    private static T GetInstance<T>(string objectName) where T : Behaviour
    {
        T[] sceneObjects = GameObject.FindObjectsOfType<T>();
        if (sceneObjects == null || sceneObjects.Length <= 0)
            return GetNewObjectInstance<T>(objectName);
        else
            return GetActiveObjectInstance<T>(sceneObjects);
    }
    private static T GetNewObjectInstance<T>(string name) where T : Behaviour
    {
        return new GameObject(name).AddComponent<T>();
    }

    private static T GetActiveObjectInstance<T>(T[] objects) where T : Behaviour
    {
        T activeObject = null;
        for (int obj = 0; obj < objects.Length; ++obj)
        {
            if (activeObject != null)
                objects[obj].enabled = false;
            else if (objects[obj].enabled)
                activeObject = objects[obj];
        }

        if (activeObject == null)
        {
            objects[0].enabled = true;
            activeObject = objects[0];
        }
        return activeObject;
    }
}
