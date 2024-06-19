namespace Asmin.Entities.CustomEntities.Request.User
{
    public class UserLoginRequest
    {
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Password, plain text.
        /// </summary>
        public string Password { get; set; }
    }
}
