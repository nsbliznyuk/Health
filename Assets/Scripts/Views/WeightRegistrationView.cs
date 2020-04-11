using Models;
using TMPro;
using UnityEngine;

namespace Views
{
    public class WeightRegistrationView : MonoBehaviour
    {
        public TMP_InputField weightInput;

        public void SetWeight()
        {
            // Получаем модель
            var userModel = new UserProfileModel();
            var serializedUserModel = PlayerPrefs.GetString("user_profile", JsonUtility.ToJson(new UserProfileModel()));
            userModel = JsonUtility.FromJson<UserProfileModel>(serializedUserModel);
            
            // Изменяем модель
            userModel.Weight = ushort.Parse(weightInput.text);
            userModel.RegistrationFinished = true;
            
            // Сохраняем модель
            serializedUserModel = JsonUtility.ToJson(userModel);
            PlayerPrefs.SetString("user_profile", serializedUserModel);
        }
    }
}