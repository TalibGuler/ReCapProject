using System;
using System.Collections.Generic;
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
        public static string CategoryLimitExceded = "5 adetten fazla resim eklenemez";

        public static string CarImageNotAdded { get; internal set; }
        public static string CarImageNotFound { get; internal set; }
        public static string CarImageDeleted { get; internal set; }
        public static string CarImageUpdated { get; internal set; }
        public static string CarImageLimitExceeded { get; internal set; }
    }
}
