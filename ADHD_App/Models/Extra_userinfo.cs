namespace ADHD_App.Models
{
    public class Extra_userInfo
    {
        public int Id { get; set; } //Connect extra user info to the user id
        public int Currency { get; private set; }
        public List<string> profile_pictures { get; private set; }
        public string C_Profile_Picture { get; private set; }


        public Extra_userInfo(int id) {
            Id = id;
            //load the extra userinfo json and extra the info related to id
        }

        public bool Purchase(int amount)
        {
            if (amount >= 0 && amount >= Currency ) 
            {
                Currency -= amount;
                return true;
            }
            return false;
        }

        public bool changeProfilePicture(string new_profile) 
        {
            if (profile_pictures.Contains(new_profile)) 
            {
                C_Profile_Picture = new_profile;
                return true;
            }
            return false;
        }
    }
}
