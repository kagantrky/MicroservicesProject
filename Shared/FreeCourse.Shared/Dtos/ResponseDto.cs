﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;

namespace FreeCourse.Shared.Dtos
{
    public class ResponseDto<T>
    {
        public T Data { get; set; }

        [JsonIgnore]
        public int StatusCode { get; set; } //kendi içimizde kullanmak iin jsonıgnore
                                            //zaten api istek yapılınca dönüş tipini görebiliyoruz. reponse bodysinde bir daha statuscode göndermeye gerek yok
                                            //kod içinde donus tipini belirlerken buradan faydalanacağız. o yüzden jsonIgnore ile işaretledik.

        [JsonIgnore]
        public bool IsSuccessful { get; private set; }

        public List<string> Errors { get; set; } //hatalar buradan dönecek.

        //statik metotlar nesne oluşturmada bize fayda sağlıyor.
        //builder prototype pattern gibi. 
        //static factory metotlar yardımcı olur. 

        //Static Factory Methods
        public static ResponseDto<T> Success(T data, int statusCode)
        {
            return new ResponseDto<T> { Data = data, StatusCode = statusCode, IsSuccessful = true };
        }
        //update veya delete gibi işlemlerde data dönmeyebilir bu yüzden sadece statuscode
        public static ResponseDto<T> Success(int statusCode)
        {
            return new ResponseDto<T> { Data = default(T), StatusCode = statusCode, IsSuccessful = true}
        }
        public static ResponseDto<T> Fail(List<string> errors, int statusCode)
        {
            return new ResponseDto<T>
            {
                Errors = errors,
                StatusCode = statusCode,
                IsSuccessful = false
            };
        }
        public static ResponseDto<T> Fail(string error, int statusCode)
        {
            return new ResponseDto<T>
            {
                Errors = new List<string>() { error },
                StatusCode = statusCode,
                IsSuccessful = false
            };
        }
    }
}
