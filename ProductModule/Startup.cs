﻿using AutoMapper;
using Common.DataAccessManager;
using Common.PDFProcessing;
using Common.Repository;
using Common.UOW;
using Microsoft.EntityFrameworkCore;
using ProductModule.DataAccessManager;
using ProductModule.EntityProcessor;
using ProductModule.Mappings;
using ProductModule.Repository;
using ProductModule.Services;

namespace ProductModule
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
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            // Services
            //services.AddScoped<IProductService, ProductServiceWithRepository>();
            //services.AddScoped<IProductService, ProductServiceDbContext>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IDataAccessManager, ProductDataAccessManager>();

            services.AddScoped<ProductEntityProcessor>();
            services.AddScoped<IPDFProcessor, PDFProcessor>();
            
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            // DbContext
            services.AddDbContext<DbContext, ApplicationDbContext>(o =>
            {
                o.UseNpgsql(Configuration.GetConnectionString("demodb"));
                    //.LogTo(Console.WriteLine);
            });

            // Repositories
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            //Registration.ConfigureServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            //app.UseAuthorization();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
