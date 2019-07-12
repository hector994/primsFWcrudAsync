using System;
using System.Collections.Generic;
using System.Text;

using BatPrismTutorials.Model;
using System.Threading.Tasks;

namespace BatPrismTutorials.Services
{
    
    public interface IBatFamilyService
    {

        Task<IEnumerable<BatFamily>> GetAllAsync();
        Task<BatFamily> GetByIdAsync(int id);
        Task UpdateAsync(BatFamily todoItem);
        Task InsertAsync(BatFamily todoItem);
        Task DaleteAsync(BatFamily todoItem);


        //IEnumerable<BatFamily> GetFamilies();
        //BatFamily GetById(int id);
        //void Update(BatFamily BatParent);
        //void Insert(BatFamily BatParent);
        //void Delete(int id);
    }
}
