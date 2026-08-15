using Account_Service.Data;
using Account_Service.Data.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddDbContext<AccountDb>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("financedb"))
);

var app = builder.Build();

app.MapOpenApi();

if (app.Environment.IsDevelopment())
{
    app.MapScalarApiReference();
}

app.UseHsts();
app.UseHttpsRedirection();

using (var scope = app.Services.CreateScope())
{
     var dbCtx = scope.ServiceProvider.GetRequiredService<AccountDb>();
    dbCtx.Database.EnsureCreated();
    try {
        dbCtx.Accounts.Count();
    }
    catch (Exception)
    {
        var dbCreator = dbCtx.GetService<IRelationalDatabaseCreator>();
        dbCreator.CreateTables();
    }
}

app.MapGet("/getAccounts/{uid}", getUserAccounts);
app.MapPost("/addBalance/{id}", addBalance);
app.MapPost("/addAccount", addAccount);

app.Run();

static async Task<Ok<List<Account>>> getUserAccounts(AccountDb db, int uid)
{
    return TypedResults.Ok(await db.Accounts.Where(a => a.user_id == uid).OrderBy(a => a.id).ToListAsync());
}

static async Task<Results<Ok<AccountDTO>, BadRequest>> addBalance(AccountDb db, int id, decimal amount)
{
    var account = await db.Accounts.Where(a => a.id == id).FirstOrDefaultAsync();
    if (account == null)
        return TypedResults.BadRequest();

    account.balance += amount;
    await db.SaveChangesAsync();
    return TypedResults.Ok(new AccountDTO
    {
        id = account.id,
        balance = account.balance
    });
}

//PLACEHOLDER FOR DEVELOPMENT
static async Task<Created<Account>> addAccount(AccountDb db, AddAccountDTO addAccountDTO)
{
    Account account = new Account() { user_id = addAccountDTO.user_id };
    db.Accounts.Add(account);
    await db.SaveChangesAsync();

    return TypedResults.Created($"/{account.id}", account);
}