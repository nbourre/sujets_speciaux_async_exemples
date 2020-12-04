using System;
using System.Collections.Generic;
using System.Text;

namespace demo_json_serialization.Services
{
    public interface IDataService<T>
    {
        IEnumerable<T> GetAll();
        bool Insert(T record);
        bool UpdateOrInsert(T record);
        bool Delete(T record);
        bool Save();
    }
}
