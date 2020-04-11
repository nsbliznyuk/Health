using Models;
using UnityEngine;

namespace Views
{
    public class InitializationView : MonoBehaviour
    {
        public CanvasControllerView RegistartionScreen;
        public CanvasControllerView ChallengesScreen;
        
        private void Start()
        {
            var userModel = new UserProfileModel();
            var serializedUserModel = PlayerPrefs.GetString("user_profile", JsonUtility.ToJson(new UserProfileModel()));
            userModel = JsonUtility.FromJson<UserProfileModel>(serializedUserModel);


            if (userModel.RegistrationFinished)
            {
                // Открываем 4 окно
                RegistartionScreen.Hide();
                ChallengesScreen.Show();
            }
            else
            {
                // Открываем окно регистрации
                RegistartionScreen.Show();
                ChallengesScreen.Hide();
            }
        }

        private void OnDestroy()
        {
            Debug.Log("Initializtion Destroy");
        }
    }
}