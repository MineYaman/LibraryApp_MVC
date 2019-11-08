using LibraryApp.Entities;
using LibraryApp.Entities.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Interfaces.Abstract
{
    public interface IStudentService : IGenericService<Ogrenci>
    {
        Ogrenci GetByNo(int no);
        bool UpdateCeza(int id, int ceza);
    }
}
