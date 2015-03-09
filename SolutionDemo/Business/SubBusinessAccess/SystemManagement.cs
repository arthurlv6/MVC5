using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel.DbContexts;
using DataModel.Entities;

namespace Business.SubBusinessAccess
{
    public class SystemManagement : CommonOperation
    {
        public void UserLoginRecord(OperationRecord input)
        {
                db.OperationRecords.Add(input);
                db.SaveChanges();
        }
        public List<OperationRecord> GetLogs(string UserId)
        {
                return db.OperationRecords.Where(d=>d.UserId==UserId).ToList();
        } 
    }
}
