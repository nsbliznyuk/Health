using Models;
using TMPro;
using UnityEngine;

namespace Views
{
    public class AgeRegistrationView : MonoBehaviour
    {

        public TMP_InputField ageInput;

        public void SetAge()
        {
            // Получаем модель
            var userModel = new UserProfileModel();
            var serializedUserModel = PlayerPrefs.GetString("user_profile", JsonUtility.ToJson(new UserProfileModel()));
            userModel = JsonUtility.FromJson<UserProfileModel>(serializedUserModel);
            
            // Изменяем модель
            userModel.Age = ushort.Parse(ageInput.text);
            
            // Сохраняем модель
            serializedUserModel = JsonUtility.ToJson(userModel);
            PlayerPrefs.SetString("user_profile", serializedUserModel);
        }
    }
}