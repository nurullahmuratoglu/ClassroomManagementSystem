﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ClassroomManagementSystem.Core.Dtos
{
    public class ResponseDto<T>
    {
        public T Data { get; set; }
        public List<string> Errors { get; set; }
        
        public int StatusCode { get; set; }


        public static ResponseDto<T> Success(int statucCode, T data)
        {
            return new ResponseDto<T> { Data = data, StatusCode = statucCode };
        }
        public static ResponseDto<T> Success(int statucCode)
        {
            return new ResponseDto<T> { StatusCode = statucCode };
        }
        public static ResponseDto<T> Fail(int statucCode, List<string> errors)
        {
            return new ResponseDto<T> { StatusCode = statucCode, Errors = errors };
        }
        public static ResponseDto<T> Fail(int statucCode, string error)
        {
            return new ResponseDto<T> { StatusCode = statucCode, Errors = new List<string> { error } };
        }
    }
}
