using System;

namespace ReCapProject.Business.Constants
{
    public static class Messages
    {
        public static readonly string CarIsRented = "Bu araba kiralanmış.";
        public static readonly string NotFound = "Veri bulunamadı.";
        public static readonly string MaximumCarImagesWarning = "Bu araba için yüklenen fotoğraf sayısı sınıra ulaşmış. Bu nedenle yükleme gerçekleştirilemez.";
        public static readonly string UserNotFound = "Kullanıcı bulunamadı.";
        public static readonly string PasswordError = "Şifre hatalı.";
        public static readonly string SuccessfulLogin = "Giriş başarılı.";
        public static readonly string UserAlreadyExist = "Kullanıcı zaten kayıtlı.";
        public static readonly string UserRegistered = "Kullanıcı kaydı oluşturuldu.";
        public static readonly string AccessTokenCreated = "Access Token oluşturuldu.";
    }
}