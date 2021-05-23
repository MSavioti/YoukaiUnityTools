using UnityEngine;
using UnityEngine.UI;

namespace YoukaiFox.Tools.GooglePlay
{
    [RequireComponent(typeof(Button))]
    public class GooglePlayLeaderboardsButton : GooglePlayButton
    {
#if UNITY_ANDROID

        #region Protected methods

        protected override void CallButtonAction()
        {
            ShowLeaderboards();
        }

        #endregion

        #region Private methods

        private void ShowLeaderboards()
        {
            base.Manager.ShowLeaderboards();
        }

        #endregion

#endif
    }
}
