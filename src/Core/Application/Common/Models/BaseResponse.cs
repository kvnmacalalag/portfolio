using System.Collections.Generic;
using System.Linq;

namespace Portfolio.Application.Common.Models
{
    public abstract class BaseResponse
    {
        public bool IsSuccess => !Errors.Any();
        public Dictionary<string, string[]> Errors { get; protected set; } = new Dictionary<string, string[]>();
    }

    public class BaseResponse<TModel> : BaseResponse
    {
        public TModel Data { get; }
        public BaseResponse(TModel model, Dictionary<string, string[]> validationErrors = null)
        {
            Data = model;
            if (validationErrors != null)
            {
                Errors = validationErrors;
            }
        }
    }

    public class CreateRecordResponse<T>
    {
        public T Id { get; }
        public CreateRecordResponse(T id)
        {
            Id = id;
        }
    }
}