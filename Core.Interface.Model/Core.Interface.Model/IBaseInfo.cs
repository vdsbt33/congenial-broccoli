using System;

namespace Core.Interface.Model.Product
{
    public interface IBaseInfo
    {
        long Id { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime EditedDate { get; set; }
    }
}
