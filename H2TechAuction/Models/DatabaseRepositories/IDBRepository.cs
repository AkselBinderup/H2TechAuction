using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2TechAuction.Models.DatabaseRepositories;

public interface IDBRepository<T>
{
    bool Create(T Input);
    bool Update(T Input, int Id);
    bool Delete(int Id);
    T Read(string obj, string obj2);
    List<T> ReadAll(int Id);
}
