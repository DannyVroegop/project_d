using System.Text.Json;
using System.Text.Json.Serialization;

namespace ADHD_App.Models
{
    public class Extra_userinfo
    {
        public int Id { get; private set; }
        public string[] unlockedImages { get; private set; }
        public string ProfilePicture { get; private set; }

        //public Extra_userinfo(int ID, string[] images, string profilepicture)
        //{
        //    id = ID;
        //    unlockedImages = images;
        //    ProfilePicture = profilepicture;
        //}

        public void changePicture(string picture)
        {
            if (unlockedImages.Contains(picture))
            {
                ProfilePicture = picture;
            }
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize<Extra_userinfo>(this);
        }
    }
}
