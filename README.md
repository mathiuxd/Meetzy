# COMO TRABAJAR EN EL PROYECTO

Primero que todo hay que configurar el git, les recomiendo que vean este video https://www.youtube.com/watch?v=_2Hih_XylUA aqui se explica el como identificarse en git y agregar una SSH en GitHub para trabajar mas comodos.

Despues de hacer eso hay que clonar el repositorio, si hicieron la configuracion del video el link para clonar el repo es: git@github.com:mathiuxd/Meetzy.git Despues de esto les va a pedir que si estan seguros, si lo clonaron desde Visual Studio en la ventana emergente que les sale lo unico que hay que escribir es "yes", lo mismo si lo hacen desde la consola.

# FLUJO DE TRABAJO

Primero verifican que si esten en la rama que es con
```bash
git branch        # muestra en qué rama están
git checkout dev  # cámbiense a dev
```

**Nunca trabajen en `main` directo. Si lo intentan, GitHub lo va a rechazar.**

Cuando vayan a hacer algo siempre deben de hacer pull que seria asi:
git pull origin dev
> ⚠️ Si no hacen pull antes de empezar, van a tener conflictos. Siempre pull primero.

cuando terminen alguna tarea hacen lo siguiente:
git add .
git commit -m "Descripcion de lo que hicieron" <--- aqui traten de ser breves y especificos en lo que hicieron
git push origin dev


### si tienen conflictos avisenme

## Issues — qué está pendiente

Los pendientes están en la pestaña **Projects** del repo. Antes de empezar a trabajar en algo, fíjense ahí para no pisar el trabajo de alguien más.
