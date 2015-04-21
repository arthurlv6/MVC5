using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Business.ViewModels;
using DataModel;
using DataModel.DbContexts;
using DataModel.Entities;

namespace Business
{
    public class CommonOperation
    {
       
        public static DateTime NewZealandTime
        {
            get
            {
                DateTime serverTime = DateTime.Now;
                TimeZoneInfo timeZone1 = TimeZoneInfo.FindSystemTimeZoneById("New Zealand Standard Time");
                return TimeZoneInfo.ConvertTime(serverTime, timeZone1);
            }
        }
        public void RecordException(ErrorLog input, DemoDbContext dbContext)
        {
            foreach (DbEntityEntry entry in dbContext.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    // If the EntityState is the Deleted, reload the date from the database.   
                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                    default: break;
                }
            }
            if (string.IsNullOrEmpty(input.Message))
                input.Message = "Failed to catch the error message.";
            if (string.IsNullOrEmpty(input.MessageDump))
                input.Message = "Failed to catch the error stack message.";
            if (string.IsNullOrEmpty(input.DeviceId))
                input.DeviceId = "Unknow deviceId.";

            input.EventUtc = DateTime.UtcNow;
            //dbContext.ErrorLogs.Add(input);
            dbContext.SaveChanges();
            dbContext.Dispose();
        }

        public virtual CommonSearchVm<T> GetSearchResult<T, TOrderBy>(CommonSearchVm<T> condition,
            Expression<Func<T, TOrderBy>> orderBy, SortOrder sortOrder = SortOrder.Ascending)
            where T : class
        {
            using (var db=new DemoDbContext())
            {
                var result = new CommonSearchVm<T>();
                List<T> group;
                int total = db.Set<T>().Count(condition.Func);
                var totalPages = total / condition.PerPageSize + (total % condition.PerPageSize > 0 ? 1 : 0);
                if (condition.CurrentPage > totalPages)
                {
                    condition.CurrentPage = 1;
                }
                if (sortOrder == SortOrder.Ascending)
                {
                    group =
                        db.Set<T>()
                            .Where(condition.Func)
                            .OrderBy(orderBy)
                            .Skip((condition.CurrentPage - 1) * condition.PerPageSize)
                            .Take(condition.PerPageSize)
                            .ToList();
                }
                else
                {
                    group =
                        db.Set<T>()
                            .Where(condition.Func)
                            .OrderByDescending(orderBy)
                            .Skip((condition.CurrentPage - 1) * condition.PerPageSize)
                            .Take(condition.PerPageSize)
                            .ToList();
                }
                result.Data = group;

                result.TotalPages = totalPages == 0 ? 1 : totalPages;
                result.PerPageSize = condition.PerPageSize;
                result.CurrentPage = condition.CurrentPage;
                return result;
            }
        }

        protected void ThrowOperationException(Action action)
        {
            try
            {
               action.Invoke();
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder sb=new StringBuilder();
                foreach (var error in ex.EntityValidationErrors)
                {
                    Console.WriteLine("====================");
                    Console.WriteLine(
                        "Entity {0} in state {1} has validation errors:",
                        error.Entry.Entity.GetType().Name,
                        error.Entry.State);
                    foreach (var ve in error.ValidationErrors)
                    {
                        //Console.WriteLine();
                        sb.Append(string.Format("\tProperty: {0}, Error: {1}", ve.PropertyName, ve.ErrorMessage));
                    }
                    Console.WriteLine();
                }
                throw new DbEntityValidationException(sb.ToString());
            }
            catch (Exception e)
            {
                throw new Exception("Please contact your database manager.");
            }

        }
        protected List<T> ThrowOperationException<T>(Func<List<T>> func) where T : class,new()
        {
            try
            {
               return func.Invoke();
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var error in ex.EntityValidationErrors)
                {
                    Console.WriteLine("====================");
                    Console.WriteLine(
                        "Entity {0} in state {1} has validation errors:",
                        error.Entry.Entity.GetType().Name,
                        error.Entry.State);
                    foreach (var ve in error.ValidationErrors)
                    {
                        //Console.WriteLine();
                        sb.Append(string.Format("\tProperty: {0}, Error: {1}", ve.PropertyName, ve.ErrorMessage));
                    }
                    Console.WriteLine();
                }
                throw new DbEntityValidationException(sb.ToString());
            }
            catch (Exception e)
            {
                throw new Exception("Please contact your database manager.");
            }

        }
        public void Dispose()
        {
            //db.Dispose();
        }
    }
}
