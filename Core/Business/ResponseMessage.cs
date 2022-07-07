using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business
{
	public static class ResponseMessage
	{
		public static string Add { get; } = "Ekleme işlemi başarılı";
		public static string Delete { get; } = "Silme işlemi başarılı";
		public static string Update { get; } = "Güncelleme işlemi başarılı";

		public static string DeleteWarning { get; } = "Silme işlemi başarısız";
		public static string AddWarning { get; } = "Ekleme işlemi başarısız";
		public static string UpdateWarning { get; } = "Güncelleme işlemi başarısız";

		public static string SearchSucces { get; } = "Aranan veri bulunmuştur";
		public static string SearchWarning { get; } = "Aranan veri bulunamamıştır";

		public static string ProductAdd { get; } = "Ürün yükleme işlemi başarılı";
		public static string ProductAddWarning { get; } = "Ürün yükleme işlemi başarısız";
	}
}
