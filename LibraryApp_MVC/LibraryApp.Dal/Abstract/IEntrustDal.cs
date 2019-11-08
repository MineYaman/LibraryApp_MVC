using LibraryApp.Entities;
using LibraryApp.Entities.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Dal.Abstract
{
    public interface IEntrustDal : IDisposable
    {
        Emanet Add(Emanet entity);
        int Update(Emanet entity);
        List<Emanet> GetAll();
        List<Emanet> GetListID(int id);
        List<Emanet> DynamicList(Expression<Func<Emanet, bool>> predicate);// Dinamik Filtreleme 
        Emanet GetById(int id);
        bool ReceivedByID(int id);
        bool Received(Emanet entity);
    }
}
