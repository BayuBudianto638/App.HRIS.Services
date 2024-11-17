var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.App_HRIS_Services>("app-hris-services");

builder.AddProject<Projects.App_HRIS_Services_EmployeeServices>("app-hris-services-employeeservices");

builder.AddProject<Projects.App_HRIS_Entities>("app-hris-entities");

builder.Build().Run();
