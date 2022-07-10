using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatTask
{
    interface IRepository<T> where T : class
    {
        IEnumerable<T> GetList(); // получение всех объектов
        T Get(int id); // получение одного объекта по id
        void Create(T item); // создание объекта

        void Save();  // сохранение изменений
    }
}