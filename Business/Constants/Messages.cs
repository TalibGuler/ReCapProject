using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string Add = "Eklendi";
        public static string Fail = "Başarısız oldu";
        public static string Delete = "Silindi";
        public static string Update = "Değiştirildi";
        public static string Listed = "Listelendi";
        public static string AuthorizationDenied = "Yetkiniz Yok";
        public static string UserRegistered = "Kayıt edildi";
        public static string UserNotFound = "Kullanıcı bulunamadı.";
        public static string PasswordError = "Parola hatası";
        public static string SuccessfulLogin = "Giriş başarılı";
        public static string UserAlreadyExists = "Kullanıcı mevcut";
        public static string AccessTokenCreated = "Token oluşturuldu";
    }
}
