using System;

namespace Models
{
    [Serializable]
    public class UserProfileModel
    {
        public bool RegistrationFinished;
        public ushort Age;
        public ushort Height;
        public ushort Weight;
    }
}