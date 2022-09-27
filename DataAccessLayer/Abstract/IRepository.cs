using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IRepository<T> 
    {
        List<T> List();
        void Insert(T p);
        void Update(T p);
        void Delete(T p);
        //todo Şartlı Arama yapar! (filtreli)
        List<T> List(Expression<Func<T,bool>> filter);
    }
}
