using Microsoft.AspNetCore.Identity;

namespace OnlineEdu.WebUI.Validators
{
    public class CustomErrorDescriber : IdentityErrorDescriber
    {
        public override IdentityError PasswordRequiresDigit()
        {
            return new IdentityError
            {
                Description = "Şifre en az 1 rakam içermelidir"
            };
        }

        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError
            {
                Description = "Şifre en az 1 kücük karakter içermelidir."
            };
        }
        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new IdentityError
            {
                Description = "Şifre en az 1 özel karakter (,.-/*-+...) içermelidir"
            };
        }

        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError
            {
                Description = $"Şifre en az {length} karakter olmalıdır."
            };
        }
        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError
            {
                Description = "Şifre en az 1 büyük karakter (A-Z) içermelidir."
            };
        }
        public override IdentityError DuplicateUserName(string userName)
        {
            return new IdentityError
            {
                Description = $"Bu {userName} kullanıcı adı zaten kullanılmaktadır."
            };
        }



    }
}
