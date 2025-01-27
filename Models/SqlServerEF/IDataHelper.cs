using System;
using System.Collections.Generic;
using System.Text;

namespace dist_manage.Models
{
    public interface IDataHelper<Table>
    {
        // Read
        List<Table> GetAllData();
        List<Table> Search(string SerachItem);
        Table Find(int Id);

        //Write
        int Add(Table table);
        int Edit(int Id, Table table);
        int Delete(int Id);
    }
}
