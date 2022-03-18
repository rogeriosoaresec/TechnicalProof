**Backend**

* **Run with InMemoryDatabase**

    The project use an InMemoryDatabase. 
    Just run the project without problem.

* **Run with ExternalDatabase**

    If you want use an external database it will be necessary change uncomment the `line 48` and comment the `line 47` from `Startup.cs`, and change the credentials.

    ```
    //DbContext
    services.AddDbContext<CampaignContext>(opt => opt.UseInMemoryDatabase("CampaignDb"));
    //services.AddDbContext<CampaignContext>(options => options.UseSqlServer("Data Source=LocalDb;Initial Catalog=PoC;User ID=sa;Password=pa$$w0rd!"));
    ```
    After uncomment the snippet, it will be run the migration

    `PM> Update-database`

* **Troubleshooting**
    If you have have problem with `NET::ERR_CERT_DATE_INVALID`, try the following solution:
    
    1. Clean the old certificate and generate a new trusted one. Run the commands listed below:
        `dotnet dev-certs https --clean`
        `dotnet dev-certs https --trust`
    2. Go to %APPDATA%\Microsoft\UserSecrets and delete all of the directories
    3. Re-run the application. It should now run with no SSL errors
