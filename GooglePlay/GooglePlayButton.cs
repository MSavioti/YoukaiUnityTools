using UnityEngine;
using UnityEngine.UI;

namespace YoukaiFox.Tools.GooglePlay
{
    [RequireComponent(typeof(Button))]
    public class GooglePlayButton : MonoBehaviour
    {
        #if UNITY_ANDROID

        #region Serialized fields

        [SerializeField]
        private GooglePlayAction _action;

        #endregion

        #region Non-serialized fields

        private GooglePlayManager _manager;
        private Button _button;

        #endregion

        #region Custom types

        public enum GooglePlayAction
        {
            SignIn, ViewLeaderboard, ShowAchievements, ShowFriends
        }

        #endregion

        #region Unity events

        private void Awake() 
        {
            AssignComponents();
        }

        private void Start() 
        {
            _button.onClick.AddListener(CallOnClickAction);
        }

        #endregion

        #region Public methods
        #endregion

        #region Private methods

        private void AssignComponents()
        {
            _button = GetComponent<Button>();
            _manager = FindObjectOfType<GooglePlayManager>();

            if (!_manager)
            {
                Debug.LogError($"Unable to find an active instance of an object of type {typeof(GooglePlayManager)}.");
            }
        }

        private void CallOnClickAction()
        {
            switch (_action)
            {
                case GooglePlayAction.SignIn:
                    _manager.SignIn();
                    break;
                case GooglePlayAction.ViewLeaderboard:
                    _manager.ShowLeaderboards();
                    break;
                case GooglePlayAction.ShowAchievements:
                    _manager.ShowAchievements();
                    break;
                case GooglePlayAction.ShowFriends:
                    _manager.ShowFriends();
                    break;
                default:
                    throw new System.ArgumentOutOfRangeException();
            }
        }

        #endregion

        #endif
    }
}
