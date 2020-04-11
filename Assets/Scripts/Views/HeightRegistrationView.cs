using Models;
using TMPro;
using UnityEngine;

namespace Views
{
    public class HeightRegistrationView : MonoBehaviour
    {
        public TMP_InputField heightInput;

        public void SetHeight()
        {
            // Получаем модель
            var userModel = new UserProfileModel();
            var serializedUserModel = PlayerPrefs.GetString("user_profile", JsonUtility.ToJson(new UserProfileModel()));
            userModel = JsonUtility.FromJson<UserProfileModel>(serializedUserModel);
            
            // Изменяем модель
            userModel.Height = ushort.Parse(heightInput.text);
            
            // Сохраняем модель
            serializedUserModel = JsonUtility.ToJson(userModel);
            PlayerPrefs.SetString("user_profile", serializedUserModel);
        }
    }
}