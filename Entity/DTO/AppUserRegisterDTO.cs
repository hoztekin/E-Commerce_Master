using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTO
{
	public class AppUserRegisterDTO
	{
		[Required(ErrorMessage ="E-Mail Adresi Zorunludur")]
		[DisplayName ("E-Posta")]
		[DataType(DataType.EmailAddress, ErrorMessage = "Geçerli Mail Adresi Yazınız!")]
		public string EMail { get; set; }



		[DataType(DataType.PhoneNumber)]
		[DisplayName ("Telefon")]
		public string Phone { get; set; }


		[Required(ErrorMessage ="Kullanıcı Adı Zorunludur")]
		[DisplayName("Kullanıcı Adı")]
		public string UserName { get; set; }



		[DataType(DataType.Password)]
		[Required(ErrorMessage ="Şifre Zorunludur")]
		public string Password { get; set; }



		[DataType(DataType.Password)]
		[Required(ErrorMessage = "Şifre Tekrarı Zorunludur")]
		[Compare("Password")]
		public string ConfirmPassword { get; set; }
	}
}
