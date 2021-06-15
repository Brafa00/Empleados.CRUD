## Sistema de Gestión de Empleados

## Tabla de contenidos

* [Introducción](#Introducción)
* [Tecnologías](#Tecnologías)
* [Ejecucion BackEnd](#Ejecucion-BackEnd)
* [Servidor de desarrollo](#Servidor-de-desarrollo)
* [Scaffolding de código](#Scaffolding-de-código)
* [construir](#construir)
* [Ejecución de pruebas unitarias](#Ejecución-de-pruebas-unitarias)
* [Ejecución de pruebas de un extremo a otro](#Ejecución-de-pruebas-de-un-extremo-a-otro)
* [Recomendaciones](#Recomendaciones)
* [Más ayuda](#Más-ayuda)

# Introducción

Se realiza sistema de administración de empleados, para la empresa Apis, en el cúal se solicita un CRUD basico teniendo en cuenta los requisitos funcionales como no funcionales descritos en un correo formal.

El siguiente sistema esta realizado para automatizar los procesos de recursos humanos, pero esta enfocado en la administración basica de los datos personales de los empleados.

El proyecto fue solicitado y realizado en Angular para el FrontEnd  y .Net Core con Sql Server para el desarrollo BackEnd.


# Tecnologías

Este proyecto se generó con:

* [Angular CLI] version 12.0.3.
* Node v14.17.0
* npm 6.14.13
* .net Core v3.1
* Microsoft Sql Server Management Studio 18
* Patron Repository
* Angular Material UI v12.0.4

## Ejecucion BackEnd

El proyecto es Code First,  lo que quiere decir  que dentro del proyecto se encuentran las migraciones de Entity Framework Core, las cuales se ejecutan automáticamente al iniciar la aplicación, creando así la estructura de la base de datos.

## Servidor de desarrollo

Ejecute `ng serve` para un servidor de desarrollo. Vaya a `http://localhost:4200/`. La aplicación se volverá a cargar automáticamente si cambia alguno de los archivos de origen.

## Scaffolding de código

Ejecute `ng generate component component-name` para generar un nuevo componente. También puede usar `ng generate directive|pipe|service|class|guard|interface|enum|module`.

## construir

Ejecutar para compilar el proyecto. Los artefactos de compilación se almacenarán en el directorio. `ng build` `dist/`

## Ejecución de pruebas unitarias

Ejecute `ng test` para ejecutar las pruebas unitarias a través de [Karma](https://karma-runner.github.io).

## Ejecución de pruebas de un extremo a otro

Ejecute `ng e2e` para ejecutar las pruebas de extremo a extremo a través de una plataforma de su elección. Para usar este comando, primero debe agregar un paquete que implemente capacidades de prueba de un extremo a otro.

## Recomendaciones

Ejecutar la aplicación en Visual Studio 2019 para la depuración.

## Más ayuda

Para obtener más ayuda sobre el uso de angular CLI vaya a [Angular CLI Overview and Command Reference](https://angular.io/cli) page.
Para obtener más informacion sobre el uso de Code First vaya a [Code First en una nueva base de datos](https://docs.microsoft.com/es-es/ef/ef6/modeling/code-first/workflows/new-database)
