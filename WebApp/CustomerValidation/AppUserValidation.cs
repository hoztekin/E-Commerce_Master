using Microsoft.AspNetCore.Identity;

namespace WebApp.CustomerValidation
{
	public class AppUserValidation : IdentityErrorDescriber
	{
        public override IdentityError DuplicateEmail(string email)
        {
            return new IdentityError { Code = "MevcutEmail", Description = $"{email} Bu Mail Adresi Kayıtlı" };
        }

        public override IdentityError DuplicateUserName(string userName)
        {
            return new IdentityError { Code = "MevcutUserName", Description = $"{userName} Bu Kullanıcı Adı Kayıtlı" };
        }

        public override IdentityError InvalidEmail(string email)
        {
            return new IdentityError { Code = "MevcutEmail", Description = $"{email}Geçerli Mail Adresi Yazınız" };
        }

		//public override IdentityError PasswordRequiresNonAlphanumeric()
		//{
		//	return new IdentityError { Code = "Parola Hatası", Description = $"Parolanız Harf ve Rakamlardan Oluşmalıdır" };
		//}

	}
}
