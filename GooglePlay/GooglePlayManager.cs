using UnityEngine;
using UnityEngine.SocialPlatforms;

#if UNITY_ANDROID
using GooglePlayGames;
using GooglePlayGames.BasicApi;
#endif

namespace YoukaiFox.Tools.GooglePlay
{
    public class GooglePlayManager : SingletonGameObject<GooglePlayManager>
    {
        #if UNITY_ANDROID

        #region Serialized fields

        [SerializeField]
        private int _pageFriendCount = 5;

        [SerializeField]
        private bool _forceReloadOnFriendsLoad = true;

        #endregion

        #region Non-serialized fields

        private SignInStatus _signInStatus;

        #endregion

        #region Properties

        public SignInStatus CurrentSignInStatus => _signInStatus;

        #endregion

        #region Custom types
        #endregion

        #region Unity events

        private void Start() 
        {
            Initialize();
            DontDestroyOnLoad(gameObject);
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Run only once at the start of the game.
        /// </summary>
        public void Initialize()
        {
            PlayGamesPlatform.DebugLogEnabled = true;
            PlayGamesPlatform.Activate();
            PlayGamesPlatform.Instance.Authenticate(SignInInteractivity.CanPromptOnce, (result) => 
            {
                _signInStatus = result;
            });
        }

        /// <summary>
        /// Used for sign in button.
        /// </summary>
        /// <returns></returns>
        public SignInStatus SignIn()
        {
            PlayGamesPlatform.Instance.Authenticate(SignInInteractivity.CanPromptAlways, (result) => 
            {
                _signInStatus = result;
            });

            return _signInStatus;
        }

        /// <summary>
        /// Unlock achievement based on the id <paramref name="achievementId"/>.
        /// </summary>
        /// <param name="achievementId">ID shown on achievements option inside Google Play Console.</param>
        /// <returns></returns>
        public bool Achieve(string achievementId)
        {
            if (_signInStatus != SignInStatus.Success)
                return false;

            Social.LoadAchievements(achievements =>
            {
                bool found = false;
                int i = 0;

                while (!found && i < achievements.Length)
                {
                    if (achievements[i].id.Equals(achievementId) && !achievements[i].completed)
                    {
                        Social.ReportProgress(achievementId, 100.0f, (bool success) =>
                        {
                            if (success)
                                found = true;
                        });
                    }

                    i++;
                }
            });

            return true;
        }

        /// <summary>
        /// Unlock achievement based on the id <paramref name="achievementId"/> with
        /// a provided increment <paramref name="increment"/>.
        /// </summary>
        /// <param name="achievementId">ID shown on achievements option inside Google Play Console.</param>
        /// <param name="increment">Achievement's progression, ranging from 0 to 100.</param>
        /// <returns></returns>
        public bool AchieveIncremental(string achievementId, float increment)
        {
            if (_signInStatus != SignInStatus.Success)
                return false;

            Social.LoadAchievements(achievements =>
            {
                bool found = false;
                int i = 0;

                while (!found && i < achievements.Length)
                {
                    if (achievements[i].id.Equals(achievementId) && !achievements[i].completed)
                    {
                        Social.ReportProgress(achievementId, increment, (bool success) =>
                        {
                            if (success)
                                found = true;
                        });
                    }

                    i++;
                }
            });

            return true;
        }

        /// <summary>
        /// Calls the native UI listing the achievements present in the game.
        /// </summary>
        /// <returns>Returns true is successful.</returns>
        public bool ShowAchievements()
        {
            if (_signInStatus != SignInStatus.Success)
                return false;

            var success = true;

            try
            {
                Social.ShowAchievementsUI();
            }
            catch (System.Exception e)
            {
                success = false;
                Debug.LogError(e.Message);
                throw;
            }

            return success;
        }

        /// <summary>
        /// Calls the native leaderboards UI.
        /// </summary>
        /// <returns>Returns true is successful.</returns>
        public bool ShowLeaderboards()
        {
            if (_signInStatus != SignInStatus.Success)
                return false;

            var success = true;

            try
            {
                Social.ShowLeaderboardUI();
            }
            catch (System.Exception e)
            {
                success = false;
                Debug.LogError(e.Message);
                throw;
            }

            return success;
        }

        public IUserProfile[] ShowFriends()
        {
            if (!CheckShowFriendsPermission())
                return null;

            return ListFriends();
        }

        public IUserProfile[] ShowMoreFriends()
        {
            return ListMoreFriends();
        }

        #endregion

        #region Private methods

        private bool CheckShowFriendsPermission()
        {
            var permission = false;
            
            PlayGamesPlatform.Instance.GetFriendsListVisibility(_forceReloadOnFriendsLoad, (visibility) =>
            {
                if (visibility == FriendsListVisibilityStatus.Visible)
                    permission = true;
                else if (visibility == FriendsListVisibilityStatus.NotAuthorized)
                    permission = false;
            });

            if (permission)
                return true;

            return AskToLoadFriends();
        }

        private bool AskToLoadFriends()
        {
            var permission = false;

            PlayGamesPlatform.Instance.AskForLoadFriendsResolution((result) => 
            {
                if (result == UIStatus.Valid) 
                    permission = true;
                else 
                    permission = false;
            });

            return permission;
        }

        private IUserProfile[] ListFriends()
        {
            IUserProfile[] profiles = null;

            Social.localUser.LoadFriends((success) =>  
            {
                profiles = Social.localUser.friends;
            });

            return profiles;
        }

        private IUserProfile[] ListMoreFriends()
        {
            IUserProfile[] profiles = null;

            PlayGamesPlatform.Instance.LoadMoreFriends(_pageFriendCount, (status) =>
            {
                if (status == LoadFriendsStatus.LoadMore)
                {
                    throw new System.NotImplementedException();
                }
            });

            return profiles;
        } 

        #endregion

        #endif
    }
}
