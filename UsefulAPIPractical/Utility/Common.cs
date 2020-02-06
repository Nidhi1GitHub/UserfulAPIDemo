using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UsefulAPIPractical.Utility
{
    public static class Common
    {
        public static ApiResponse GenerateApiResponse(int ResultCode, bool Status, string Message, object Data)
        {
            ApiResponse apiResponse = new ApiResponse();
            apiResponse.ResultCode = ResultCode;
            apiResponse.Status = Status;
            apiResponse.Message = Message;
            apiResponse.Data = Data;
            return apiResponse;
        }
    }

    public class ApiResponse
    {
        public int ResultCode { get; set; }
        public bool Status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }


}