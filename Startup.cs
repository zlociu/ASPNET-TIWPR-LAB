using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using Zajecia_ASPNET.Data;
using Zajecia_ASPNET.Models;

namespace Zajecia_ASPNET
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseInMemoryDatabase("BookDB");
            });

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseFileServer(false);

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            AddBooks(serviceProvider).Wait();
        }

        private Task AddBooks(IServiceProvider serviceProvider)
        {
            var dbContext = serviceProvider.GetRequiredService<AppDbContext>();

            var book = new BookModel
            {
                Title = "Kod Leonarda da Vinci",
                Author = "Dan Brown",
                YearOfPublication = 2006,
                Publisher = "Albatros",
                ISBN = "978-83-919131-3-9"
            };
            dbContext.Books.Add(book);

            var book2 = new BookModel
            {
                Title = "Przedwiośnie",
                Author = "Stefan Żeromski",
                YearOfPublication = 1966,
                Publisher = "Czytelnik",
            };
            dbContext.Books.Add(book2);

            var book3 = new BookModel
            {
                Title = "Gra o Tron",
                Author = "George R. R. Martin",
                YearOfPublication = 2011,
                Publisher = "Zysk i S-ka",
                ISBN = "978-83-7506-358-5"
            };
            dbContext.Books.Add(book3);

            var book4 = new BookModel
            {
                Title = "Quo Vadis",
                Author = "Henryk Sienkiewicz",
                YearOfPublication = 1970,
                Publisher = "Państwowy Instytut Wydawniczy"
            };
            dbContext.Books.Add(book4);

            var book5 = new BookModel
            {
                Title = "Intruz",
                Author = "Stephenie Meyer",
                YearOfPublication = 2008,
                Publisher = "Wydawnictwo Dolnośląskie",
                ISBN = "978-83-245-9467-2"
            };
            dbContext.Books.Add(book5);

            var book6 = new BookModel
            {
                Title = "Kordian",
                Author = "Juliusz Słowacki",
                YearOfPublication = 1977,
                Publisher = "Państwowy Instytut Wydawniczy",
                ISBN = "978-83-06-00578-3"
            };
            dbContext.Books.Add(book6);
            dbContext.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
