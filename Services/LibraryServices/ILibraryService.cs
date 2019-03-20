using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Domain;
using Services.Models;

namespace Services.LibraryServices
{
    public interface ILibraryService
    {
        
        IEnumerable<Library> GetAllLibraries();
        
        Library GetLibrary(int id);
       
        void InsertLibrary(Library library);
        void UpdateLibrary(Library library);
        void DeleteLibrary(Library library);
        Library GetWithInclude(int id, params Expression<Func<Library, object>>[] Include);


        Lending Lend(Lending lend);
        
    }
}