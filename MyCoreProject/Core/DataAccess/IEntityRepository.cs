using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    //generic Constraint
    //class--Sadece referans tip olanlar
    //Ientity-- Sadece Ientity ve onu implemente eden classlar dahil edilebilir
    //new-- ssadece new lenebilen elemanlar dahil edilir

  public  interface IEntityRepository<T> where T:class,IEntity,new()
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
