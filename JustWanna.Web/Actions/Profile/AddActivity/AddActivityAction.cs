using FubuMVC.Core.Ajax;
using JustWanna.Web.Infrastructure;

namespace JustWanna.Web.Actions.Profile.AddActivity
{
    public class ProfileAddActivityAction
    {
        public ProfileAddActivityModel Get(ProfileAddActivityRequest input)
        {
            return new ProfileAddActivityModel { UserId = input.UserId };
        }
        public AjaxContinuation Post(ProfileAddActivityModel input)
        {
            return AjaxContinuation.Successful();
        }
    }

    public class ProfileAddActivityRequest : ProfileAddActivityModel, IPartialModel
    {
    }

    public class ProfileAddActivityModel 
    {
        public string Name { get; set; }
        public string UserId { get; set; }
    }
}