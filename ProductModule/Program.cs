//using AutoMapper;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
//using ProductModule;
//using ProductModule.Services;

//var builder = WebApplication.CreateBuilder(args);
//{
//    builder.Services.AddControllers();
//    builder.Services.AddEndpointsApiExplorer();
//    builder.Services.AddSwaggerGen();
//    builder.Services.AddScoped<IProductService, ProductServiceDbContext>();
//    var mapperConfig = new MapperConfiguration(mc =>
//    {
//        mc.AddProfile(new MappingProfile());
//    });
//    IMapper mapper = mapperConfig.CreateMapper();
//    builder.Services.AddSingleton(mapper);

//    // DbContext
//    builder.Services.AddDbContext<ApplicationDbContext>(o =>
//    {
//        o.UseNpgsql(builder.Configuration.GetConnectionString("demodb"));
//    });
//}

//var app = builder.Build();
//{
//    if (app.Environment.IsDevelopment())
//    {
//        app.UseSwagger();
//        app.UseSwaggerUI();
//    }
//    app.UseHttpsRedirection();
//    app.MapControllers();
//    app.Run();
//}
