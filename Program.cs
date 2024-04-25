using DeShawns.blueprint;
using DeShawns.blueprint.DTOs;

List<Dog> dogs = new List<Dog>
{
    new Dog() { Id = 1, Name = "Dianemarie Hartness", WalkerId = 3 },
    new Dog() { Id = 2, Name = "Christoph Fosdyke", WalkerId = 10},
    new Dog() { Id = 3, Name = "Rocket", WalkerId = 7},
    new Dog() { Id = 4, Name = "Ebony", WalkerId = 3},
    new Dog() { Id = 5, Name = "Scotty", WalkerId = 8},
    new Dog() { Id = 6, Name = "Mac", WalkerId = 2},
    new Dog() { Id = 7, Name = "Oreo", WalkerId = 5},
    new Dog() { Id = 8, Name = "Sassy", WalkerId = 1},
    new Dog() { Id = 9, Name = "Salem", WalkerId = 9},
    new Dog() { Id = 10, Name = "Panda", WalkerId = 7}
};

List<Walker> walkers = new List<Walker>
{
    new Walker() { Id = 1, Name = "Alphonse Meron"},
    new Walker() { Id = 2, Name = "Damara Pentecust"},
    new Walker() { Id = 3, Name = "Anna Bowton"},
    new Walker() { Id = 4, Name = "Hunfredo Drynan"},
    new Walker() { Id = 5, Name = "Elmira Bick"},
    new Walker() { Id = 6, Name = "Bernie Dreger"},
    new Walker() { Id = 7, Name = "Rolando Gault"},
    new Walker() { Id = 8, Name = "Tiffanie Tubby"},
    new Walker() { Id = 9, Name = "Tomlin Cutill"},
    new Walker() { Id = 10, Name = "Arv Biddle0"}
};

List<City> cities = new List<City>
{
    new City() { Id = 1, Name = "Boise"},
    new City() { Id = 2, Name = "Chicago"},
    new City() { Id = 3, Name = "Denver"},
    new City() { Id = 4, Name = "Minneapolis"},
    new City() { Id = 5, Name = "Phoenix"},
    new City() { Id = 6, Name = "Pittsburgh"},
    new City() { Id = 7, Name = "San Diego"},
    new City() { Id = 8, Name = "Sarasota"},
    new City() { Id = 9, Name = "Tucson"},
    new City() { Id = 10, Name = "White Plains"}
};

List<WalkerCity> walkerCities = new List<WalkerCity>
{
    new WalkerCity() { Id = 1, CityId = 2, WalkerId = 1},
    new WalkerCity() { Id = 2, CityId = 10, WalkerId = 2},
    new WalkerCity() { Id = 3, CityId = 8, WalkerId = 3},
    new WalkerCity() { Id = 4, CityId = 7, WalkerId = 4},
    new WalkerCity() { Id = 5, CityId = 1, WalkerId = 5},
    new WalkerCity() { Id = 6, CityId = 3, WalkerId = 6},
    new WalkerCity() { Id = 7, CityId = 9, WalkerId = 7},
    new WalkerCity() { Id = 8, CityId = 5, WalkerId = 8},
    new WalkerCity() { Id = 9, CityId = 4, WalkerId = 9},
    new WalkerCity() { Id = 10, CityId = 6, WalkerId = 10},
};


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/api/hello", () =>
{
    return new { Message = "Welcome to DeShawn's Dog Walking" };
});

app.MapGet("/api/Dogs", () =>
{
   foreach (Dog dog in dogs)
   {
    Walker walker = walkers.FirstOrDefault(w => w.Id == dog.WalkerId);
    City city = cities.FirstOrDefault(c => c.Id == walker.Id);
   }
   return dogs.Select(d => new DogDTO
   {
    Id = d.Id,
    Name = d.Name,
    WalkerId = d.WalkerId
   });
});


app.Run();
