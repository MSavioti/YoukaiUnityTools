using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SingletonGameObject<T> : MonoBehaviour where T : Component
{
    #region Static fields

    // Singleton _instance.
    private static T _instance;
    
    #endregion

    #region Serialized fields

    [Header("Singleton settings")]
    [SerializeField]
    private bool _createObjectIfNotInScene = false;

    [SerializeField]
    private bool _persistBetweenScenes = false;

    #endregion

    #region Properties

    public static T Instance
    {
        get
        {
            if (_isQuitting)
                return null;

            return _instance;
        }
    }

    #endregion

    #region Non-serialized fields

    private static bool _isQuitting = false;
    #endregion

    #region Unity events

    // Remember overriding and calling base.Awake() in
    // classes which extend this one.
    protected virtual void Awake() 
    {
        VerifySingletonPattern();
        CreateSingletonObject();
    }

    private void OnApplicationQuit() 
    {
        _isQuitting = true;
    }

    #endregion

    #region Public methods
    #endregion

    #region Private methods

    private void VerifySingletonPattern()
    {
        if (!Application.isPlaying)
            return;

        if (_instance != null)
        {
            string warning = "An additional singleton _instance was created";
            warning += $" in {gameObject.name}. Destroying it now...";
            Debug.LogWarning(warning);
            Destroy(gameObject);
        }
        else
        {
            if (_instance == null)
                _instance = FindObjectOfType<T>();

            if (_instance == null)
                _instance = this as T;

            if (_instance == null)
            {
                Debug.LogWarning("Singleton object not found.");
            }
        }
    }

    private void CreateSingletonObject()
    {
        if (!_createObjectIfNotInScene)
            return;

        if (_instance != null)
            return;

        GameObject singletonObject = new GameObject();
        _instance = singletonObject.AddComponent<T>();
        Debug.Log("Singleton object created.");
    }

    private void MakeObjectPersistent()
    {
        if (!_persistBetweenScenes)
            return;

        if (_instance == null)
            return;

        DontDestroyOnLoad(gameObject);
    }

    #endregion    
}
