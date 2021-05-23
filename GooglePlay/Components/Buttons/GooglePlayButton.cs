using UnityEngine;
using UnityEngine.UI;
using YoukaiFox.UnityExtensions;

namespace YoukaiFox.Tools.GooglePlay
{
    [RequireComponent(typeof(Button))]
    public abstract class GooglePlayButton : MonoBehaviour
    {
        #if UNITY_ANDROID

        #region Non-serialized fields

        private GooglePlayManager _manager;
        private Button _button;

        #endregion

        #region Accessors

        protected GooglePlayManager Manager { get; private set; }

        #endregion

        #region Unity events

        private void Awake() 
        {
            AssignComponents();
        }

        private void Start() 
        {
            _button.onClick.AddListener(CallButtonAction);
        }

        #endregion

        #region Private methods

        private void AssignComponents()
        {
            _button = gameObject.GetOrAddComponent<Button>();
            _manager = FindObjectOfType<GooglePlayManager>();

            if (!_manager)
            {
                Debug.LogError($"Unable to find an active instance of an object of type {typeof(GooglePlayManager)}.");
            }
        }

        protected abstract void CallButtonAction();

        #endregion

        #endif
    }
}
