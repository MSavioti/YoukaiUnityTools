using UnityEngine;

namespace YoukaiFox.Tools.GooglePlay
{
    public class GooglePlayAchieveOnEnable : MonoBehaviour
    {
#if UNITY_ANDROID
        [SerializeField]
        [Tooltip("Achievement ID shown in Google Play console.")]
        private string _achievementId;

        [SerializeField]
        [Tooltip("Achievement increment, which ranges from 0 to 100.")]
        private float _increment;

        private void OnEnable() 
        {
            if (_increment < 100)
                GooglePlayManager.Instance.AchieveIncremental(_achievementId, _increment);
            else
                GooglePlayManager.Instance.Achieve(_achievementId);
        }
#endif
    }
}
