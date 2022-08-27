using AutoMapper;
using Common.Repository;
using Microsoft.EntityFrameworkCore;
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
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductService, ProductServiceDbContext>();
            //services.AddSingleton<Func<string, IProductService>>(serviceProvider => key =>
            //{
            //    switch (key)
            //    {
            //        case "Db": return serviceProvider.GetService<ProductServiceDbContext>();
            //        case "Repository": return serviceProvider.GetService<ProductService>();
            //        default: throw new KeyNotFoundException();
            //    }
            //});
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            // DbContext
            services.AddDbContext<ApplicationDbContext>(o =>
            {
                o.UseNpgsql(Configuration.GetConnectionString("demodb"));
            });

            // Repositories
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IProductRepository, ProductRepository>();
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
            app.UseAuthorization();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
