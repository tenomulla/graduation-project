using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingWebCore.Models
{
    public class UserSession
    {
        private static IHttpContextAccessor Accessor;
        public static UsersViewModel USession;
        public UserSession(IHttpContextAccessor _accessor)
        {
            Accessor = _accessor;
        }

        public static HttpContext User(UsersViewModel user)
        {
            HttpContext context = Accessor.HttpContext;
            context.Session.SetString("FullName", user.FullName);
            context.Session.SetString("UserType", user.UserType);
            context.Session.SetInt32("UserSessionId", user.Id);
            context.Session.SetString("UserName", user.UserName);
            USession.FullName = context.Session.GetString("FullName");
            USession.Id = Convert.ToInt32(context.Session.GetInt32("Id"));
            USession.UserName = context.Session.GetString("UserName");
            USession.UserType = context.Session.GetString("UserType");
            return context;
        }
    }
}
