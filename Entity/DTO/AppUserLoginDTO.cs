using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTO
{
	public class AppUserLoginDTO
	{
		
		[Required (ErrorMessage = "Kullanıcı Adı ile Giriş Zorunludur")]
		public string UserName { get; set; }

		[DataType(DataType.Password)]
		[Required (ErrorMessage = "Şifre Alanı zorunludur")]
		public string Password { get; set; }
	}
}
