using System;

namespace Investz.Shared.Models
{
    public class ResponseSingleDto<TEntity>
    {
        public TEntity Entity;

        public int StatusCode;

        public string Message;

        public bool Success;

        public Exception Exception;

        public ResponseSingleDto()
        {
            StatusCode = 200;
            Message = "";
            Success = true;
        }

        public ResponseSingleDto(Exception e) 
        {
            StatusCode = 500;
            Message = e.Message;
            Success = false;
        }
    }
}
