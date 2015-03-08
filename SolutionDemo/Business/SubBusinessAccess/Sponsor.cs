using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Business.ViewModels;
using DataModel;
using DataModel.DbContexts;
using DataModel.Entities;
namespace Business.SubBusinessAccess
{
    public interface ISponsor
    {
        ApplicationUser GetSponsor(string id);
        IEnumerable<Area> GetAreas();
        void RecordException(ErrorLog input, DemoDbContext dbContext);

        CommonSearchVm<T> GetSearchResult<T, TOrderBy>(CommonSearchVm<T> condition,
            Expression<Func<T, TOrderBy>> orderBy, SortOrder sortOrder = SortOrder.Ascending)
            where T : class;

        void Dispose();
    }

    public class Sponsor:CommonOperation, ISponsor
    {
        public ApplicationUser GetSponsor(string id)
        {
                return db.Users.Find(id);
        }

        public IEnumerable<Area> GetAreas()
        {
            return db.Areas.Include("Children");
        }  
    }
}
