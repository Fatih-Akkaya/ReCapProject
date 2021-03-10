using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araç eklendi";
        public static string CarNameInvalid = "Araç ismi geçersiz";
        public static string CarPriceInvalid = "Araç fiyatı geçersiz";
        public static string CarsListed = "Araçlar Listelendi";
        public static string CarDeleted = "Araç silindi";
        public static string CarUpdated = "Araçlar güncellendi";
        public static string MaintenanceTime = "Sistemimiz şu anda bakımdadır.";
        
        public static string BrandAdded = "Marka eklendi";
        public static string BrandDeleted = "Marka silindi";
        public static string BrandsListed = "Markalar Listelendi";
        public static string BrandUpdated = "Marka güncellendi";

        public static string ColorAdded = "Renk eklendi";
        public static string ColorDeleted = "Renk silindi";
        public static string ColorsListed = "Renkler Listelendi";
        public static string ColorUpdated = "Renk güncellendi";

        public static string UserAdded = "Kullanıcı eklendi";
        public static string UserDeleted = "Kullanıcı silindi";
        public static string UsersListed = "Kullanıcılar listelendi";
        public static string UserUpdated = "Kullanıcı güncellendi";

        public static string CustomerAdded = "Firma eklendi";
        public static string CustomerUpdated = "Firma güncellendi";
        public static string CustomersListed = "Firmalar listelendi";
        public static string CustomerDeleted = "Firma silindi";

        public static string RentalAdded = "Araç kiralandı";
        public static string RentalDeleted = "Araç kiralama silindi";
        public static string RentalsListed = "Kiralamalar listelendi";
        public static string RentalUpdated = "Kira güncellendi";

        public static string RentalNotAdded = "Kira sisteme eklenemedi";
        public static string CarImageAdded="Araç resmi eklendi";
        public static string CarImageDeleted="Araç resmi silindi";
        public static string CarImagesListed="Araç resimleri listelendi";
        public static string CarImageUpdated="Araç resmi güncellendi";
        public static string CarImageLimitExceded="Bir aracın en fazla 5 adet resmi olabilir";

        public static string AuthorizationDenied = "Yetkiniz yok.";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";
    }
}
