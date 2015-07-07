using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MovieReviewApp.Models;
using MovieReviewAPILibrary.DAL;
using MovieReviewAPILibrary;

namespace MovieReviewApp.Controllers
{
    public class DataServiceController : ApiController
    {

        [HttpPost]
        public HttpResponseMessage CreateUser(User user)
        {
            UserDataAccessLayer userDAL = new UserDataAccessLayer();
            var dynObj = new { result = userDAL.Create(user.Username, user.Pwd, user.Email) };
            HttpResponseMessage message = Request.CreateResponse(HttpStatusCode.OK, dynObj);
            return message;
        }

        [HttpGet]
        public User GetUserInfo(string username, string pwd)
        {
            UserDataAccessLayer userDAL = new UserDataAccessLayer();
            return userDAL.GetUserInfo(username, pwd);
        }
    }
}
