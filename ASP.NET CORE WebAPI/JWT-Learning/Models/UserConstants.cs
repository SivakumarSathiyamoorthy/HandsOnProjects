namespace JWT_Learning.Models
{
    public class UserConstants
    {

        public static List<UserModel> Users = new List<UserModel>()
        {
            new UserModel() { UserName="siva", Password="123", EmailAddress="a@a.com", Role="AdminUser"},
            new UserModel() {UserName="kumar", Password="456", EmailAddress="b@b.com", Role="NormalUser"}
        };
    }
}
