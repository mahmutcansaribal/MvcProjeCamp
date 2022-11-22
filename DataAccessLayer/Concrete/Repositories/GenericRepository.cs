using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    //todo Gonderdigimiz T degeri bir class olmalı diyoruz!
    public class GenericRepository<T> : IRepository<T> where T : class
    {

        Context c = new Context();
        DbSet<T> _object;

        //todo Gelen Sınıfı anlayabilmemiz için bir Constructor yaratıyoruz!

        public GenericRepository()
        {
            //todo Dışarıdan gelen T degerini atadık. dışarıdan gelen entity neyse o olacaktır.
            _object = c.Set<T>();
        }
        public void Delete(T p)
        {
            //EntityFramework'den kullanılan methodlar.
            var deletedEntity = c.Entry(p);
            deletedEntity.State = EntityState.Deleted;
            // _object.Remove(p);
            c.SaveChanges();
        }
        public T Get(Expression<Func<T, bool>> filter)
        {
            //todo bir dizide ya da listede geriye 1 tane deger döndürmek için kullanılan methottur. ID sı 5 olan yazarı getirmek için
            return _object.SingleOrDefault(filter);
        }
        public void Insert(T p)
        {
            //todo EntityFramework'den kullanılan Methodlar.
            //todo ekleme işleimi entitystate üzerinden yapmaya başladık.
            var addedEntity = c.Entry(p);
            addedEntity.State = EntityState.Added;
            // _object.Add(p);
            c.SaveChanges();
        }
        //todo Listeleme işlemi.
        public List<T> List()
        {
            return _object.ToList();
        }
        //todo Burada Komple bir deger döndürülür mesela tüm yazarları
        //todo parametreli list
        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public void Update(T p)
        {
            //todo guncelleme islmeleri yapıldı.
            var updatedEntity = c.Entry(p);
            updatedEntity.State = EntityState.Modified;
            c.SaveChanges();
        }
    }
}
/*
    ToList
    Add
    Remove
    Find    
*/