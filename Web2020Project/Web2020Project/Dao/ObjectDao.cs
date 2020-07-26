using System;

namespace Web2020Project.Dao
{
    public interface ObjectDao
    {
        bool add(Object obj);
        bool remove(String id);
        bool  edit(Object obj);
    }
}