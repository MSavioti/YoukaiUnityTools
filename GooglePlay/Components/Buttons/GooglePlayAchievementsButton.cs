using UnityEngine;
using UnityEngine.UI;

namespace YoukaiFox.Tools.GooglePlay
{
    [RequireComponent(typeof(Button))]
    public class GooglePlayAchievementsButton : GooglePlayButton
    {
#if UNITY_ANDROID

        #region Protected methods

        protected override void CallButtonAction()
        {
            ShowAchievements();
        }

        #endregion

        #region Private methods

        private void ShowAchievements()
        {
            GooglePlayManager.Instance.ShowAchievements();
        }

        #endregion

#endif
    }
}
