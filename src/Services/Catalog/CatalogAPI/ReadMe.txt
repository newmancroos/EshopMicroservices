- Refer hub.docker.com/_/postgres  for docker options
- What is Backing Service :
		Microservices uses some external support tolls like database, Cache, Message Brocker, Key-Vault are call Backing Service

- MediatR - Dynamic Dependency injector
- Marten - Transactional Document support for Postgres database in asp.net core. It is a ORM (Object relational mapping) like Entity framework
- Mapster - It is a object mapper like AutoMapper
- Carter - Service End-point router for minimal Api


- Communicate with docker Postgres database
	* docker ps   - List down all the containers
	* docker exec -it 827c0e493420 bash    (where the numbers is container Id, and -it means interactive tunnel) - We'll get docker commandline
	* Connect POstgres database : psql -U postgres   (We'll get postgres command line)
	*  \l  in the command line will listdown all the dabases
	* from Postgres commandline give \c CatalogDb  to connect
	* Listdown all tables \d
	* SELECT * FROM mt_doc_product;  - list down all data in the product table




	-Containerize API
	- Select Add Docker support and select overwrite the existing one
	-  We add Container orgestration for Postgres sql now after we create Dokcer support for Api we need to add Container Orgeatration for Api
	- This will modify existing Docker-Compose and docker-composeoverrite file
	- Change the exposed port numbers to 6000(http) 6060(https) here 8000 and 8081 are docker exposed port for api
	- We need to add configurations into docker-compose overrite
	- for connection string etc.. in the environment
	- Catalog api depend on Catalog db so in Api section we need to add depende attribute so that docker will start Postgres before Api
