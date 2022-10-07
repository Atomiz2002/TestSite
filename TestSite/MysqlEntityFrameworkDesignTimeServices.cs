using Microsoft.EntityFrameworkCore.Design;
using MySql.EntityFrameworkCore.Extensions;

namespace TestSite; 

// ReSharper disable once UnusedType.Global
public class MysqlEntityFrameworkDesignTimeServices : IDesignTimeServices {

	public void ConfigureDesignTimeServices(IServiceCollection serviceCollection) {
		serviceCollection.AddEntityFrameworkMySQL();

		new EntityFrameworkRelationalDesignServicesBuilder(serviceCollection)
		   .TryAddCoreServices();
	}

}