using UnityEngine;
using UnityEngine.UI;

namespace YoukaiFox.Tools.GooglePlay
{
    [RequireComponent(typeof(Button))]
    public class GooglePlaySignInButton : GooglePlayButton
    {
#if UNITY_ANDROID

        #region Protected methods

        protected override void CallButtonAction()
        {
            SignIn();
        }

        #endregion

        #region Private methods

        private void SignIn()
        {
            base.Manager.SignIn();
        }

        #endregion

#endif
    }
}
