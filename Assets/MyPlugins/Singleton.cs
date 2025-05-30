using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T m_Instance { get; private set; }

    public static T Instance
    {
        get
        {
            if (m_Instance == null)
                m_Instance = (T)FindObjectOfType(typeof(T), true);
            return m_Instance;
        }
    }

    protected virtual void Awake()
    {
        if (!Application.isPlaying)
            return;
        m_Instance = this as T;
    }
}
