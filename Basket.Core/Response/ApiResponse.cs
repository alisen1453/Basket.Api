namespace Basket.Core.Response
{
    using System.Collections.Generic;

    public class ApiResponse<T>
    {
        // İstek başarılı mı başarısız mı olduğunu belirten alan.
        public bool IsSuccesful { get; set; }
        public int Statuscode { get; set; }

        // Birden fazla mesajı (hata, uyarı, bilgi) tutan bir liste.
        public List<string> Messages { get; set; }

        // İstek başarılı olduğunda dönecek olan veri.
        public T Data { get; set; }


        // Bu constructor başarılı durumlar için kullanılır.
        // Kullanıcıya döndürülecek veri ve isteğe bağlı olarak mesaj listesi alır.
        public ApiResponse(int statuscode, T data, List<string> messages)
        {
            IsSuccesful = true; // Başarılı durumda true olarak ayarlanır.
            Data = data; // Döndürülen veri burada atanır.
            Messages = messages;
            Statuscode = statuscode;
            // Mesajlar boşsa, varsayılan bir mesaj eklenir.
        }

        // Bu constructor başarısız durumlar için kullanılır.
        // Başarısızlık durumunda mesaj listesi alır, data kısmı default olarak atanır.
        public ApiResponse(int statuscode, List<string> messages)
        {
            IsSuccesful = false; // Başarısız durumda false olarak ayarlanır.
            Messages = messages; // Hata mesajları buraya atanır.
            Data = default;// Başarısız durumda veri döndürülmeyeceği için veri kısmı boş bırakılır.
            Statuscode = statuscode;
        }

        // Bu constructor, tek bir hata mesajı döndürmek için kullanılabilir.
        public ApiResponse(int statuscode, string message)
        {
            IsSuccesful = false; // Başarısız durumda false olarak ayarlanır.
            Messages = new List<string> { message }; // Tek mesaj bir listeye dönüştürülür.
            Data = default; // Veri kısmı boş bırakılır.
            Statuscode = statuscode;
        }
    }




}

