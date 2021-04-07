using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess

{   // İnterface metotlar default public kendisi public değildir. public yazmayı unutma
    // Generic constrain =generic kısıt sadece entities'teki sınıflar adı gelsin
    // Class:referanstip
    // **Core Katmanı diğer katmanları referans almaz.
    public interface IEntityRepository<T> where T:class,IEntity,new() 
        /* IEntity new'lenemez bu yüzden sadece veri tabanı nesneleri kaldı.
         yazılacak Classlar hem IEntity hem de
         clas sağlamaktadır. */
    {

        // her product ve category değiştirmemek için bir Generic  yapalım. Product yada category yerine T yazalım

        List<T> GetAll(Expression<Func<T, bool>> filter=null);
        T Get(Expression<Func<T, bool>> filter);

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

        List<T> GetAllByCategory(int categoryId);

    }
}
