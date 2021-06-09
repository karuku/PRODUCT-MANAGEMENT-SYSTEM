using System;

namespace ProductManagerData.DTO
{
    [Serializable]
    public class LoginDTO
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string NewPassword { get; set; }

        public string ConfirmNewPassword { get; set; }

        public bool RememberMe { get; set; } 

        public string Token { get; set; }
    }

    [Serializable]
    public class ApiResponseModel
    {
        public int rCode { get; set; }

        public string message { get; set; }

        public dynamic rObj { get; set; } 
    }
}
