using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        internal static string CarAdded = "Araba eklendi";
        internal static string CarDeleted = "Araba silindi";
        internal static string CarUpdated = "Araba güncellendi";
        internal static string CarNameInvalid = "Ürün ismi geçersiz";
        internal static string CarsListed="Ürünler listelendi";
        internal static string MaintenanceTime="Sistem Bakımda";

        internal static string BrandAdded = "Marka eklendi";
        internal static string BrandNameInvalid = "Geçersiz Marka";
        internal static string BrandDeleted = "Marka Silindi";
        internal static string BrandUpdated = "Marka Silindi";
        internal static string BrandsListed = "Markalar Listelendi";

        internal static string ColorNameInvalid = "Renk tanımı geçersiz";
        internal static string ColorAdded = "Renk eklendi";
        internal static string ColorDeleted = "Renk silindi";
        internal static string ColorUpdated = "Renk güncellendi";
        internal static string ColorsListed = "Renkler Listelendi";

        internal static string UserAdded = "Kullanıcı Eklendi";
        internal static string UserDeleted = "Kullanıcı Silindi";
        internal static string UsersListed = "Kullanıcı Listelendi";
        internal static string UserUpdated = "Kullanıcı Güncellendi";

        internal static string RentalAdded = "Kiralama Eklendi";
        internal static string RentalDeleted = "Kiralama Silindi";
        internal static string RentalsListed = "Kiralama Listelendi";
        internal static string RentalUpdated = "Kiralama Güncellendi";

        internal static string CustomerAdded = "Müşteri Eklendi";
        internal static string CustomerDeleted = "Müşteri Silindi";
        internal static string CustomerUpdated = "Müşteri Güncellendi";
        internal static string CustomerListed = "Müşteriler Listelendi"

        public static string CarImageAdded="Resim Eklendi";
        public static string CarImageDeleted = "Resim Silindi";
        public static string CarImageUpdated = "Resim Güncellendi";
        public static string CarImagesListed = "Resimler Listelendi";
        public static string CarImageCountOfCarIdError = "En fazla 5 resim kaydedebilirsiniz";

        internal static string AuthorizationDenied="Yetkiniz Yok";

        internal static string UserOperationClaim = "Kullanıcının Bilgileri";

        public static string UserRegistered = "Kayıt Oldu";
        public static string UserNotFound = "Kullanıcı Bulunamadı";
        public static string PasswordError = "Parola Hatası";
        public static string SuccessfulLogin = "Başarılı Giriş";
        public static string UserAlreadyExists = "Kullanıcı Mevcut";
        public static string AccessTokenCreated = "Token oluşturuldu";
       
    }
}
 