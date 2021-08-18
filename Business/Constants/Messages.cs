using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araba eklendi";
        public static string CarNameInvalid = "Araba ismi geçersiz";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string CarListed = "Araba listelendi";
        public static string UserAdded = "Kullanıcı Eklenmiştir";
        public static string GetUserId = "Kullanıcı Idleri Getirildi";
        public static string GetUser = "Kullanıcılar Getirildi";
        public static string CustomerAdded = "Müşteri Eklenmiştir.";
        public static string AuthorizationDenied = "Yetkiniz yok.";
        public static string Deleted = "Araba Silindi";
        public static string CarBrandNameInvalid = " Marka adı 2 kelimeden fazla olmalırdır";
        public static string CarsListed="Araba Listelenmiştir";
        public static string UserDeleted ="Kullanıcı Silindi";
        public static string UserUpdated = "Kullanıcı Güncellendi";
        public static string CustomerUpdated = "Müşteri Güncellendi";
        public static string CustomerDeleted = "Müşteri Silindi";
        public static string GetCustomerId = "Müşteri Idleri Getirildi";
        public static string GetCustomer = "Müşteriler Getirildi";
        public static string RentalError = "Araba Şuanda Kiralanamıyor";
        public static string RentalCarNotDelivered= "Kiralık Araba Teslim Edilmedi";
        public static string RentalAdded="Kiralık araba eklendi";
        public static string RentalDeleted= "Kiralık araba silindi";
        public static string RentalsListed="Kiralık araba Listelendi";
        public static string GetRental = "Kiralık Aracı getir";
        public static string RentalUpdated = "Kiralık araba güncellendi";
        public static string CarImageLimit="5 fotoğraftan fazlasını koyamazsınız";
        public static string CarimageAdded="araba resmi eklendi";
        public static string CarImageDeleted="Araba resmi silinmiştir";
        public static string CarImageNotFound="Araba resmi bulunamadı";
        public static string UserRegistered="Kullanıcı Kaydedildi";
        public static string UserNotFound="Kullanıcı Bulunamadı";
        public static string UserAlreadyExists="Kullanıcı zaten var";
    }
}
