using AutoMapper;
using Common.Repository;
using Common.UOW;
using CWC.DocMgmt.Services;
using CWC.DocMgmtClient.Mappings;
using Microsoft.EntityFrameworkCore;
using ProductModule.Repository;

namespace CWC.DocMgmt
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
           
            services.AddScoped<IDocManagerService, DocManagerService>();

           

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
            services.AddScoped<IDocInfoRepository, DocInfoRepository>();

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
