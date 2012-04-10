using JustWanna.Web.Models;

namespace JustWanna.Web.Actions.Profile
{
    public class ProfileIndexAction
    {

        public ProfileModel Get(ProfileRequest input)
        {

            return new ProfileModel
                       {
                           UserName = input.Slug,
                           UserId ="{123}",
                           Profile = "This is my profile"
                       };
        }

    }

    public class ProfileModel
    {
        public string UserName { get; set; }
        public string UserId { get; set; }
        public string Profile { get; set; }
    }

    public class ProfileRequest : IRequestBySlug
    {
        public string Slug { get; set; }
    }
}