using Domain;
using Library.Models;
using Services.LibraryServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Infrastructure
{
    public static class ModelFactory
    {
        public static LibraryViewModel ToModel(this Domain.Library library, IBookCopiesService bookCopiesService)
        {
            var Booknr = bookCopiesService.BookCopyNr(library.LibraryID);
            return new LibraryViewModel()
            {
                Id = library.LibraryID,
                Address = library.Adress,
                BookNr = Booknr,
                City = library.City,
                Name = library.Name
            };
        }
        public static LibraryViewModel ToModel(this Domain.Library library)
        {
           
            return new LibraryViewModel()
            {
                Id = library.LibraryID,
                Address = library.Adress,
                BookNr = library.BookCopies.Count(),
                City = library.City,
                Name = library.Name
            };
        }
        public static BookViewModel ToModel(this Book book)
        {
            var publisherName = book.Publisher == null ? "" : book.Publisher.Name;
            return new BookViewModel()
            {
                Id = book.BookID,
                Title = book.Title,
                YearOfIssue = book.YearOfIssue,
                NumberOfPages = book.NumberOfPages,
                Publisher = publisherName,
                LendingsNr = book.Lendings.Count,
                BookNr = book.BookCopies.Count

            };
        }

        public static Domain.Library ToEntity(this LibraryViewModel viewModel)
        {
            return new Domain.Library()
            {
                Adress = viewModel.Address,
                City = viewModel.City,
                Name = viewModel.Name
            };
        }
        public static Book ToEntity(this BookViewModel viewModel)
        {
            return new Book()
            {
                Title = viewModel.Title,
                YearOfIssue = viewModel.YearOfIssue,
                NumberOfPages = viewModel.NumberOfPages
                

            };
        }

        public static Domain.Library Edit(this LibraryViewModel viewModel, Domain.Library entity)
        {
            entity.Adress = viewModel.Address;
            entity.City = viewModel.City;
            entity.Name = viewModel.Name;
            return entity;
        }

        public static PublisherViewModel ToModel(this Publisher entity)
        {
            return new PublisherViewModel()
            {
                Id = entity.PublisherID,
                BookNr = entity.Books.Count,
                Country = entity.Country,
                Name = entity.Name
            };
        }
        public static ClientViewModel ToModel(this Client entity)
        {
            return new ClientViewModel()
            {
                Id = entity.ClientID,
                City = entity.City,
                Address = entity.Address,
                Phone = entity.Phone,
                Name = entity.Name
            };
        }
        public static Publisher ToEntity(this PublisherViewModel viewModel)
        {
            return new Publisher()
            {
                Name = viewModel.Name,
            Country = viewModel.Country
            };
        }
        public static Client ToEntity(this ClientViewModel viewModel)
        {
            return new Client()
            {
                Name = viewModel.Name,
                City = viewModel.City,
                Address = viewModel.Address,
                Phone = viewModel.Phone
            };
        }
        public static Publisher Edit(this PublisherViewModel viewModel, Publisher entity)
        {
            entity.Name = viewModel.Name;
            entity.Country = viewModel.Country;
            return entity;
        }
        public static Client Edit(this ClientViewModel viewModel, Client entity)
        {
            entity.Name = viewModel.Name;
            entity.City = viewModel.City;
            entity.Address = viewModel.Address;
            entity.Phone = viewModel.Phone;
            return entity;
        }
        public static Book Edit (this BookViewModel viewModel, Book entity)
        {
            entity.Title = viewModel.Title;
            entity.NumberOfPages = viewModel.NumberOfPages;
            entity.YearOfIssue = viewModel.YearOfIssue;
            return entity;
        }
    }
       
}
