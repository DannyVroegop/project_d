using System.Collections;

namespace ADHD_App.Models
{
    public class Extra_userinfo
    {
        public int Id { get; set; } //Connect extra user info to the user id
        public string ProfilePicture { get; set; }
        public string[] unlockedImages { get; set; }


        public bool changeProfilePicture(string new_profile) 
        {
            if (unlockedImages.Contains(new_profile)) 
            {
                ProfilePicture = new_profile;
                return true;
            }
            return false;
        }
    }
}
