using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    protected static bool ShuttingDown;
    static T instance;

    public static T Instance
    {
        get
        {
            if (ShuttingDown) return null;

            // Find from world if null
            if (instance == null) instance = (T)FindFirstObjectByType(typeof(T), FindObjectsInactive.Include);

            // Create instance if instance doesn't exist
            if (instance == null)
            {
                GameObject temp = new(typeof(T) + "Instance");
                instance = temp.AddComponent<T>();
                DontDestroyOnLoad(instance.gameObject);
            }

            return instance;
        }
    }

    public void Init() { }

    void OnDestroy()
    {
        if (instance == this)
        {
            OnCleanUp();
            instance = null;
        }
    }

    protected virtual void OnCleanUp() { }

    void OnApplicationQuit()
    {
        ShuttingDown = true;
    }
}
