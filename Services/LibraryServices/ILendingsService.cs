using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.LibraryServices
{
    public interface ILendingsService
    {
        IEnumerable<Lending> GetAllLendings();
        void InsertLending(Lending lending);
        void UpdateLending(Lending lending);
        void DeleteLending(Lending lending);
        Lending GetLending(int id);
    }
}
