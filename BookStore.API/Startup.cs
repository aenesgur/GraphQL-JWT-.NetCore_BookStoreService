using BookStore.API.GraphQL;
using BookStore.API.GraphQL.Mutations;
using BookStore.API.GraphQL.Queries;
using BookStore.API.GraphQL.Types.Author;
using BookStore.API.GraphQL.Types.Book;
using BookStore.Business;
using BookStore.Business.Abstract;
using BookStore.DAL;
using BookStore.DAL.Abstract;
using BookStore.DAL.Concrete.EfCore;
using BookStore.Identity;
using BookStore.Identity.Services;
using BookStore.Identity.Services.Abstracts;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BookStore.API
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
            services.AddControllers().AddNewtonsoftJson();

            services.AddTransient<IAuthorDal, AuthorDal>();
            services.AddTransient<IBookDal, BookDal>();
            services.AddTransient<IAuthorManager, AuthorManager>();
            services.AddTransient<IBookManager, BookManager>();

            services.AddDbContext<BookStoreIdentitydbContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:BookStoreIdentityDb"]));
            services.AddDbContext<BookStoreContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:BookStoreDb"]));

            services.AddScoped<IDocumentExecuter, DocumentExecuter>();
            services.AddScoped<BookStoreQuery>();
            services.AddScoped<BookStoreMutation>();
            services.AddScoped<AuthorType>();
            services.AddScoped<AuthorInputType>();
            services.AddScoped<BookInputType>();
            services.AddScoped<BookType>();
            services.AddScoped<IDependencyResolver>(_ => new FuncDependencyResolver(_.GetRequiredService));
            services.AddScoped<ISchema, BookStoreSchema>();
            

            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequiredLength = 5;
            }).AddEntityFrameworkStores<BookStoreIdentitydbContext>()
             .AddDefaultTokenProviders();

            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = Configuration["AuthSettings:Audience"],
                    ValidIssuer = Configuration["AuthSettings:Issuer"],
                    RequireExpirationTime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["AuthSettings:Key"])),
                    ValidateIssuerSigningKey = true
                };
            });

            services.AddScoped<IUserService, UserService>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, BookStoreContext db)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            db.EnsureSeedData();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
