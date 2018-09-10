# Amaris
Se realizó una Web Api con el patron unity of work con inyección de dependencia como indica uno de los principios SOLID. Como contenedor se uso Unity utilizando interceptor para la captura de try/catch en toda la aplicacion. El logeo se uso la libreria NLog para guardar los trace en un txt y los errores también en un txt y a su vez en base de datos.
Las url de donde se obtienen los datos estan en el web config para que puedan ser configurables. 
Tambien se debe configurar en el web config el server y el nombre de base de datos en el ConnectionString.
