using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constans
{
   public static class Messages
    {
        public static string ColorInvalidName = "Renk İsmini Giriniz";
        public static string BrandInvalidName = "Marka ismini Giriniz";
        public static string CarInvalidDP= "Geçersiz Günlük Miktar";
        public static string Added = "Eklendi";
        public static string Deleted = "Silindi";
        public static string Updated = "Güncelledi";
        public static string BrandAdded = "Marka Eklendi";
        public static string BrandDeleted = "Marka Silindi";
        public static string BrandUpdated = "Marka Güncelledin";
        public static string CarAdded = "Araba Eklendi";
        public static string CarDeleted = "Araba Silindi";
        public static string CarUpdate = "Araba Güncellendi";
        public static string MaintenanceTime = "Sistem bakımda";

        public static string FailAddedImageLimit { get; internal set; }
        public static string ImageLimit = "Fotoğraf Limiti Doldu";
        internal static string AuthorizationDenied = "Yetkiniz Yok";
    }
}
