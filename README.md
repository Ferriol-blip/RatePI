# RatePI

**:closed_book: Documentacion**

Backend de la aplicación RatePI, trata de administrar las votaciones de los distintos proyectos integrados, cada participante podrá votar a un unico PI de cada una de las categoria con una puntuacion del 1 al 5.

* Se almacenan los asistentes y su votacion de cada caterogira y pi.
* Se almacena las categorias, votacion acumulada de estas y su pi.
* Se almacena los pi con su nombre, descripcion, ciclo.
* Se almacena los integrantes de cada pi, nombre e email.

**:blue_book: Funcionalidades**

1. Obtener un listado de proyectos filtrado por cada una de las categorias, devolviendo también la puntuación media.
    *  Obtiene la puntuación total, mediante un metodo obtiene la cantidad total de votos de un proyecto y calcula la media.
 
1.  Obtener un listado de proyectos filtrando por ciclo formativo.
 
1.  Introduccion de un PI, solo accesible por el administrador del evento.
    *  Con cada inserción de un nuevo proyecto, se insertan automaticamente las tres categorias ligadas a ese proyecto.
  
1.  Obtener un listado de proyectos, filtrado por su ciclo y puntuación.
  
1.  Eliminar una puntuación de un asistente.
    *  Se elimina el registro del asistente y sus puntuaciones, además actualiza, restando en este caso de la puntuación total del pi. (Se ha usado el delete del controler, otra opción sería usar un get y realizar un update sin necesidad de eliminar el asistente)
 
1.  Obtener un listado de proyectos filtrado por su nombre, obteniendo tambíen su puntuación total.
  
1.  Insertar un asistente nuevo.
    *  Inserta el nombre e email de asistente, proyecto, puntuacion y a que categoria va dirigido, que actualiza, sumandose a la puntuación total del proyecto seleccionado.


