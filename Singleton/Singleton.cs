using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SingletonGameObject<T> : MonoBehaviour where T : Component
{
    #region Static fields

    // Singleton public instance.
    public static T Instance;

    #endregion

    #region Serialized fields

    [Header("Singleton settings")]
    [SerializeField]
    private bool _createObjectIfNotInScene = false;

    [SerializeField]
    private bool _persistBetweenScenes = false;

    #endregion

    #region Non-serialized fields
    #endregion

    #region Unity events

    // Remember overriding and calling base.Awake() in
    // classes which extend this one.
    protected virtual void Awake() 
    {
        VerifySingletonPattern();
        CreateSingletonObject();
    }

    #endregion

    #region Public methods
    #endregion

    #region Private methods

    private void VerifySingletonPattern()
    {
        if (!Application.isPlaying)
            return;

        if (Instance != null)
        {
            string warning = "An additional singleton instance was created";
            warning += $" in {gameObject.name}. Destroying it now...";
            Debug.LogWarning(warning);
            Destroy(gameObject);
        }
        else
        {
            if (Instance == null)
                Instance = FindObjectOfType<T>();

            if (Instance == null)
                Instance = this as T;

            if (Instance == null)
            {
                Debug.LogWarning("Singleton object not found.");
            }
        }
    }

    private void CreateSingletonObject()
    {
        if (!_createObjectIfNotInScene)
            return;

        if (Instance != null)
            return;

        GameObject singletonObject = new GameObject();
        Instance = singletonObject.AddComponent<T>();
        Debug.Log("Singleton object created.");
    }

    private void MakeObjectPersistent()
    {
        if (!_persistBetweenScenes)
            return;

        if (Instance == null)
            return;

        DontDestroyOnLoad(gameObject);
    }

    #endregion    
}
