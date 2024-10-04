using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2TechAuction.Models.DatabaseRepositories;

public interface IDBRepository<T>
{
    bool Create(T Input);
    bool Update(T Input, int id);
    bool Delete(int Id);
    T Read();
    List<T> ReadAll();
}
