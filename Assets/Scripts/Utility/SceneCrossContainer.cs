using UnityEngine;
using System.Collections;

public class SceneCrossContainer : MonoBehaviour {

    private static SceneCrossContainer _instance = null;
    public static SceneCrossContainer Instance
    {
        get { return _instance; }
    }

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;

        DontDestroyOnLoad(gameObject);
    }

}
